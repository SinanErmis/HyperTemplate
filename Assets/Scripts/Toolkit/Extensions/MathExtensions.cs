using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Rhodos.Toolkit.Extensions
{
    public static class MathExtensions
    {
        public static int Abs(this int number)
        {
            return Mathf.Abs(number);
        }
        public static float Abs(this float f)
        {
            return (f < 0) ? -f : f;
        }
        public static bool GetProbability(this int number, int over)
        {
            int random = Random.Range(1, over + 1);
            return random.InRangeInclusive(1, number);
        }

        public static bool GetProbabilityOver100(this int number)
        {
            return GetProbability(number, 100);
        }
        public static bool InRangeInclusive<T>(this T value, T closedLeft, T closedRight)
            where T : IComparable =>
            value.CompareTo(closedLeft) >= 0 && value.CompareTo(closedRight) <= 0;
        
        public static Matrix4x4 MatrixLerp(this Matrix4x4 from, Matrix4x4 to, float time)
        {
            Matrix4x4 ret = new Matrix4x4();
            for (int i = 0; i < 16; i++)
                ret[i] = Mathf.Lerp(from[i], to[i], time);
            return ret;
        }
    }
}