using System;
using Frameworks.Exceptions;
using Robots.Actions;
using Robots.Surfaces;

namespace Robots.Models
{
    public class ToyRobot : RobotBase, IMovable
    {
        /// <summary>
        /// The surface.
        /// </summary>
        private SurfaceSize _surface;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Robots.Models.ToyRobot"/> class.
        /// </summary>
        public ToyRobot(SurfaceSize surface, IExceptionFactory exceptionFactory) : base(exceptionFactory)
        {
            _surface = surface;
        }

        public void MoveForward()
        {
            throw new NotImplementedException();
        }
    }
}