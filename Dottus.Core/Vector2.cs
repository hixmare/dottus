using System;

namespace Dottus.Core
{
    [VertexDescriptor(typeof(Vector2))]
    public readonly struct Vector2 : IEquatable<Vector2>
    {
        /* Properties */
        /* Data */
        public Single X { get; }
        public Single Y { get; }
        /* Control */
        public Vector2 YX => new Vector2(Y, X);
        public Single Length => (Single)System.Math.Sqrt(X * X + Y * Y);
        public Single LengthSquared => X * X + Y * Y;

        /* Constructors */
        public Vector2(Single value) { X = Y = value; }
        public Vector2(Single x, Single y) { X = x; Y = y; }

        /* Instance methods */
        public Vector2 Clamp(Vector2 min, Vector2 max) => Clamp(this, min, max);
        public Single Dot(Vector2 other) => Dot(this, other);
        public Vector2 Normalize() => Normalize(this);
        /* Interface methods */
        public Boolean Equals(Vector2 other) => X == other.X && Y == other.Y;
        /* Overridden methods */
        public override Boolean Equals(Object obj) => (obj as Vector2?)?.Equals(this) ?? false;
        public override Int32 GetHashCode() => X.GetHashCode() ^ Y.GetHashCode();
        public override String ToString() => $"{X}, {Y}";

        /* Constants */
        public static readonly Vector2 Zero = new Vector2(0);
        public static readonly Vector2 One = new Vector2(1);
        public static readonly Vector2 UnitX = new Vector2(1, 0);
        public static readonly Vector2 UnitY = new Vector2(0, 1);
        /* Static methods */
        public static Vector2 Clamp(Vector2 vector, Vector2 min, Vector2 max) => new Vector2(Dottus.Core.Math.Clamp(vector.X, min.X, max.X), Dottus.Core.Math.Clamp(vector.Y, min.Y, max.Y));
        public static Single Dot(Vector2 v1, Vector2 v2) => v1.X * v2.X + v1.Y * v2.Y;
        public static Vector2 Normalize(Vector2 vector) => vector * (1f / vector.Length);
        /* Equality operators */
        public static Boolean operator ==(Vector2 v1, Vector2 v2) => v1.Equals(v2);
        public static Boolean operator !=(Vector2 v1, Vector2 v2) => !v1.Equals(v2);
        /* Binary operators */
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
            => new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
            => new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        public static Vector2 operator *(Vector2 v1, Vector2 v2)
            => new Vector2(v1.X * v2.X, v1.Y * v2.Y);
        public static Vector2 operator /(Vector2 v1, Vector2 v2)
            => new Vector2(v1.X / v2.X, v1.Y / v2.Y);
        public static Vector2 operator +(Vector2 v1, Single value)
            => new Vector2(v1.X + value, v1.Y + value);
        public static Vector2 operator -(Vector2 v1, Single value)
            => new Vector2(v1.X - value, v1.Y - value);
        public static Vector2 operator *(Vector2 v1, Single value)
            => new Vector2(v1.X * value, v1.Y * value);
        public static Vector2 operator /(Vector2 v1, Single value)
            => new Vector2(v1.X / value, v1.Y / value);
        /* Unary operators */
        public static Vector2 operator -(Vector2 vector)
            => new Vector2(-vector.X, -vector.Y);
    }
}