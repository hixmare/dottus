using System;

namespace Dottus.Core
{
    [VertexDescriptor(typeof(ColoredVertex), typeof(Vector3), typeof(Color4))]
    public readonly struct ColoredVertex : IEquatable<ColoredVertex>
    {
        /* Properties */
        /* Data */
        public Vector3 Position { get; }
        public Color4 Color { get; }
        /* Control */
        public Single X => Position.X;
        public Single Y => Position.Y;
        public Single Z => Position.Z;
        public Single R => Color.R;
        public Single G => Color.G;
        public Single B => Color.B;
        public Single A => Color.A;

        /* Constructors */
        public ColoredVertex(Single x, Single y) : this(x, y, 0) { }
        public ColoredVertex(Single x, Single y, Single z) : this(x, y, z, 0, 0, 0, 255) { }
        public ColoredVertex(Single x, Single y, Single z, Color4 color) : this(new Vector3(x, y, z), color) { }
        public ColoredVertex(Single x, Single y, Single z, Byte r, Byte g, Byte b, Byte a) : this(new Vector3(x, y, z), new Color4(r, g, b, a)) { }
        public ColoredVertex(Vector3 position, Color4 color)
        {
            Position = position;
            Color = color;
        }

        /* Overridden methods */
        public override Boolean Equals(Object obj) => (obj as ColoredVertex?)?.Equals(this) ?? false;
        public override Int32 GetHashCode() => Position.GetHashCode() ^ Color.GetHashCode();
        /* Interface methods */
        public Boolean Equals(ColoredVertex other) => Position == other.Position && Color == other.Color;
    }
}