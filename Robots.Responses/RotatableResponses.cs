using System;
using Robots.Surfaces;

namespace Robots.Responses
{
    /// <summary>
    /// Rotatable responses.
    /// </summary>
    public class RotatableResponses
    {
        /// <summary>
        /// verify the valuf of enum variable
        /// </summary>
        /// <param name="value">a integer value of enum </param>
        /// <returns>a valid value of enum</returns>
        private static CompassDirections verifyCompassBoundary(int value)
        {
            int len = Enum.GetValues(typeof(CompassDirections)).Length;
            value = value > len ? 1 : value < 1 ? len : value;
            return (CompassDirections)value;
        }

        /// <summary>
        /// Rotate90s the degrees to left.
        /// </summary>
        /// <returns><c>true</c>, if degrees to left was rotate90ed, <c>false</c> otherwise.</returns>
        /// <param name="position">Position.</param>
        public static bool Rotate90DegreesToLeft(RobotPosition position)
        {
            if (position == null) return false;

            // the direction is sequenced in array, so add 1 to turn left
            position.Direction = verifyCompassBoundary(Convert.ToInt32(position.Direction) + 1);
            return true;
        }

        /// <summary>
        /// Rotate90s the degrees to right.
        /// </summary>
        /// <returns><c>true</c>, if degrees to right was rotate90ed, <c>false</c> otherwise.</returns>
        /// <param name="position">Position.</param>
        public static bool Rotate90DegreesToRight(RobotPosition position)
        {
            if (position == null) return false;

            // the direction is sequenced in array, so less 1 to turn right
            position.Direction = verifyCompassBoundary(Convert.ToInt32(position.Direction) - 1);
            return true;
        }
    }
}