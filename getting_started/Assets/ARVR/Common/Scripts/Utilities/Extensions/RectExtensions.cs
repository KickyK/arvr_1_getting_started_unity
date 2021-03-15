using System;
using UnityEngine;

namespace ARVR.Utilities
{
    public static class RectExtensions
    {
        public static void InflateBy(this ref Rect source, int inflateBy)
        {
            if (inflateBy % 2 == 1)
                throw new ArgumentException("Cannot inflate by odd value!");

            int halfInflateBy = (int)(inflateBy / 2);
            source.x -= halfInflateBy;
            source.x -= halfInflateBy;
            source.width += inflateBy;
            source.height += inflateBy;
        }
    }
}