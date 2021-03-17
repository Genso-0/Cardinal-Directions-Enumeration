using System;
using UnityEngine;

    [Flags]
    public enum Directions : byte
    {
        None = 0,
        North = 1 << 0,
        East = 1 << 1,
        South = 1 << 2,
        West = 1 << 3,

        NorthEast = North | East,
        SouthEast = East | South,
        SouthWest = South | West,
        NorthWest = West | North
    }
    public static class DirectionsHelper
    {
        public static Directions GetDirection(Vector3 from, Vector3 to)
        {
            Vector3 direction = (to - from).normalized;
            float dot = Vector3.Dot(direction, Vector3.up);
            Directions result = Directions.None;
            if (dot > 0)
                result.Add(Directions.North);
            else if (dot < 0)
                result.Add(Directions.South);

            dot = Vector3.Dot(direction, Vector3.right);
            if (dot > 0)
                result.Add(Directions.East);
            else if (dot < 0)
                result.Add(Directions.West);

            return result;
        }
        public static void Add(ref this Directions dir, Directions other)
        {
            dir |= other;
        }
        public static void Remove(ref this Directions dir, Directions other)
        {
            dir &= ~other;
        }
        public static bool IsEqual(this Directions dir, Directions other)
        {
            return (dir & other) == other;
        }
        /// <summary>
        /// Finds the overlap between two combinations
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static Directions FindCommon(this Directions dir, Directions other)
        {
            return dir & other;
        }
        /// <summary>
        /// Checks if an enumeration is part of a combination
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool Contains(this Directions dir, Directions other)
        {
            return (dir & other) != 0;
        }
    }
