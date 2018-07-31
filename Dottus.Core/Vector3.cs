using System;

namespace Dottus.Core
{
    [VertexDescriptor(typeof(Vector3))]
    public readonly struct Vector3 : IEquatable<Vector3>
    {
        /* Properties */
        /* Data */
        public Single X { get; }
        public Single Y { get; }
        public Single Z { get; }
        /* Control */
        public Vector2 XY => new Vector2(X, Y);
        public Vector2 XZ => new Vector2(X, Z);
        public Vector2 YZ => new Vector2(Y, Z);
        public Vector3 ZYX => new Vector3(Z, Y, X);
        public Single Length => (Single)System.Math.Sqrt(X * X + Y * Y + Z * Z);
        public Single LengthSquared => X * X + Y * Y + Z * Z;

        /* Constructors */
        public Vector3(Single value) { X = Y = Z = value; }
        public Vector3(Single x, Single y, Single z = 0) { X = x; Y = y; Z = z; }
        public Vector3(Vector2 vector, Single z = 0) { X = vector.X; Y = vector.Y; Z = z; }

        /* Instance methods */
        public Vector3 Clamp(Vector3 min, Vector3 max) => Clamp(this, min, max);
        public Single Dot(Vector3 other) => Dot(this, other);
        public Vector3 Normalize() => Normalize(this);
        /* Interface methods */
        public Boolean Equals(Vector3 other) => X == other.X && Y == other.Y && Z == other.Z;
        /* Overridden methods */
        public override Boolean Equals(Object obj) => (obj as Vector3?)?.Equals(this) ?? false;
        public override Int32 GetHashCode() => X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        public override String ToString() => $"{X}, {Y}, {Z}";

        /* Constants */
        public static readonly Vector3 Zero = new Vector3(0);
        public static readonly Vector3 One = new Vector3(1);
        public static readonly Vector3 UnitX = new Vector3(1, 0, 0);
        public static readonly Vector3 UnitY = new Vector3(0, 1, 0);
        public static readonly Vector3 UnitZ = new Vector3(0, 0, 1);
        /* Static Methods */
        public static Vector3 Clamp(Vector3 vector, Vector3 min, Vector3 max) => new Vector3(Math.Clamp(vector.X, min.X, max.X), Math.Clamp(vector.Y, min.Y, max.Y), Math.Clamp(vector.Z, min.Z, max.Z));
        public static Single Dot(Vector3 v1, Vector3 v2) => v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        public static Vector3 Normalize(Vector3 vector) => vector * (1f / vector.Length);
        /* Equality operators */
        public static Boolean operator ==(Vector3 v1, Vector3 v2) => v1.Equals(v2);
        public static Boolean operator !=(Vector3 v1, Vector3 v2) => !v1.Equals(v2);
        /* Binary operators */
        public static Vector3 operator +(Vector3 v1, Vector3 v2)
            => new Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        public static Vector3 operator -(Vector3 v1, Vector3 v2)
            => new Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        public static Vector3 operator *(Vector3 v1, Vector3 v2)
            => new Vector3(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z);
        public static Vector3 operator /(Vector3 v1, Vector3 v2)
            => new Vector3(v1.X / v2.X, v1.Y / v2.Y, v1.Z / v2.Z);
        public static Vector3 operator +(Vector3 v1, Single value)
            => new Vector3(v1.X + value, v1.Y + value, v1.Z + value);
        public static Vector3 operator -(Vector3 v1, Single value)
            => new Vector3(v1.X - value, v1.Y - value, v1.Z - value);
        public static Vector3 operator *(Vector3 v1, Single value)
            => new Vector3(v1.X * value, v1.Y * value, v1.Z * value);
        public static Vector3 operator /(Vector3 v1, Single value)
            => new Vector3(v1.X / value, v1.Y / value, v1.Z / value);
        /* Unary operators */
        public static Vector3 operator -(Vector3 vector) => new Vector3(-vector.X, -vector.Y, -vector.Z);
    }
}