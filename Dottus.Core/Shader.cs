using System;
using OpenTK.Graphics.OpenGL4;

namespace Dottus.Core
{
    public class Shader
    {
        internal Int32 Id { get; }

        public String Source { get; }
        public ShaderType Type { get; }

        public Shader(ShaderType type, String source)
        {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }
            Id = GL.CreateShader(type);

            Type = type;
            Source = source;

            Compile();
        }

        ~Shader() => GL.DeleteShader(Id);

        public void Compile()
        {
            GL.ShaderSource(Id, Source);
            GL.CompileShader(Id);
        }
    }
}