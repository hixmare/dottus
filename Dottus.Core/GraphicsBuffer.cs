using System;
using System.Runtime.CompilerServices;
using OpenTK.Graphics.OpenGL4;

using Boolean = System.Boolean;

namespace Dottus.Core
{
    public class GraphicsBuffer
    {
        protected internal Int32 Id { get; protected set; }
        protected internal IntPtr Data { get; protected set; }

        public BufferTarget Target { get; }
        public BufferAccessMask AccessMask { get; }
        public BufferStorageFlags StorageFlags { get; }

        public Int32 Cursor { get; protected set; }
        public Int32 Length { get; protected set; }

        public Boolean IsEndOfBuffer => Cursor == Length;

        public GraphicsBuffer(
            BufferTarget target,
            BufferStorageFlags storageFlags =
                BufferStorageFlags.MapReadBit | BufferStorageFlags.MapWriteBit | BufferStorageFlags.DynamicStorageBit |
                BufferStorageFlags.MapCoherentBit | BufferStorageFlags.MapPersistentBit,
            BufferAccessMask accessMask =
                BufferAccessMask.MapReadBit | BufferAccessMask.MapWriteBit |
                BufferAccessMask.MapCoherentBit | BufferAccessMask.MapPersistentBit)
        {
            Target = target;
            StorageFlags = storageFlags;
            AccessMask = accessMask;

            Cursor = 0;
            Length = DefaultLength;

            Allocate();
        }

        ~GraphicsBuffer() => GL.DeleteBuffer(Id);

        public void Allocate()
        {
            Id = GL.GenBuffer();
            GL.BindBuffer(Target, Id);
            GL.BufferStorage(Target, Length, IntPtr.Zero, StorageFlags);
            Data = GL.MapBufferRange(Target, IntPtr.Zero, Length, AccessMask);
        }

        public void Deallocate()
        {
            GL.DeleteBuffer(Id);
            Data = IntPtr.Zero;
            Id = -1;
        }

        public void Reallocate() => Reallocate(Length);

        public void Reallocate(Int32 newLength)
        {
            if ((UInt32)newLength > (UInt32)Length) { throw new ArgumentOutOfRangeException(nameof(newLength)); }
            /* Allocate new buffer */
            (Int32 id, IntPtr data, Int32 len) prev = (Id, Data, Length);
            Length = newLength;
            Allocate();
            /* Copy previous data */
            unsafe { System.Buffer.MemoryCopy((void*)prev.data, (void*)Data, Length, prev.len); }
            /* Deallocate previous buffer */
            GL.DeleteBuffer(prev.id);
        }

        public Byte Peek()
        {
            if (IsEndOfBuffer) { throw new InvalidOperationException("End of buffer"); }
            return this[Cursor];
        }

        public T Peek<T>() where T : struct
        {
            if (IsEndOfBuffer) { throw new InvalidOperationException("End of buffer"); }
            unsafe { return Unsafe.Read<T>((void*)(Data + Cursor)); }
        }

        public ReadOnlySpan<T> Peek<T>(Int32 count) where T : struct
        {
            var sizeOfT = Unsafe.SizeOf<T>();
            unsafe
            {
                var result = new ReadOnlySpan<T>((void*)(Data + Cursor), count * sizeOfT);
                return result;
            }
        }

        public Byte Read()
        {
            if (IsEndOfBuffer) { throw new InvalidOperationException("End of buffer"); }
            return this[Cursor++];
        }

        public T Read<T>(out Int32 advanced) where T : struct
        {
            if (IsEndOfBuffer) { throw new InvalidOperationException("End of buffer"); }
            var result = Peek<T>();
            Cursor += (advanced = Unsafe.SizeOf<T>());
            return result;
        }

        public ReadOnlySpan<T> Read<T>(Int32 count, out Int32 advanced) where T : struct
        {
            if (count <= 0 || Cursor + count >= Length) { throw new ArgumentOutOfRangeException(nameof(count)); }
            var result = Peek<T>(count);
            Cursor += (advanced = count * Unsafe.SizeOf<T>());
            return result;
        }

        public void Seek(Int32 index)
        {
            if ((UInt32)index >= (UInt32)Length) { throw new IndexOutOfRangeException(nameof(index)); }
            Cursor = index;
        }

        public void Write(Byte value)
        {
            if (IsEndOfBuffer) { Reallocate(Length * 2); }
            this[Cursor++] = value;
        }

        public Int32 Write<T>(T value) where T : struct
        {
            if (IsEndOfBuffer) { Reallocate(Length * 2); }
            var sizeOfT = Unsafe.SizeOf<T>();
            unsafe { Unsafe.Write<T>((void*)(Data + Cursor), value); }
            Cursor += sizeOfT;
            return sizeOfT;
        }

        public Int32 Write<T>(ReadOnlySpan<T> values) where T : struct
        {
            if (Cursor + values.Length >= Length)
            {
                var multiplier = 2;
                while (Length * multiplier <= Cursor + values.Length) { multiplier *= 2; }
                Reallocate(Length * multiplier);
            }
            var sizeOfT = Unsafe.SizeOf<T>();
            unsafe
            {
                var dest = new Span<T>((void*)(Data + Cursor), values.Length);
                values.CopyTo(dest);
                Cursor += values.Length * sizeOfT;
                return values.Length * sizeOfT;
            }
        }

        public T Get<T>(Int32 index) where T : struct { unsafe { return Unsafe.Read<T>((void*)(Data + Cursor)); } }

        public void Set<T>(Int32 index, T value) where T : struct { unsafe { Unsafe.Write<T>((void*)(Data + Cursor), value); } }

        public Byte this[Int32 index]
        {
            get
            {
                if ((UInt32)index >= (UInt32)Length) { throw new IndexOutOfRangeException(nameof(index)); }
                unsafe { return ((Byte*)Data)[index]; }
            }
            set
            {
                if ((UInt32)index >= (UInt32)Length) { throw new IndexOutOfRangeException(nameof(index)); }
                unsafe { ((Byte*)Data)[index] = value; }
            }
        }

        public const Int32 DefaultLength = 1024;
    }
}