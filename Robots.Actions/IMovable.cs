using System;

namespace Robots.Actions
{
    /// <summary>
    /// Private a mechanism of moving
    /// </summary>
    public interface IMovable
    {
        /// <summary>
        /// Move the robot forward from the current postion
        /// </summary>
        void MoveForward();
    }
}