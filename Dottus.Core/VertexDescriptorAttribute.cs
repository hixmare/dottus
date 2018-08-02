using System;
using System.Linq;
using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL4;

using Boolean = System.Boolean;

namespace Dottus.Core
{
    public class VertexDescriptorAttribute : Attribute
    {
        public Int32 Stride { get; }
        public Int32[] Offsets { get; }

        public VertexDescriptorAttribute(Type stride, params Type[] offsets)
        {
            Stride = Marshal.SizeOf(stride);
            Offsets = offsets.Length == 0 ? null : (from offset in offsets select Marshal.SizeOf(offset)).ToArray();
        }

        public VertexAttribute ToVertexAttribute(
            Int32 index = 0,
            Int32 offset = 0,
            VertexAttribPointerType type = VertexAttribPointerType.Float,
            Boolean isNormalized = false) => ToVertexAttribute(index, Stride, offset, type, isNormalized);

        public VertexAttribute ToVertexAttribute(
            Int32 index,
            Int32 segmentSize,
            Int32 offset = 0,
            VertexAttribPointerType type = VertexAttribPointerType.Float,
            Boolean isNormalized = false)
        {
            return new VertexAttribute(
                index,
                Stride,
                segmentSize / GetTypeSize(type),
                offset,
                type,
                isNormalized
            );
        }

        public VertexAttribute[] ToVertexAttributes(
            VertexAttribPointerType type = VertexAttribPointerType.Float,
            Boolean isNormalized = false)
        {
            VertexAttribute[] array;
            if (Offsets == null)
            {
                array = new VertexAttribute[1];
                array[0] = ToVertexAttribute(0, 0, type, isNormalized);
            }
            else
            {
                array = new VertexAttribute[Offsets.Length];

                for (int i = 0, offset = 0; i < array.Length; i++)
                {
                    array[i] = ToVertexAttribute(i, Offsets[i], offset, type, isNormalized);
                    offset += Offsets[i];
                }
            }
            return array;
        }

        private static Int32 GetTypeSize(VertexAttribPointerType type)
        {
            switch (type)
            {
                case VertexAttribPointerType.Float: return sizeof(Single);
                case VertexAttribPointerType.Double: return sizeof(Double);

                case VertexAttribPointerType.UnsignedByte:
                case VertexAttribPointerType.Byte: return sizeof(SByte);
                case VertexAttribPointerType.UnsignedShort:
                case VertexAttribPointerType.Short: return sizeof(Int16);
                case VertexAttribPointerType.UnsignedInt:
                case VertexAttribPointerType.Int: return sizeof(Int32);

                default: return -1;
            }
        }
    }
}