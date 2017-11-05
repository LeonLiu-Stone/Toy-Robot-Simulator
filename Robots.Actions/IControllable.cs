using System;
using Robots.Surfaces;

namespace Robots.Actions
{
    /// <summary>
    /// Pivate a mechanism of common robot actions 
    /// </summary>
    public interface IControllable
    {
        /// <summary>
        /// place a robot
        /// </summary>
        /// <param name="position">the current position</param>
        void Place(RobotPosition position);

        /// <summary>
        /// Reports the current position.
        /// </summary>
        /// <returns>The current position.</returns>
        void ReportPosition();
    }
}