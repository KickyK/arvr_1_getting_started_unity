using System;
using System.Collections.Generic;
using System.Linq;

namespace ARVR.Utilities
{
    public static class ListExtensions
    {
        /// <summary>
        /// Shuffles a list contents
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <see cref="https://exceptionnotfound.net/understanding-the-fisher-yates-card-shuffling-algorithm/"/>
        public static void Shuffle<T>(this List<T> list)
        {
            if (list == null)
                throw new ArgumentException("Cannot shuffle invalid list!");

            if (list.Count == 0)
                return;

            T temp = default(T);
            var rnd = new System.Random();
            var randIndex = 0;

            for (var index = list.Count - 1; index > 0; --index)
            {
                randIndex = rnd.Next(index + 1);
                temp = list[index];
                list[index] = list[randIndex];
                list[randIndex] = temp;
            }
        }
    }
}