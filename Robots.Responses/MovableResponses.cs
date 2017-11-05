using System;
using Robots.Surfaces;

namespace Robots.Responses
{
    /// <summary>
    /// Movable responses.
    /// </summary>
    public class MovableResponses
    {
        /// <summary>
        /// Moves the forward one step.
        /// </summary>
        /// <returns><c>true</c>, if forward one step was moved, <c>false</c> otherwise.</returns>
        /// <param name="position">Position.</param>
        /// <param name="surface">Surface.</param>
        public static bool MoveForwardOneStep(RobotPosition position, Surface surface)
        {
            if (position == null) return false;

            var newPosition = new RobotPosition{ X = position.X, Y = position.Y, Direction = position.Direction};

            var step = 1;
            switch (newPosition.Direction)
            {
                case CompassDirections.NORTH:
                    newPosition.Y += step;
                    break;
                case CompassDirections.SOUTH:
                    newPosition.Y -= step;
                    break;
                case CompassDirections.WEST:
                    newPosition.X -= step;
                    break;
                case CompassDirections.EAST:
                    newPosition.X += step;
                    break;
            }

            var valid = surface.InBoundary(newPosition);
            if(valid)
            {
                position.X = newPosition.X;
                position.Y = newPosition.Y;
            }
            return valid;
        }
    }
}
