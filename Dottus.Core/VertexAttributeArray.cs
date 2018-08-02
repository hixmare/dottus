using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;

namespace Dottus.Core
{
    public class VertexAttributeArray
    {
        protected internal Int32 Id { get; protected set; }

        private IEnumerable<VertexAttribute> _Attributes;
        public IEnumerable<VertexAttribute> Attributes
        {
            get => _Attributes;
            set
            {
                _Attributes = value;
                if (value != null) { EnableAttributes(); }
            }
        }

        private GraphicsBuffer _Buffer;
        public GraphicsBuffer Buffer
        {
            get => _Buffer;
            set
            {
                _Buffer = value;
                if (value == null) { return; }
                GL.BindBuffer(_Buffer.Target, _Buffer.Id);
                EnableAttributes();
            }
        }

        public VertexAttributeArray(GraphicsBuffer buffer = null, IEnumerable<VertexAttribute> items = null)
        {
            GL.BindBuffer(buffer.Target, buffer.Id);
            Id = GL.GenVertexArray();
            _Buffer = buffer;
            _Attributes = items;

            if (buffer != null && items != null) { EnableAttributes(); }
        }

        ~VertexAttributeArray() => GL.DeleteVertexArray(Id);

        public void EnableAttributes()
        {
            if (Attributes == null) { throw new InvalidOperationException($"{nameof(Attributes)} is null"); }
            if (Buffer == null) { throw new InvalidOperationException($"{nameof(Buffer)} is null"); }

            GL.BindVertexArray(Id);

            foreach (var at in Attributes)
            {
                GL.VertexAttribPointer(at.Index, at.TypeCount, at.Type, at.IsNormalized, at.Stride, at.ByteOffset);
                GL.EnableVertexAttribArray(at.Index);
            }
        }
    }
}