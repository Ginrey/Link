using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Link.Security;

public class MD5Hash : IDisposable
{
    private MD5? MD5;
    private HMACMD5? LoginMD5;

    private byte[]? Hash;
    private bool disposed;

    public MD5Hash()
    {
        MD5 = MD5.Create();
    }

    public byte[] GetHash(string login, string password, byte[] key)
    {
        byte[] loginData = Encoding.ASCII.GetBytes(login);
        byte[] authData = Encoding.ASCII.GetBytes(login + password);

        return GetHash(loginData, authData, key);
            
    }
    public byte[] GetHash(string login, byte[] authData, byte[] key)
    {
        byte[] loginData = Encoding.ASCII.GetBytes(login);

        return GetHash(loginData, authData, key);
    }

    public byte[] GetHash(byte[] login, byte[] authData, byte[] key)
    {
        if (MD5 == null)
            throw new ObjectDisposedException(nameof(MD5Hash));

        var hash = new HMACMD5(MD5.ComputeHash(authData)).ComputeHash(key);

        SetHash(login, hash);

        return hash;
    }

    /// <summary>
    /// Оптимизированная версия с использованием Span для снижения аллокаций.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte[] GetHashOptimized(ReadOnlySpan<byte> login, ReadOnlySpan<byte> authData, ReadOnlySpan<byte> key)
    {
        if (MD5 == null)
            throw new ObjectDisposedException(nameof(MD5Hash));

        Span<byte> authHashBuffer = stackalloc byte[16]; // MD5 всегда 16 байт
        if (!MD5.TryComputeHash(authData, authHashBuffer, out var authHashBytes) || authHashBytes != 16)
            throw new InvalidOperationException("Failed to compute MD5 hash");

        using var hmac = new HMACMD5(authHashBuffer.ToArray());
        var hash = hmac.ComputeHash(key.ToArray());

        SetHash(login.ToArray(), hash);

        return hash;
    }

    public void SetHash(string login, byte[] hash)
    {
        SetHash(Encoding.ASCII.GetBytes(login), hash);
    }
        
    public void SetHash(byte[] login, byte[] hash)
    {
        LoginMD5?.Dispose();
        LoginMD5 = new HMACMD5(login);
        Hash = hash;
    }

    public byte[] GetKey(byte[] key)
    {
        if (LoginMD5 == null || Hash == null)
            throw new InvalidOperationException("Hash not set");

        byte[] hash02 = new byte[key.Length + Hash.Length];

        Hash.CopyTo(hash02.AsSpan());
        key.CopyTo(hash02.AsSpan(Hash.Length));

        return LoginMD5.ComputeHash(hash02);
    }

    /// <summary>
    /// Оптимизированная версия GetKey с использованием Span.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte[] GetKeyOptimized(ReadOnlySpan<byte> key)
    {
        if (LoginMD5 == null || Hash == null)
            throw new InvalidOperationException("Hash not set");

        // Используем stackalloc для небольших буферов (обычно key + hash < 1024)
        Span<byte> combined = key.Length + Hash.Length <= 1024 
            ? stackalloc byte[key.Length + Hash.Length]
            : new byte[key.Length + Hash.Length];

        Hash.CopyTo(combined);
        key.CopyTo(combined.Slice(Hash.Length));

        return LoginMD5.ComputeHash(combined.ToArray());
    }

    public void Dispose()
    {
        if (!disposed)
        {
            MD5?.Dispose();
            LoginMD5?.Dispose();
            disposed = true;
        }
    }
}