using System;
using System.IO;
using System.Runtime.InteropServices;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace Dottus.Core
{
    public class Game1 : GameWindow
    {
        GraphicsBuffer Buffer;
        ShaderProgram Program;
        VertexAttributeArray Array;

        public Game1() : base(
            600, 600, new GraphicsMode(32, 0, 0, 4), "", GameWindowFlags.Default,
            DisplayDevice.Default, 4, 2, GraphicsContextFlags.Default)
        {
            GL.Viewport(ClientRectangle);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.Enable(EnableCap.DebugOutput);
            GL.DebugMessageCallback((source, type, id, severity, length, message, userParam) =>
            {
                Console.WriteLine("OpenGL Debugger" +
                    $"\n  Id : {userParam} :: {id}\n" +
                    $"  Source : {source}\n" +
                    $"  Type : {type}\n" +
                    $"  Severity : {severity}\n" +
                    $"  Length : {length}\n" +
                    $"  Message : {Marshal.PtrToStringAnsi(message, length)}\n");
            }, IntPtr.Zero);
            GL.ClearColor(Color.CornflowerBlue);

            Buffer = new GraphicsBuffer(BufferTarget.ArrayBuffer);
            Buffer.Write<Single>(new[] {
                0, 0.5f, 0, 1, 0, 0, 1,
                -0.5f, -0.5f, 0, 0, 1, 0, 1,
                0.5f, -0.5f, 0, 0, 0, 1, 1,
            });

            Program = new ShaderProgram(new[]{
                new Shader(
                    ShaderType.VertexShader,
                    File.ReadAllText(
                        Path.Combine(Environment.CurrentDirectory, "content", "coloredvec3.vert"))
                ),
                new Shader(
                    ShaderType.FragmentShader,
                    File.ReadAllText(
                        Path.Combine(Environment.CurrentDirectory, "content", "coloredvec3.frag"))
                ),
            });

            GL.UseProgram(Program.Id);

            Array = new VertexAttributeArray(Buffer, typeof(ColoredVertex).DescribeVertexAttributes());

            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.CullFace);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.UseProgram(Program.Id);
            GL.BindVertexArray(Array.Id);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            SwapBuffers();
        }
    }
}