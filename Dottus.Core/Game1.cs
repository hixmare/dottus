using System;
using System.Runtime.InteropServices;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace Dottus.Core
{
    public class Game1 : GameWindow
    {
        public Game1() : base(
            600, 600, new GraphicsMode(32, 0, 0, 4), "", GameWindowFlags.Default,
            DisplayDevice.Default, 4, 2, GraphicsContextFlags.Default)
        { }

        protected override void OnLoad(EventArgs e)
        {
            GL.Enable(EnableCap.DebugOutput);
            GL.DebugMessageCallback((source, type, id, severity, length, message, userParam) =>
            {
                Console.WriteLine("OpenGL Debugger",
                    $"\n  Id : {userParam} :: {id}\n" +
                    $"  Source : {source}\n" +
                    $"  Type : {type}\n" +
                    $"  Severity : {severity}\n" +
                    $"  Length : {length}\n" +
                    $"  Message : {Marshal.PtrToStringAnsi(message, length)}\n");
            }, IntPtr.Zero);
            GL.ClearColor(Color.CornflowerBlue);

            var buffer = new GraphicsBuffer(BufferTarget.ArrayBuffer);
            buffer.Write(new ColoredVertex(0, 1, 2, Color4.Blue));
            unsafe
            {
                var transpose = new Span<Single>((void*)buffer.Data, buffer.Length);
            }
            var attribs = typeof(ColoredVertex).DescribeVertexAttributes();
            ;
        }
    }
}