using System;
using Frameworks.Exceptions;
using Robots.Actions;
using Robots.Responses;
using Robots.Surfaces;

namespace Robots.Models
{
    public class ToyRobot : RobotBase, IControllable, IMovable, IRotatable
    {
        /// <summary>
        /// The exception factory.
        /// </summary>
        private IExceptionFactory _exceptionFactory;

        /// <summary>
        /// The surface.
        /// </summary>
        private Surface _surface;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Robots.Models.ToyRobot"/> class.
        /// </summary>
        public ToyRobot(Surface surface, IExceptionFactory exceptionFactory) : base(exceptionFactory)
        {
            _exceptionFactory = exceptionFactory;
            _surface = surface;
        }

        public void MoveForward()
        {
            if(!MovableResponses.MoveForwardOneStep(this.Position, _surface))
                _exceptionFactory.GenerateSafeException($"the robot cannot move to expected postion");
        }

        public void Place(RobotPosition position)
        {
            if (!ControllableResponses.PlaceRobotToFlatSurface(this.Position, _surface))
                _exceptionFactory.GenerateSafeException($"the robot cannot place to expected postion");
        }

        public void ReportPosition()
        {
            OnProgressChangedEvent();
        }

        public void RotateToLeft()
        {
            if (!RotatableResponses.Rotate90DegreesToLeft(this.Position))
                _exceptionFactory.GenerateSafeException($"the robot cannot rotate 90 degrees to left");
        }

        public void RotateToRight()
        {
            if (!RotatableResponses.Rotate90DegreesToRight(this.Position))
                _exceptionFactory.GenerateSafeException($"the robot cannot rotate 90 degrees to right");
        }
    }
}