using System;
using OpenTK.Graphics.OpenGL4;

using Boolean = System.Boolean;

namespace Dottus.Core
{
    public readonly struct VertexAttribute
    {
        public Int32 Index { get; }
        public Int32 Stride { get; }
        public Int32 TypeCount { get; }
        public Int32 ByteOffset { get; }
        public Boolean IsNormalized { get; }
        public VertexAttribPointerType Type { get; }

        public VertexAttribute(
            Int32 index = 0,
            Int32 stride = 0,
            Int32 typeCount = 0,
            Int32 byteOffset = 0,
            VertexAttribPointerType type = VertexAttribPointerType.Float,
            Boolean isNormalized = false)
        {
            Index = index;
            Stride = stride;
            TypeCount = typeCount;
            ByteOffset = byteOffset;
            Type = type;
            IsNormalized = isNormalized;
        }
    }
}