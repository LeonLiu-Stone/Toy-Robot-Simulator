using System;
using Robots.Surfaces;

namespace Robots.Responses
{
    /// <summary>
    /// Controllable responses.
    /// </summary>
    public class ControllableResponses
    {
        /// <summary>
        /// Places the robot to flat surface.
        /// </summary>
        /// <returns><c>true</c>, if robot to flat surface was placed, <c>false</c> otherwise.</returns>
        /// <param name="expectedPosition">Expected position.</param>
        /// <param name="surface">Surface.</param>
        public static RobotPosition PlaceRobotToFlatSurface(RobotPosition expectedPosition, Surface surface)
        {
            if (expectedPosition == null) return null;

            return surface.InBoundary(expectedPosition) ? expectedPosition : null;
        }
    }
}