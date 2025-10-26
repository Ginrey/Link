using System;
using System.Threading;

namespace Link.Pools
{
    public class BufferPool : StackPool<ArraySegment<byte>>
    {
        private const int HeaderSize = 8; // sizeof(int) * 2
        private const int CountOffset = 0;
        private const int IdOffset = 4;

        private static int _idCounter = 1;
        private readonly int _id;

        public int DefaultSize { get; }
        public bool FixedSize { get; }

        public BufferPool(int defaultSize, bool fixedSize = false, int maxFreeCount = 1024, int allocateDefaultCount = 16)
            : base(maxFreeCount, allocateDefaultCount)
        {
            DefaultSize = defaultSize;
            FixedSize = fixedSize;
            _id = Interlocked.Increment(ref _idCounter);
        }

        public override ArraySegment<byte> Create()
        {
            if (DefaultSize <= 0)
            {
                return new ArraySegment<byte>();
            }
            return new ArraySegment<byte>(new byte[DefaultSize]);
        }

        private bool Validate(byte[] buffer)
        {
            if (buffer.Length < HeaderSize) return false;

            int id = BitConverter.ToInt32(buffer, IdOffset);
            if (id != _id)
            {
                int count = BitConverter.ToInt32(buffer, CountOffset);
                if (count == 0) // First time this buffer is seen by this pool
                {
                    BitConverter.GetBytes(_id).CopyTo(buffer, IdOffset);
                    id = _id;
                }
            }
            return id == _id;
        }

        private int Change(byte[] buffer, int value)
        {
            if (buffer.Length < HeaderSize) return 0;

            int currentCount = BitConverter.ToInt32(buffer, CountOffset);
            int newCount = currentCount + value;
            BitConverter.GetBytes(newCount).CopyTo(buffer, CountOffset);
            return newCount;
        }

        public override ArraySegment<byte> Take()
        {
            lock (LockObject)
            {
                var result = base.Take();
                if (result.Array != null)
                {
                    Change(result.Array, -1);
                }
                return result;
            }
        }

        public bool Return(ArraySegment<byte> element)
        {
            return Return(element.Array, element.Offset, element.Count);
        }

        public virtual bool Return(byte[] buffer, int offset, int count)
        {
            if (buffer == null || DefaultSize <= 0 || buffer.Length < HeaderSize)
            {
                return false;
            }

            if (offset < HeaderSize)
            {
                count = count - (HeaderSize - offset);
                offset = HeaderSize;
            }

            if (count < DefaultSize)
            {
                return false;
            }

            if (!Validate(buffer))
            {
                return false;
            }

            bool returnedSuccessfully = false;
            lock (LockObject)
            {
                if (FreeItems.Count < MaxFreeCount || Change(buffer, 0) > 0)
                {
                    int returnedCount = 0;
                    for (int i = 0; i < count; i += DefaultSize)
                    {
                        int currentOffset = offset + i;
                        int currentCount = FixedSize ? DefaultSize : Math.Min(DefaultSize, count - i);

                        if (currentOffset + currentCount > buffer.Length) break;

                        if (base.Return(new ArraySegment<byte>(buffer, currentOffset, currentCount), true))
                        {
                            returnedCount++;
                            returnedSuccessfully = true;
                        }
                    }
                    Change(buffer, returnedCount);
                }
            }
            return returnedSuccessfully;
        }

        public override void Allocate(int count)
        {
            if (count <= 0) return;
            var buffer = new byte[HeaderSize + count * DefaultSize];
            Return(buffer, 0, buffer.Length);
        }
    }
}
