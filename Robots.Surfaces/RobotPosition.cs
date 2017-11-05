using System;

namespace Robots.Surfaces
{
    /// <summary>
    /// Declaure common properties for Position classes
    /// </summary>
    public class RobotPosition
    {
        /// <summary>
        /// coordinates X : from west to east
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// coordinates Y : from south to north
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Compass Points
        /// </summary>
        public CompassDirections Direction { get; set; }
    }
}