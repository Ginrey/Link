using System;
using System.Security.Cryptography;
using System.Text;

namespace Link.Security;

public sealed class MD5Hash : IDisposable
{
    private HMACMD5? _loginMD5;
    private byte[]? _hash;
    private bool _disposed;

    public byte[] GetHash(string login, string password, byte[] key)
    {
        ArgumentNullException.ThrowIfNull(login);
        ArgumentNullException.ThrowIfNull(password);
        ArgumentNullException.ThrowIfNull(key);

        byte[] loginData = Encoding.ASCII.GetBytes(login);
        byte[] authData = Encoding.ASCII.GetBytes(login + password);

        return GetHash(loginData, authData, key);
    }

    public byte[] GetHash(string login, byte[] authData, byte[] key)
    {
        ArgumentNullException.ThrowIfNull(login);
        ArgumentNullException.ThrowIfNull(authData);
        ArgumentNullException.ThrowIfNull(key);

        byte[] loginData = Encoding.ASCII.GetBytes(login);
        return GetHash(loginData, authData, key);
    }

    public byte[] GetHash(byte[] login, byte[] authData, byte[] key)
    {
        ArgumentNullException.ThrowIfNull(login);
        ArgumentNullException.ThrowIfNull(authData);
        ArgumentNullException.ThrowIfNull(key);

        using var md5 = MD5.Create();
        var authHash = md5.ComputeHash(authData);
        
        using var hmac = new HMACMD5(authHash);
        var hash = hmac.ComputeHash(key);

        SetHash(login, hash);
        return hash;
    }

    public void SetHash(string login, byte[] hash)
    {
        ArgumentNullException.ThrowIfNull(login);
        SetHash(Encoding.ASCII.GetBytes(login), hash);
    }

    public void SetHash(byte[] login, byte[] hash)
    {
        ArgumentNullException.ThrowIfNull(login);
        ArgumentNullException.ThrowIfNull(hash);

        _loginMD5?.Dispose();
        _loginMD5 = new HMACMD5(login);
        _hash = hash;
    }

    public byte[] GetKey(byte[] key)
    {
        ArgumentNullException.ThrowIfNull(key);
        ObjectDisposedException.ThrowIf(_disposed, this);

        if (_hash == null || _loginMD5 == null)
            throw new InvalidOperationException("Hash not initialized. Call SetHash or GetHash first.");

        byte[] hash02 = new byte[key.Length + _hash.Length];
        _hash.AsSpan().CopyTo(hash02);
        key.AsSpan().CopyTo(hash02.AsSpan(_hash.Length));

        return _loginMD5.ComputeHash(hash02);
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _disposed = true;
            _loginMD5?.Dispose();
            _loginMD5 = null;
            _hash = null;
        }
    }
}
