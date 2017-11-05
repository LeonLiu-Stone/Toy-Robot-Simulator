using System;

namespace Robots.Actions
{
    /// <summary>
    /// Pivate a mechanism of rotating 
    /// </summary>
    public interface IRotatable
    {
        /// <summary>
        /// turn left
        /// </summary>
        void RotateToLeft();

        /// <summary>
        /// turn right
        /// </summary>
        void RotateToRight();
    }
}