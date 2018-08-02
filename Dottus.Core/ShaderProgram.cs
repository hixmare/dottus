using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK.Graphics.OpenGL4;

namespace Dottus.Core
{
    public class ShaderProgram
    {
        internal Int32 Id { get; }

        public IEnumerable<Shader> Shaders { get; }

        public ShaderProgram(IEnumerable<Shader> shaders)
        {
            if (shaders == null || shaders.Count() == 0) { throw new ArgumentException(nameof(shaders)); }

            Id = GL.CreateProgram();
            foreach (var sh in shaders) { GL.AttachShader(Id, sh.Id); }
            GL.LinkProgram(Id);

            Shaders = shaders;
        }
    }
}