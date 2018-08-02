using System;
using System.Drawing;

namespace Dottus.Core
{
    public readonly partial struct Color4 : IEquatable<Color4>
    {
        /* Attributes */
        /* Data */
        public Single R { get; }
        public Single G { get; }
        public Single B { get; }
        public Single A { get; }
        /* Control */
        public Color4 ARGB => new Color4(A, R, G, B);

        /* Constructors */
        public Color4(Single value, Single a = 1.0f) : this(value, value, value, a) { }
        public Color4(Single r, Single g, Single b, Single a = 1.0f)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        /* Instance methods */
        public override Boolean Equals(Object obj) => (obj as Color4?)?.Equals(this) ?? false;
        public override Int32 GetHashCode()
            => R.GetHashCode() ^ G.GetHashCode() ^ B.GetHashCode() ^ A.GetHashCode();
        /* Interface methods */
        public bool Equals(Color4 other) => R == other.R && G == other.G && B == other.B && A == other.A;

        /* Equality operators */
        public static Boolean operator ==(Color4 c1, Color4 c2) => c1.Equals(c2);
        public static Boolean operator !=(Color4 c1, Color4 c2) => !c1.Equals(c2);
        /* Casting operators */
        public static implicit operator Color4(Color color) => new Color4(color.R, color.G, color.B, color.A);
        /* Constants: Built-in colors */
        public static readonly Color4 AliceBlue = Color.AliceBlue;
        public static readonly Color4 AntiqueWhite = Color.AntiqueWhite;
        public static readonly Color4 Aqua = Color.Aqua;
        public static readonly Color4 Aquamarine = Color.Aquamarine;
        public static readonly Color4 Azure = Color.Azure;
        public static readonly Color4 Beige = Color.Beige;
        public static readonly Color4 Bisque = Color.Bisque;
        public static readonly Color4 Black = Color.Black;
        public static readonly Color4 BlanchedAlmond = Color.BlanchedAlmond;
        public static readonly Color4 Blue = Color.Blue;
        public static readonly Color4 BlueViolet = Color.BlueViolet;
        public static readonly Color4 Brown = Color.Brown;
        public static readonly Color4 BurlyWood = Color.BurlyWood;
        public static readonly Color4 CadetBlue = Color.CadetBlue;
        public static readonly Color4 Chartreuse = Color.Chartreuse;
        public static readonly Color4 Chocolate = Color.Chocolate;
        public static readonly Color4 Coral = Color.Coral;
        public static readonly Color4 CornflowerBlue = Color.CornflowerBlue;
        public static readonly Color4 Cornsilk = Color.Cornsilk;
        public static readonly Color4 Crimson = Color.Crimson;
        public static readonly Color4 Cyan = Color.Cyan;
        public static readonly Color4 DarkBlue = Color.DarkBlue;
        public static readonly Color4 DarkCyan = Color.DarkCyan;
        public static readonly Color4 DarkGoldenrod = Color.DarkGoldenrod;
        public static readonly Color4 DarkGray = Color.DarkGray;
        public static readonly Color4 DarkGreen = Color.DarkGreen;
        public static readonly Color4 DarkKhaki = Color.DarkKhaki;
        public static readonly Color4 DarkMagenta = Color.DarkMagenta;
        public static readonly Color4 DarkOliveGreen = Color.DarkOliveGreen;
        public static readonly Color4 DarkOrange = Color.DarkOrange;
        public static readonly Color4 DarkOrchid = Color.DarkOrchid;
        public static readonly Color4 DarkRed = Color.DarkRed;
        public static readonly Color4 DarkSalmon = Color.DarkSalmon;
        public static readonly Color4 DarkSeaGreen = Color.DarkSeaGreen;
        public static readonly Color4 DarkSlateBlue = Color.DarkSlateBlue;
        public static readonly Color4 DarkSlateGray = Color.DarkSlateGray;
        public static readonly Color4 DarkTurquoise = Color.DarkTurquoise;
        public static readonly Color4 DarkViolet = Color.DarkViolet;
        public static readonly Color4 DeepPink = Color.DeepPink;
        public static readonly Color4 DeepSkyBlue = Color.DeepSkyBlue;
        public static readonly Color4 DimGray = Color.DimGray;
        public static readonly Color4 DodgerBlue = Color.DodgerBlue;
        public static readonly Color4 Firebrick = Color.Firebrick;
        public static readonly Color4 FloralWhite = Color.FloralWhite;
        public static readonly Color4 ForestGreen = Color.ForestGreen;
        public static readonly Color4 Fuchsia = Color.Fuchsia;
        public static readonly Color4 Gainsboro = Color.Gainsboro;
        public static readonly Color4 GhostWhite = Color.GhostWhite;
        public static readonly Color4 Gold = Color.Gold;
        public static readonly Color4 Goldenrod = Color.Goldenrod;
        public static readonly Color4 Gray = Color.Gray;
        public static readonly Color4 Green = Color.Green;
        public static readonly Color4 GreenYellow = Color.GreenYellow;
        public static readonly Color4 Honeydew = Color.Honeydew;
        public static readonly Color4 HotPink = Color.HotPink;
        public static readonly Color4 IndianRed = Color.IndianRed;
        public static readonly Color4 Indigo = Color.Indigo;
        public static readonly Color4 Ivory = Color.Ivory;
        public static readonly Color4 Khaki = Color.Khaki;
        public static readonly Color4 Lavender = Color.Lavender;
        public static readonly Color4 LavenderBlush = Color.LavenderBlush;
        public static readonly Color4 LawnGreen = Color.LawnGreen;
        public static readonly Color4 LemonChiffon = Color.LemonChiffon;
        public static readonly Color4 LightBlue = Color.LightBlue;
        public static readonly Color4 LightCoral = Color.LightCoral;
        public static readonly Color4 LightCyan = Color.LightCyan;
        public static readonly Color4 LightGoldenrodYellow = Color.LightGoldenrodYellow;
        public static readonly Color4 LightGray = Color.LightGray;
        public static readonly Color4 LightGreen = Color.LightGreen;
        public static readonly Color4 LightPink = Color.LightPink;
        public static readonly Color4 LightSalmon = Color.LightSalmon;
        public static readonly Color4 LightSeaGreen = Color.LightSeaGreen;
        public static readonly Color4 LightSkyBlue = Color.LightSkyBlue;
        public static readonly Color4 LightSlateGray = Color.LightSlateGray;
        public static readonly Color4 LightSteelBlue = Color.LightSteelBlue;
        public static readonly Color4 LightYellow = Color.LightYellow;
        public static readonly Color4 Lime = Color.Lime;
        public static readonly Color4 LimeGreen = Color.LimeGreen;
        public static readonly Color4 Linen = Color.Linen;
        public static readonly Color4 Magenta = Color.Magenta;
        public static readonly Color4 Maroon = Color.Maroon;
        public static readonly Color4 MediumAquamarine = Color.MediumAquamarine;
        public static readonly Color4 MediumBlue = Color.MediumBlue;
        public static readonly Color4 MediumOrchid = Color.MediumOrchid;
        public static readonly Color4 MediumPurple = Color.MediumPurple;
        public static readonly Color4 MediumSeaGreen = Color.MediumSeaGreen;
        public static readonly Color4 MediumSlateBlue = Color.MediumSlateBlue;
        public static readonly Color4 MediumSpringGreen = Color.MediumSpringGreen;
        public static readonly Color4 MediumTurquoise = Color.MediumTurquoise;
        public static readonly Color4 MediumVioletRed = Color.MediumVioletRed;
        public static readonly Color4 MidnightBlue = Color.MidnightBlue;
        public static readonly Color4 MintCream = Color.MintCream;
        public static readonly Color4 MistyRose = Color.MistyRose;
        public static readonly Color4 Moccasin = Color.Moccasin;
        public static readonly Color4 NavajoWhite = Color.NavajoWhite;
        public static readonly Color4 Navy = Color.Navy;
        public static readonly Color4 OldLace = Color.OldLace;
        public static readonly Color4 Olive = Color.Olive;
        public static readonly Color4 OliveDrab = Color.OliveDrab;
        public static readonly Color4 Orange = Color.Orange;
        public static readonly Color4 OrangeRed = Color.OrangeRed;
        public static readonly Color4 Orchid = Color.Orchid;
        public static readonly Color4 PaleGoldenrod = Color.PaleGoldenrod;
        public static readonly Color4 PaleGreen = Color.PaleGreen;
        public static readonly Color4 PaleTurquoise = Color.PaleTurquoise;
        public static readonly Color4 PaleVioletRed = Color.PaleVioletRed;
        public static readonly Color4 PapayaWhip = Color.PapayaWhip;
        public static readonly Color4 PeachPuff = Color.PeachPuff;
        public static readonly Color4 Peru = Color.Peru;
        public static readonly Color4 Pink = Color.Pink;
        public static readonly Color4 Plum = Color.Plum;
        public static readonly Color4 PowderBlue = Color.PowderBlue;
        public static readonly Color4 Purple = Color.Purple;
        public static readonly Color4 Red = Color.Red;
        public static readonly Color4 RosyBrown = Color.RosyBrown;
        public static readonly Color4 RoyalBlue = Color.RoyalBlue;
        public static readonly Color4 SaddleBrown = Color.SaddleBrown;
        public static readonly Color4 Salmon = Color.Salmon;
        public static readonly Color4 SandyBrown = Color.SandyBrown;
        public static readonly Color4 SeaGreen = Color.SeaGreen;
        public static readonly Color4 SeaShell = Color.SeaShell;
        public static readonly Color4 Sienna = Color.Sienna;
        public static readonly Color4 Silver = Color.Silver;
        public static readonly Color4 SkyBlue = Color.SkyBlue;
        public static readonly Color4 SlateBlue = Color.SlateBlue;
        public static readonly Color4 SlateGray = Color.SlateGray;
        public static readonly Color4 Snow = Color.Snow;
        public static readonly Color4 SpringGreen = Color.SpringGreen;
        public static readonly Color4 SteelBlue = Color.SteelBlue;
        public static readonly Color4 Tan = Color.Tan;
        public static readonly Color4 Teal = Color.Teal;
        public static readonly Color4 Thistle = Color.Thistle;
        public static readonly Color4 Tomato = Color.Tomato;
        public static readonly Color4 Transparent = Color.Transparent;
        public static readonly Color4 Turquoise = Color.Turquoise;
        public static readonly Color4 Violet = Color.Violet;
        public static readonly Color4 Wheat = Color.Wheat;
        public static readonly Color4 White = Color.White;
        public static readonly Color4 WhiteSmoke = Color.WhiteSmoke;
        public static readonly Color4 Yellow = Color.Yellow;
        public static readonly Color4 YellowGreen = Color.YellowGreen;
    }
}