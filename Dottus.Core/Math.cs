using System;

namespace Dottus.Core
{
    public static class Math
    {
        public static Single Clamp(Single value, Single min = 0, Single max = 1) => value < min ? min : value > max ? max : value;
        public static Double Clamp(Double value, Double min = 0, Double max = 1) => value < min ? min : value > max ? max : value;
    }
}