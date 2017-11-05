using System;

namespace Robots.Surfaces
{
    /// <summary>
    /// Surface size.
    /// </summary>
    public abstract class SurfaceSize
    {
        /// <summary>
        /// Gets the minimum x.
        /// </summary>
        /// <value>The minimum x.</value>
        public abstract int minX { get; }

        /// <summary>
        /// Gets the max x.
        /// </summary>
        /// <value>The max x.</value>
        public abstract int maxX { get; }

        /// <summary>
        /// Gets the minimum y.
        /// </summary>
        /// <value>The minimum y.</value>
        public abstract int minY { get; }

        /// <summary>
        /// Gets the max y.
        /// </summary>
        /// <value>The max y.</value>
        public abstract int maxY { get; }

        /// <summary>
        /// Ins the boundary.
        /// </summary>
        /// <returns><c>true</c>, if boundary was ined, <c>false</c> otherwise.</returns>
        /// <param name="position">Position.</param>
        public virtual bool InBoundary(RobotPosition position)
        {
            return position.X >= minX && position.X <= maxX
                           && position.Y >= minY && position.Y <= maxY;
        }
    }
}