using System;
using System.IO;
using System.Runtime.InteropServices;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace Dottus.Core
{
    public class Game2 : GameWindow
    {
        Int32 vbo, vao, program;

        public Game2() : base(
            600, 600, new GraphicsMode(32, 0, 0, 4), "", GameWindowFlags.Default,
            DisplayDevice.Default, 4, 2, GraphicsContextFlags.Debug)
        {
            GL.Viewport(ClientRectangle);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.CornflowerBlue);

            vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);

            var buffer = new[] {
                0, 0.5f, 0,         1, 0, 0, 1,
                -0.5f, -0.5f, 0,    0, 1, 0, 1,
                0.5f, -0.5f, 0,     0, 0, 1, 1,
            };
            GL.BufferStorage(
                BufferTarget.ArrayBuffer,
                buffer.Length * 4,
                buffer,
                BufferStorageFlags.DynamicStorageBit | BufferStorageFlags.MapReadBit | BufferStorageFlags.MapWriteBit);

            var vert = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vert, File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "content", "coloredvec3.vert")));
            GL.CompileShader(vert);

            var frag = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(frag, File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "content", "coloredvec3.frag")));
            GL.CompileShader(frag);

            program = GL.CreateProgram();
            GL.AttachShader(program, vert);
            GL.AttachShader(program, frag);
            GL.LinkProgram(program);

            vao = GL.GenVertexArray();
            GL.BindVertexArray(vao);

            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 7 * 4, 0);

            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 4, VertexAttribPointerType.Float, false, 7 * 4, 3 * 4);

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.CullFace);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.BindVertexArray(vao);
            GL.UseProgram(program);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            SwapBuffers();
            base.OnRenderFrame(e);
        }
    }
}