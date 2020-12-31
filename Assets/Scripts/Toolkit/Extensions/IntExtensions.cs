using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Rhodos.Toolkit.Extensions
{
    public static class IntExtensions
    {
        /// <summary>
        /// A shortcut for Mathf.Abs
        /// </summary>
        public static int Abs(this int number)
        {
            return Mathf.Abs(number);
        }

        public static bool GetProbability(this int number, int over)
        {
            int random = Random.Range(1, over + 1);
            return random.InRangeInclusive(1, number);
        }

        public static bool GetProbabilityOverAHunred(this int number)
        {
            return GetProbability(number, 100);
        }
        public static bool InRangeInclusive<T>(this T value, T closedLeft, T closedRight)
            where T : IComparable =>
            value.CompareTo(closedLeft) >= 0 && value.CompareTo(closedRight) <= 0;
    }
}