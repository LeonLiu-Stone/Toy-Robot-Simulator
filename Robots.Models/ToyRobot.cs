using System;
using Robots.Surfaces;

namespace Robots.Models
{
    public class ToyRobot : RobotBase
    {
        /// <summary>
        /// The surface.
        /// </summary>
        private SurfaceSize _surface;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Robots.Models.ToyRobot"/> class.
        /// </summary>
        public ToyRobot(SurfaceSize surface)
        {
            _surface = surface;
        }
    }
}