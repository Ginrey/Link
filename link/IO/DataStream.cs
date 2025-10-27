using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Link.IO;

/// <summary>
/// Реализация потока данных с поддержкой современных .NET 9 возможностей.
/// </summary>
public class DataStream : IDisposable
{
    private const int DefaultSize = 8;

    private byte[] _buffer;
    private int _pos;
    private Stack<bool>? _savedEndianness;

    /// <summary>
    /// Буфер текущего потока.
    /// </summary>
    public byte[] Buffer => _buffer;

    /// <summary>
    /// Позиция в текущем потоке.
    /// </summary>
    public int Position
    {
        get => _pos;
        set
        {
            if (value < 0 || value > Count)
                throw new IndexOutOfRangeException();

            _pos = value;
        }
    }

    /// <summary>
    /// Кол-во байт в потоке.
    /// </summary>
    public int Count { get; private set; }
    public void Resize(int count)
    {
        Reserve(count);
        Count = count;
    }

    /// <summary>
    /// Флаг: порядок байт обратный или прямой.
    /// </summary>
    public bool IsLittleEndian { get; set; } = true;

    public EndianBitConverter Converter => IsLittleEndian ? EndianBitConverter.Little : (EndianBitConverter)EndianBitConverter.Big;

    public byte this[int index]
    {
        get => _buffer[index];
        set => _buffer[index] = value;
    }

    /// <summary>
    /// Получить Span<byte> для текущих данных в потоке.
    /// </summary>
    public Span<byte> AsSpan() => _buffer.AsSpan(0, Count);

    /// <summary>
    /// Получить Span<byte> для непрочитанных данных в потоке.
    /// </summary>
    public Span<byte> AsSpanUnread() => _buffer.AsSpan(_pos, Count - _pos);

    /// <summary>
    /// Получить ReadOnlySpan<byte> для текущих данных в потоке.
    /// </summary>
    public ReadOnlySpan<byte> AsReadOnlySpan() => _buffer.AsSpan(0, Count);

    /// <summary>
    /// Получить ReadOnlySpan<byte> для непрочитанных данных в потоке.
    /// </summary>
    public ReadOnlySpan<byte> AsReadOnlySpanUnread() => _buffer.AsSpan(_pos, Count - _pos);

    /// <summary>
    /// Получить Memory<byte> для текущих данных в потоке.
    /// </summary>
    public Memory<byte> AsMemory() => _buffer.AsMemory(0, Count);

    /// <summary>
    /// Получить Memory<byte> для непрочитанных данных в потоке.
    /// </summary>
    public Memory<byte> AsMemoryUnread() => _buffer.AsMemory(_pos, Count - _pos);

    /// <summary>
    /// Явное преобразование byte[] в DataStream.
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static explicit operator DataStream(byte[] bytes)
    {
        return new DataStream(bytes);
    }

    /// <summary>
    /// Неявное преобразование DataStream в byte[].
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    public static implicit operator byte[] (DataStream stream)
    {
        return stream.GetBytes();
    }

    /// <summary>
    /// Инициализирует поток стандартного размера.
    /// </summary>
    public DataStream() : this(DefaultSize)
    {
    }

    /// <summary>
    /// Инициализирует поток с указанием минимального размера.
    /// </summary>
    /// <param name="count">Минимальный размер</param>
    public DataStream(int count)
    {
        Reserve(count);
    }

    /// <summary>
    /// Инициализирует поток, используя за основу массив байт.
    /// </summary>
    /// <param name="sourceBytes">Массив байт</param>
    public DataStream(byte[] sourceBytes)
    {
        Reserve(sourceBytes.Length);
        sourceBytes.AsSpan().CopyTo(_buffer);
        Count = sourceBytes.Length;
    }

    /// <summary>
    /// Инициализирует поток, используя часть массива байт.
    /// </summary>
    /// <param name="sourceBytes">Массив байт</param>
    /// <param name="position">Оффсет</param>
    /// <param name="count">Кол-во</param>
    public DataStream(byte[] sourceBytes, int position, int count)
    {
        Reserve(count);
        sourceBytes.AsSpan(position, count).CopyTo(_buffer);
        Count = count;
    }

    /// <summary>
    /// Инициализирует поток, используя ReadOnlySpan<byte>.
    /// </summary>
    /// <param name="sourceBytes">Span байт</param>
    public DataStream(ReadOnlySpan<byte> sourceBytes)
    {
        Reserve(sourceBytes.Length);
        sourceBytes.CopyTo(_buffer);
        Count = sourceBytes.Length;
    }

    /// <summary>
    /// Очистка потока от прочитанных байт.
    /// </summary>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DataStream Flush()
    {
        var len = Count - _pos;

        if (len != 0)
            _buffer.AsSpan(_pos, len).CopyTo(_buffer);

        _pos = 0;
        Count = len;

        return this;
    }

    /// <summary>
    /// Сбрасывает любые результаты чтения данных из потока.
    /// </summary>
    /// <returns></returns>
    public DataStream Reset()
    {
        _pos = 0;

        return this;
    }

    /// <summary>
    /// Очищаем поток.
    /// </summary>
    /// <returns></returns>
    public DataStream Clear()
    {
        // При записи данных в поток, вызовет очистку буфера
        Count = 0;
        _pos = 0;

        return this;
    }

    /// <summary>
    /// Запоминает текущий порядок байт при записи многобайтовых чисел.
    /// </summary>
    public void SaveEndianness()
    {
        if (_savedEndianness == null)
        {
            _savedEndianness = new Stack<bool>();
        }
        _savedEndianness.Push(IsLittleEndian);
    }

    /// <summary>
    /// Восстанавливает сохраненный ранее порядок байт при записи многобайтовых чисел.
    /// </summary>
    public void RestoreEndianness()
    {
        IsLittleEndian = _savedEndianness.Pop();
    }

    // Округляет размер до степени двойки (16, 32, 64, 128, 256, 512 etc)

    private static int[] _roundupBase =
    {
        1, 2, 4, 8,
        16, 32, 64, 128,
        256, 512, 1024, 2048,
        4096, 8192, 16384, 32768,
        65536, 131072, 262144, 524288,
        1048576, 2097152, 4194304, 8388608,
        16777216, 33554432, 67108864, 134217728,
        268435456, 536870912, 1073741824
    };
    private static int Roundup(int x)
    {
        var l = 4;
        var r = _roundupBase.Length - 1;

        while (l <= r)
        {
            var c = (l + r) >> 1;

            if (_roundupBase[c] > x) r = c - 1;
            else l = c + 1;
        }
        return _roundupBase[l];
    }

    // Выделяет нужное кол-во байт в потоке
    public void Reserve(int bytesCount)
    {
        if (_buffer == null || bytesCount > _buffer.Length)
        {
            Array.Resize(ref _buffer, Roundup(bytesCount));
        }
    }

    /// <summary>
    /// Проталкивает байт в конец потока.
    /// </summary>
    /// <param name="b">Байт</param>
    /// <returns></returns>
    public DataStream PushBack(byte b)
    {
        Reserve(Count + 1);
        _buffer[Count++] = b;

        return this;
    }

    /// <summary>
    /// Проталкивает массив байт в конец потока.
    /// </summary>
    /// <param name="bytes">Массив байт</param>
    /// <returns></returns>
    public DataStream PushBack(byte[] bytes)
    {
        if (bytes == null)
        {
            return this;
        }
        return PushBack(bytes, 0, bytes.Length);
    }

    /// <summary>
    /// Проталкивает Span байт в конец потока (оптимизированная версия).
    /// </summary>
    /// <param name="bytes">Span байт</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DataStream PushBack(ReadOnlySpan<byte> bytes)
    {
        if (bytes.IsEmpty)
        {
            return this;
        }
        Reserve(Count + bytes.Length);
        bytes.CopyTo(_buffer.AsSpan(Count));
        Count += bytes.Length;
        return this;
    }

    /// <summary>
    /// Проталкивает массив байт в конец потока.
    /// </summary>
    /// <param name="bytes">Массив байт</param>
    /// <param name="len">Количество байт</param>
    /// <param name="offset">Отступ</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DataStream PushBack(byte[] bytes, int offset, int len)
    {
        if (bytes == null)
        {
            return this;
        }
        Reserve(Count + len);
        bytes.AsSpan(offset, len).CopyTo(_buffer.AsSpan(Count));
        Count += len;

        return this;
    }

    /// <summary>
    /// Проталкивает байт в начало потока.
    /// </summary>
    /// <param name="b">Байт</param>
    /// <returns></returns>
    public DataStream PushFront(byte b)
    {
        return Insert(new[] { b });
    }

    /// <summary>
    /// Проталкивает массив байт в начало потока.
    /// </summary>
    /// <param name="bytes">Массив байт</param>
    /// <returns></returns>
    public DataStream PushFront(byte[] bytes)
    {
        return Insert(bytes);
    }

    /// <summary>
    /// Вставляет Byte[] в начало потока.
    /// </summary>
    /// <param name="insertArray"></param>
    /// <returns></returns>
    public DataStream Insert(byte[] insertArray)
    {
        if (insertArray == null)
        {
            return this;
        }
        return Insert(0, insertArray, 0, insertArray.Length);
    }

    /// <summary>
    /// Вставляет Byte[] по указанному оффсету.
    /// </summary>
    /// <param name="offset">Оффсет</param>
    /// <param name="insertArray">Массив байт</param>
    /// <returns></returns>
    public DataStream Insert(int offset, byte[] insertArray)
    {
        if (insertArray == null)
        {
            return this;
        }
        return Insert(offset, insertArray, 0, insertArray.Length);
    }

    /// <summary>
    /// Вставляет указанные байты в поток.
    /// </summary>
    /// <param name="offset">Оффсет потока</param>
    /// <param name="insertArray">Массив байт, который вставляем</param>
    /// <param name="insertArrayOffset">Оффсет вставляемого массива</param>
    /// <param name="bytesCount">Кол-во байт, которые вставляем</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DataStream Insert(int offset, byte[] insertArray, int insertArrayOffset, int bytesCount)
    {
        if (insertArray == null)
        {
            return this;
        }
        Reserve(Count + bytesCount);
        // Передвигаем байты по буферу назад, на длину вставляемого массива.
        _buffer.AsSpan(offset, Count - offset).CopyTo(_buffer.AsSpan(offset + bytesCount));
        // Вставляем данные
        insertArray.AsSpan(insertArrayOffset, bytesCount).CopyTo(_buffer.AsSpan(offset));
        Count += bytesCount;

        return this;
    }

    /// <summary>
    /// Вставляет указанные байты в поток (Span-версия).
    /// </summary>
    /// <param name="offset">Оффсет потока</param>
    /// <param name="insertSpan">Span байт для вставки</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DataStream Insert(int offset, ReadOnlySpan<byte> insertSpan)
    {
        if (insertSpan.IsEmpty)
        {
            return this;
        }
        Reserve(Count + insertSpan.Length);
        // Передвигаем байты по буферу назад, на длину вставляемого массива.
        _buffer.AsSpan(offset, Count - offset).CopyTo(_buffer.AsSpan(offset + insertSpan.Length));
        // Вставляем данные
        insertSpan.CopyTo(_buffer.AsSpan(offset));
        Count += insertSpan.Length;

        return this;
    }

    /// <summary>
    /// Проверяет, возможно ли прочитать хотя бы один байт из потока.
    /// </summary>
    /// <returns></returns>
    public bool CanReadBytes()
    {
        return _pos < Count;
    }
    /// <summary>
    /// Проверяет, возможно ли прочитать определенное кол-во байт из потока.
    /// </summary>
    /// <param name="bytesCount">Кол-во байт</param>
    /// <returns></returns>
    public bool CanReadBytes(int bytesCount)
    {
        return _pos + bytesCount <= Count;
    }

    /// <summary>
    /// Возвращает байты потока.
    /// </summary>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte[] GetBytes()
    {
        var rtnArray = new byte[Count - _pos];
        _buffer.AsSpan(_pos, Count - _pos).CopyTo(rtnArray);

        return rtnArray;
    }

    /// <summary>
    /// Копирует непрочитанные байты в указанный Span.
    /// </summary>
    /// <param name="destination">Целевой Span</param>
    /// <returns>Количество скопированных байт</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CopyTo(Span<byte> destination)
    {
        var length = Math.Min(Count - _pos, destination.Length);
        _buffer.AsSpan(_pos, length).CopyTo(destination);
        return length;
    }

    /// <summary>
    /// Пропускает указанное кол-во байт.
    /// </summary>
    /// <param name="bytesCount"></param>
    /// <returns></returns>
    public DataStream Skip(int bytesCount)
    {
        if (_pos + bytesCount < 0 || _pos + bytesCount > Count)
            throw new MarshallerException(this);

        _pos += bytesCount;

        return this;
    }

    /// <summary>
    /// Читает Byte из потока.
    /// </summary>
    /// <returns></returns>
    public byte ReadByte()
    {
        if (_pos + 1 > Count)
            throw new MarshallerException(this);

        return this[_pos++];
    }
    public bool TryRead(out byte b)
    {
        if (_pos + 1 > Count)
        {
            b = 0;
            return false;
        }
        else
        {
            b = this[_pos++];
            return true;
        }
    }

    /// <summary>
    /// Читаем SByte из потока.
    /// </summary>
    /// <returns></returns>
    public sbyte ReadSByte()
    {
        return (sbyte)ReadByte();
    }
    public bool TryRead(out sbyte b)
    {
        byte x;
        var result = TryRead(out x);
        b = (sbyte)x;
        return result;
    }

    /// <summary>
    /// Читаем Byte[] из потока.
    /// </summary>
    /// <param name="bytesCount">Кол-во байт</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte[] ReadBytes(int bytesCount)
    {
        if (_pos + bytesCount > Count)
            throw new MarshallerException(this);

        var rtnArray = new byte[bytesCount];
        _buffer.AsSpan(_pos, bytesCount).CopyTo(rtnArray);
        _pos += bytesCount;

        return rtnArray;
    }

    /// <summary>
    /// Читаем указанное кол-во байт в Span (оптимизированная версия).
    /// </summary>
    /// <param name="destination">Целевой Span</param>
    /// <returns>true если успешно</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryReadBytes(Span<byte> destination)
    {
        if (_pos + destination.Length > Count)
            return false;

        _buffer.AsSpan(_pos, destination.Length).CopyTo(destination);
        _pos += destination.Length;
        return true;
    }

    /// <summary>
    /// Читаем указанное кол-во байт в Span.
    /// </summary>
    /// <param name="destination">Целевой Span</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ReadBytes(Span<byte> destination)
    {
        if (_pos + destination.Length > Count)
            throw new MarshallerException(this);

        _buffer.AsSpan(_pos, destination.Length).CopyTo(destination);
        _pos += destination.Length;
    }

    public bool TryRead(out byte[]? buffer, int bytesCount)
    {
        if (_pos + bytesCount > Count)
        {
            buffer = null;
            return false;
        }
        else
        {
            buffer = new byte[bytesCount];
            _buffer.AsSpan(_pos, bytesCount).CopyTo(buffer);

            _pos += bytesCount;

            return true;
        }
    }
    public bool TryRead(byte[] buffer)
    {
        return TryRead(buffer, 0, buffer.Length);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryRead(byte[] buffer, int offset, int count)
    {
        if (_pos + count > Count)
        {
            return false;
        }
        else
        {
            _buffer.AsSpan(_pos, count).CopyTo(buffer.AsSpan(offset));
            _pos += count;
            return true;
        }
    }

    /// <summary>
    /// Читаем CUInt32 размер массива, затем Byte[] из потока.
    /// </summary>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte[] ReadBytes()
    {
        var length = (int)ReadCompactUInt32();

        if (_pos + length > Count)
            throw new MarshallerException(this);

        var rtnArray = new byte[length];
        _buffer.AsSpan(_pos, length).CopyTo(rtnArray);
        _pos += length;

        return rtnArray;
    }
    public bool TryRead(out byte[]? buffer)
    {
        buffer = null;

        var pos = _pos;
        uint length;
        if (!TryReadCompactUInt32(out length))
        {
            _pos = pos;
            return false;
        }
        bool result = TryRead(out buffer, (int)length);
        if (!result)
        {
            _pos = pos;
        }
        return result;
    }

    /// <summary>
    /// Читает Boolean из потока.
    /// </summary>
    /// <returns></returns>
    public bool ReadBoolean()
    {
        return ReadByte() == 1;
    }
    public bool TryRead(out bool b)
    {
        byte bt;
        bool result = TryRead(out bt);
        b = bt > 0;
        return result;
    }

    /// <summary>
    /// Читает UInt16 из потока.
    /// </summary>
    /// <returns></returns>
    public ushort ReadUInt16()
    {
        if (_pos + 2 > Count)
            throw new MarshallerException(this);

        var rtnValue = Converter.ToUInt16(_buffer, _pos);
        _pos += 2;

        return rtnValue;
    }
    public bool TryRead(out ushort value)
    {
        if (_pos + 2 > Count)
        {
            value = 0;
            return false;
        }
        else
        {
            value = Converter.ToUInt16(_buffer, _pos);
            _pos += 2;

            return true;
        }
    }

    /// <summary>
    /// Читает UInt32 из потока.
    /// </summary>
    /// <returns></returns>
    public uint ReadUInt32()
    {
        if (_pos + 4 > Count)
            throw new MarshallerException(this);

        var rtnValue = Converter.ToUInt32(_buffer, _pos);
        _pos += 4;

        return rtnValue;
    }

    public bool TryRead(out uint value)
    {
        if (_pos + 4 > Count)
        {
            value = 0;
            return false;
        }
        else
        {
            value = Converter.ToUInt32(_buffer, _pos);
            _pos += 4;

            return true;
        }
    }

    /// <summary>
    /// Читает UInt64 из потока.
    /// </summary>
    /// <returns></returns>
    public ulong ReadUInt64()
    {
        if (_pos + 8 > Count)
            throw new MarshallerException(this);

        var rtnValue = Converter.ToUInt64(_buffer, _pos);
        _pos += 8;

        return rtnValue;
    }
    public bool TryRead(out ulong value)
    {
        if (_pos + 8 > Count)
        {
            value = 0;
            return false;
        }
        else
        {
            value = Converter.ToUInt64(_buffer, _pos);
            _pos += 8;

            return true;
        }
    }

    /// <summary>
    /// Читает Int16 из потока.
    /// </summary>
    /// <returns></returns>
    public short ReadInt16()
    {
        if (_pos + 2 > Count)
            throw new MarshallerException(this);

        var rtnValue = Converter.ToInt16(_buffer, _pos);

        _pos += 2;

        return rtnValue;
    }
    public bool TryRead(out short value)
    {
        if (_pos + 2 > Count)
        {
            value = 0;
            return false;
        }
        else
        {
            value = Converter.ToInt16(_buffer, _pos);
            _pos += 2;

            return true;
        }
    }

    /// <summary>
    /// Читает Int32 из потока.
    /// </summary>
    /// <returns></returns>
    public int ReadInt32()
    {
        if (_pos + 4 > Count)
            throw new MarshallerException(this);

        var rtnValue = Converter.ToInt32(_buffer, _pos);
        _pos += 4;

        return rtnValue;
    }
    public bool TryRead(out int value)
    {
        if (_pos + 4 > Count)
        {
            value = 0;
            return false;
        }
        else
        {
            value = Converter.ToInt32(_buffer, _pos);
            _pos += 4;

            return true;
        }
    }

    /// <summary>
    /// Читает Int64 из потока.
    /// </summary>
    /// <returns></returns>
    public long ReadInt64()
    {
        if (_pos + 8 > Count)
            throw new MarshallerException(this);

        var rtnValue = Converter.ToInt64(_buffer, _pos);
        _pos += 8;

        return rtnValue;
    }
    public bool TryRead(out long value)
    {
        if (_pos + 8 > Count)
        {
            value = 0;
            return false;
        }
        else
        {
            value = Converter.ToInt64(_buffer, _pos);
            _pos += 8;

            return true;
        }
    }

    /// <summary>
    /// Читает Single из потока.
    /// </summary>
    /// <returns></returns>
    public float ReadSingle()
    {
        if (_pos + 4 > Count)
            throw new MarshallerException(this);

        var rtnValue = Converter.ToSingle(_buffer, _pos);
        _pos += 4;

        return rtnValue;
    }
    public bool TryRead(out float value)
    {
        if (_pos + 4 > Count)
        {
            value = 0;
            return false;
        }
        else
        {
            value = Converter.ToSingle(_buffer, _pos);
            _pos += 4;

            return true;
        }
    }

    /// <summary>
    /// Читает Double из потока.
    /// </summary>
    /// <returns></returns>
    public double ReadDouble()
    {
        if (_pos + 8 > Count)
            throw new MarshallerException(this);

        var rtnValue = Converter.ToDouble(_buffer, _pos);
        _pos += 8;

        return rtnValue;
    }
    public bool TryRead(out double value)
    {
        if (_pos + 8 > Count)
        {
            value = 0;
            return false;
        }
        else
        {
            value = Converter.ToDouble(_buffer, _pos);
            _pos += 8;

            return true;
        }
    }

    /// <summary>
    /// Читает Compact UInt32 из потока.
    /// </summary>
    /// <returns></returns>
    public uint ReadCompactUInt32()
    {
        if (_pos == Count)
            throw new MarshallerException(this);

        uint rtnValue;
        // CUint32 всегда записывается с порядком байт BE и читается так же, поэтому для
        // правильного чтения, мы переключаем порядок байт принудительно в BE, если он LE.
        // Сохраняем начальное значение флага, для возврата в исходное состояние потом.
        var isLe = IsLittleEndian;

        if (isLe)
            IsLittleEndian = false;

        switch (this[_pos] & 0xE0)
        {
            case 0xE0:
                ReadByte();
                rtnValue = (uint)ReadInt32();
                break;
            case 0xC0:
                rtnValue = (uint)ReadInt32() & 0x3FFFFFFF;
                break;
            case 0x80:
            case 0xA0:
                rtnValue = (uint)ReadInt16() & 0x7FFF;
                break;
            default:
                rtnValue = ReadByte();
                break;
        }

        if (isLe) IsLittleEndian = true;
        return rtnValue;
    }

    public bool TryReadCompactUInt32(out uint value)
    {
        value = 0;

        if (_pos == Count)
            return false;

        var isLe = IsLittleEndian;

        if (isLe)
            IsLittleEndian = false;

        switch (this[_pos] & 0xE0)
        {
            case 0xE0:
                if (!CanReadBytes(1))
                    return false;

                ReadByte();

                if (!CanReadBytes(4))
                    return false;

                value = (uint)ReadInt32();
                break;
            case 0xC0:
                if (!CanReadBytes(4))
                    return false;

                value = (uint)ReadInt32() & 0x3FFFFFFF;
                break;
            case 0x80:
            case 0xA0:
                if (!CanReadBytes(2))
                    return false;

                value = (uint)ReadInt16() & 0x7FFF;
                break;
            default:
                if (!CanReadBytes(1))
                    return false;

                value = ReadByte();
                break;
        }

        if (isLe)
            IsLittleEndian = true;

        return true;
    }

    /// <summary>
    /// Читает вложенный поток.
    /// </summary>
    /// <returns></returns>
    public DataStream ReadDataStream()
    {
        var i = ReadCompactUInt32();

        if (_pos + i > Count)
            throw new MarshallerException(this);

        var newStream = new DataStream(_buffer, _pos, (int)i) { IsLittleEndian = IsLittleEndian };
        _pos += (int)i;

        return newStream;
    }
    public DataStream ReadDataStream(DataStream dataStream)
    {
        if (!TryRead(dataStream))
        {
            throw new MarshallerException(this, "ReadDataStream error");
        }
        return dataStream;
    }

    public bool TryRead(out DataStream value)
    {
        value = null;
        var pos = _pos;

        uint length;
        if (!TryReadCompactUInt32(out length) || !CanReadBytes((int)length))
        {
            _pos = pos;
            return false;
        }

        value = new DataStream((int)length);
        if (!TryRead(value._buffer, 0, (int)length))
        {
            _pos = pos;
            return false;
        }
        value.Count = (int)length;
        return true;
    }
    public bool TryRead(DataStream dataStream)
    {
        var pos = _pos;

        uint length;
        if (!TryReadCompactUInt32(out length) || !CanReadBytes((int)length))
        {
            _pos = pos;
            return false;
        }

        dataStream.Reserve((int)length);
        if (!TryRead(dataStream._buffer, 0, (int)length))
        {
            _pos = pos;
            return false;
        }
        dataStream.Count = (int)length;
        return true;
    }

    public DataStream ReadValues<T>(params T[] values) where T : IDataSerializer
    {
        if (!TryReadValues<T>(values))
        {
            throw new MarshallerException(this, "TryDesrialize error");
        }
        return this;
    }
    public bool TryReadValues<T>(params T[] values) where T : IDataSerializer
    {
        foreach (var x in values)
        {
            if (x == null || !TryRead(x))
            {
                return false;
            }
        }
        return false;
    }
    public DataStream WriteValues<T>(params T[] values) where T : IDataSerializer
    {
        foreach (var x in values)
        {
            if (x != null)
            {
                Write<T>(x);
            }
        }
        return this;
    }

    /// <summary>
    /// Читает объект, наследуемый от PacketMarshaller используя текущий поток.
    /// </summary>
    /// <returns></returns>
    public T Read<T>()
    {
        T value;
        if (TryRead<T>(out value))
        {
            return value;
        }
        else
        {
            throw new MarshallerException(this, "TryDesrialize error");
        }
    }
    public bool TryRead<T>(out T? value) where T : struct
    {
        T x;
        if (TryRead(out x))
        {
            value = x;
            return true;
        }
        else
        {
            value = null;
            return false;
        }
    }
    public bool TryRead<T>(out T value)
    {
        return DataStreamIO<T>.TryRead(this, out value);
    }

    /// <summary>
    /// Читает объект, наследуемый от PacketMarshaller используя текущий поток.
    /// </summary>
    /// <param name="packetMarshaller">Объект</param>
    /// <param name="versionControl">Версия протокола</param>
    /// <returns></returns>
    public DataStream Read(IDataSerializer packetMarshaller)
    {
        if (!TryRead(this))
        {
            throw new MarshallerException(this, "TryDesrialize error");
        }
        return this;
    }
    public bool TryRead(IDataSerializer dataSerializer)
    {
        var pos = _pos;
        if (!dataSerializer.TryDeserialize(this))
        {
            _pos = pos;
            return false;
        }
        return true;
    }

    /// <summary>
    /// Читает массив объектов указанного типа, наследуемых от PacketSerializer.
    /// </summary>
    /// <typeparam name="T">Тип объекта</typeparam>
    /// <param name="versionControl">Версия протокола</param>
    /// <returns></returns>
    public T[] ReadArray<T>() where T : IDataSerializer
    {
        var itemsCount = ReadCompactUInt32();
        var collection = new List<T>();

        for (var i = 0; i < itemsCount; i++)
        {
            collection.Add(Read<T>());
        }

        return collection.ToArray();
    }
    public bool TryRead<T>(T[] result, int offset, int count) where T : IDataSerializer
    {
        var pos = _pos;
        var ok = true;
        for (var i = 0; i < count && ok; i++)
        {
            ok &= TryRead<T>(out result[offset + i]);
        }
        if (!ok)
        {
            _pos = pos;
        }
        return ok;
    }
    public bool TryRead<T>(T[] result) where T : IDataSerializer
    {
        return TryRead<T>(result, 0, result.Length);
    }
    public bool TryRead<T>(out T[] result) where T : IDataSerializer
    {
        var pos = _pos;
        uint length;
        if (!TryReadCompactUInt32(out length))
        {
            _pos = pos;
            result = null;
            return false;
        }
        if (!TryRead<T>(out result, (int)length))
        {
            _pos = pos;
            result = null;
            return false;
        }
        return true;
    }
    public bool TryRead<T>(out T[] result, int length) where T : IDataSerializer
    {
        var pos = _pos;

        result = new T[length];
        if (!TryRead<T>(result))
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Читает массив объектов указанного типа, наследуемых от PacketSerializer.
    /// </summary>
    /// <typeparam name="T">Тип объекта</typeparam>
    /// <param name="itemsCount">Количество элементов коллекции</param>
    /// <param name="versionControl">Версия протокола</param>
    /// <returns></returns>
    public T[] ReadArray<T>(int itemsCount) where T : IDataSerializer
    {
        var collection = new List<T>();

        for (var i = 0; i < itemsCount; i++)
        {
            collection.Add(Read<T>());
        }

        return collection.ToArray();
    }
    //--
        

    public bool TryRead(Encoding encoding, out string s)
    {
        byte[] bts;
        if (!TryRead(out bts))
        {
            s = string.Empty;
            return false;
        }
        s = encoding.GetString(bts);
        return true;
    }
    public bool TryRead(Encoding encoding, out string s, int length)
    {
        byte[] bts;
        if (!TryRead(out bts, length))
        {
            s = string.Empty;
            return false;
        }
        s = encoding.GetString(bts);
        return true;
    }

    /// <summary>
    /// Читает ASCII строку из потока.
    /// </summary>
    /// <returns></returns>
    public string ReadAsciiString()
    {
        var length = ReadCompactUInt32();
        var strBuf = ReadBytes((int)length);

        return Encoding.ASCII.GetString(strBuf);
    }
    /// <summary>
    /// Читает ASCII строку из потока.
    /// </summary>
    /// <returns></returns>
    public string ReadAsciiString(int length)
    {
        var strBuf = ReadBytes((int)length);

        return Encoding.ASCII.GetString(strBuf);
    }
    public bool TryReadAsciiString(out string s)
    {
        return TryRead(Encoding.ASCII, out s);
    }
    public bool TryReadAsciiString(out string s, int length)
    {
        return TryRead(Encoding.ASCII, out s, length);
    }

    /// <summary>
    /// Читает Uncicode строку из потока.
    /// </summary>
    /// <returns></returns>
    public string ReadUnicodeString()
    {
        var length = ReadCompactUInt32();
        var strBuf = ReadBytes((int)length);

        return Encoding.Unicode.GetString(strBuf);
    }

    /// <summary>
    /// Читает Uncicode строку из потока.
    /// </summary>
    /// <returns></returns>
    public string ReadUnicodeString(int length)
    {
        var strBuf = ReadBytes(length);

        return Encoding.Unicode.GetString(strBuf);
    }
    public bool TryReadUnicodeString(out string s)
    {
        return TryRead(Encoding.Unicode, out s);
    }
    public bool TryReadUnicodeString(out string s, int length)
    {
        return TryRead(Encoding.Unicode, out s, length);
    }

    /// <summary>
    /// Читатет UTF8 строку из потока.
    /// </summary>
    /// <returns></returns>
    public string ReadUtf8String()
    {
        var length = ReadCompactUInt32();
        var strBuf = ReadBytes((int)length);

        return Encoding.UTF8.GetString(strBuf);
    }
    /// <summary>
    /// Читатет UTF8 строку из потока.
    /// </summary>
    /// <returns></returns>
    public string ReadUtf8String(int length)
    {
        var strBuf = ReadBytes((int)length);

        return Encoding.UTF8.GetString(strBuf);
    }

    public bool TryReadUtf8String(out string s)
    {
        return TryRead(Encoding.UTF8, out s);
    }
    public bool TryReadUtf8String(out string s, int length)
    {
        return TryRead(Encoding.UTF8, out s, length);
    }

    /// <summary>
    /// Записывает Byte в поток.
    /// </summary>
    /// <param name="value">Байт</param>
    /// <returns></returns>
    public DataStream Write(byte value)
    {
        return PushBack(value);
    }

    /// <summary>
    /// Записывает SByte в поток.
    /// </summary>
    /// <param name="value">SByte</param>
    /// <returns></returns>
    public DataStream Write(sbyte value)
    {
        return Write((byte)value);
    }

    /// <summary>
    /// Записывает Byte[] в поток.
    /// </summary>
    /// <param name="value">Массив байт</param>
    /// <returns></returns>
    public DataStream Write(byte[] value)
    {
        return value == null ? this : PushBack(value);
    }

    /// <summary>
    /// Записывает Byte[] в поток. Если value = null и appendSize = true, то будет записан CUInt 0.
    /// </summary>
    /// <param name="value">Массив байт</param>
    /// <param name="appendSize">Флаг: записать длину массива сначала</param>
    /// <returns></returns>
    public DataStream Write(byte[] value, bool appendSize)
    {
        if (value == null)
        {
            if (appendSize)
                WriteCompactUInt32(0);

            return this;
        }

        if (appendSize)
            WriteCompactUInt32((uint)value.Length);

        return PushBack(value);
    }

    /// <summary>
    /// Записывает Boolean в поток.
    /// </summary>
    /// <param name="value">Boolean</param>
    /// <returns></returns>
    public DataStream Write(bool value)
    {
        return Write(value ? (byte)1 : (byte)0);
    }

    /// <summary>
    /// Записывает Int16 в поток.
    /// </summary>
    /// <param name="value">Int16</param>
    /// <returns></returns>
    public DataStream Write(short value)
    {
        return Write(Converter.GetBytes(value));
    }

    /// <summary>
    /// Записывает Int32 в поток.
    /// </summary>
    /// <param name="value">Int32</param>
    /// <returns></returns>
    public DataStream Write(int value)
    {
        return Write(Converter.GetBytes(value));
    }

    /// <summary>
    /// Записывает Int64 в поток.
    /// </summary>
    /// <param name="value">Int64</param>
    /// <returns></returns>
    public DataStream Write(long value)
    {
        return Write(Converter.GetBytes(value));
    }

    /// <summary>
    /// Записывает UInt16 в поток.
    /// </summary>
    /// <param name="value">UInt16</param>
    /// <returns></returns>
    public DataStream Write(ushort value)
    {
        return Write(Converter.GetBytes(value));
    }

    /// <summary>
    /// Записывает UInt32 в поток.
    /// </summary>
    /// <param name="value">UInt32</param>
    /// <returns></returns>
    public DataStream Write(uint value)
    {
        return Write(Converter.GetBytes(value));
    }

    /// <summary>
    /// Записывает UInt64 в поток.
    /// </summary>
    /// <param name="value">UInt64</param>
    /// <returns></returns>
    public DataStream Write(ulong value)
    {
        return Write(Converter.GetBytes(value));
    }

    /// <summary>
    /// Записывает Float в поток.
    /// </summary>
    /// <param name="value">Float</param>
    /// <returns></returns>
    public DataStream Write(float value)
    {
        return Write(Converter.GetBytes(value));
    }

    /// <summary>
    /// Записывает Double в поток.
    /// </summary>
    /// <param name="value">Double</param>
    /// <returns></returns>
    public DataStream Write(double value)
    {
        return Write(Converter.GetBytes(value));
    }

    /// <summary>
    /// Записывает данные другого потока.
    /// </summary>
    /// <param name="value">DataStream</param>
    /// <returns></returns>
    public DataStream Write(DataStream value)
    {
        return Write(value.GetBytes(), true);
    }

    /// <summary>
    /// Записывает объект, наследуемый от PacketMarshaller в поток.
    /// </summary>
    /// <param name="value">Объект</param>
    /// <returns></returns>
    public DataStream Write(IDataSerializer value)
    {
        return value.Serialize(this);
    }

    public DataStream Write<T>(T value)
    {
        DataStreamIO<T>.Write(this, value);
        return this;
    }
    public DataStream Write<T>(T? value) where T : struct
    {
        if (value == null)
        {
            DataStreamIO<T>.Write(this, default(T));
        }
        else
        {
            DataStreamIO<T>.Write(this, value.Value);
        }
        return this;
    }

    /// <summary>
    /// Записывает коллекцию объектов, наследуемых от PacketMarshaller в поток.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="values"></param>
    /// <returns></returns>
    public DataStream Write<T>(ICollection<T> values)
    {
        return Write<T>(values, true);
    }
    /// <summary>
    /// Записывает коллекцию объектов, наследуемых от PacketMarshaller в поток.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="values"></param>
    /// <returns></returns>
    public DataStream Write<T>(ICollection<T> values, bool appendLength)
    {
        if (appendLength)
        {
            WriteCompactUInt32((uint)values.Count);
        }
        var writer = DataStreamIO<T>.Writer;
        foreach (var m in values)
        {
            writer.Invoke(this, m);
        }

        return this;
    }

    /// <summary>
    /// Записывает CUInt32 в поток.
    /// </summary>
    /// <param name="value">UInt32</param>
    /// <returns></returns>
    public DataStream WriteCompactUInt32(uint value)
    {
        return Write(EndianBitConverter.Big.GetCompactUInt32Bytes(value));
    }

    /// <summary>
    /// Записывает CUInt32 в поток.
    /// </summary>
    /// <param name="value">Int32</param>
    /// <returns></returns>
    public DataStream WriteCompactUInt32(int value)
    {
        return WriteCompactUInt32((uint)value);
    }

    /// <summary>
    /// Записывает ASCII строку в поток.
    /// </summary>
    /// <param name="value">Строка</param>
    /// <returns></returns>
    public DataStream WriteAsciiString(string value)
    {
        var strBuf = Encoding.ASCII.GetBytes(value);
        return Write(strBuf, true);
    }

    /// <summary>
    /// Записывает ASCII строку в поток.
    /// </summary>
    /// <param name="value">Строка</param>
    /// <param name="appendLength">Флаг: записать длину массива сначала</param>
    /// <returns></returns>
    public DataStream WriteAsciiString(string value, bool appendLength)
    {
        var strBuf = Encoding.ASCII.GetBytes(value);
        return Write(strBuf, appendLength);
    }

    /// <summary>
    /// Записывает Unicode строку в поток.
    /// </summary>
    /// <param name="value">Строка</param>
    /// <returns></returns>
    public DataStream WriteUnicodeString(string value)
    {
        var strBuf = Encoding.Unicode.GetBytes(value);
        return Write(strBuf, true);
    }

    /// <summary>
    /// Записывает Unicode строку в поток.
    /// </summary>
    /// <param name="value">Строка</param>
    /// <param name="appendLength">Флаг: записать длину массива сначала</param>
    /// <returns></returns>
    public DataStream WriteUnicodeString(string value, bool appendLength)
    {
        var strBuf = Encoding.Unicode.GetBytes(value);
        return Write(strBuf, appendLength);
    }

    /// <summary>
    /// Записывает UTF8 строку в поток.
    /// </summary>
    /// <param name="value">Строка</param>
    /// <returns></returns>
    public DataStream WriteUtf8String(string value)
    {
        var strBuf = Encoding.UTF8.GetBytes(value);
        return Write(strBuf, true);
    }

    /// <summary>
    /// Записывает UTF8 строку в поток.
    /// </summary>
    /// <param name="value">Строка</param>
    /// <param name="appendLength">Флаг: записать длину массива сначала</param>
    /// <returns></returns>
    public DataStream WriteUtf8String(string value, bool appendLength)
    {
        var strBuf = Encoding.UTF8.GetBytes(value);
        return Write(strBuf, appendLength);
    }
    /// <summary>
    /// Получает Byte[] из любого DataSerializer объекта.
    /// </summary>
    /// <param name="value">DataSerializer</param>
    /// <param name="isLittleEndian">Флаг LE или BE</param>
    /// <param name="versionControl">Версия протокола</param>
    /// <returns></returns>
    public static byte[] ToBytesArray(IDataSerializer value, bool isLittleEndian)
    {
        return value.Serialize(new DataStream { IsLittleEndian = isLittleEndian }).GetBytes();
    }

    /// <summary>
    /// Сравнение с потоком.
    /// </summary>
    /// <param name="stream">Поток, с которым идет сравнение</param>
    /// <returns></returns>
    public bool Equals(DataStream stream)
    {
        if (Count != stream.Count)
            return false;

        for (var i = 0; i < Count; i++)
        {
            if (this[i] != stream[i])
            {
                return false;
            }
        }

        return true;
    }

    public override bool Equals(object obj)
    {
        var ds = obj as DataStream;
        return ds != null && Equals(ds);
    }
        
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public void Dispose()
    {
    }
}
