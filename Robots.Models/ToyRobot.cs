using System;
using Frameworks.Exceptions;
using Robots.Actions;
using Robots.Common;
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
            if (this.Status != RobotStatus.On)
                _exceptionFactory.GenerateSafeException($"please place this robot first");
            
            if(!MovableResponses.MoveForwardOneStep(this.Position, _surface))
                _exceptionFactory.GenerateSafeException($"the robot cannot move to expected postion");
        }

        public void Place(RobotPosition position)
        {
            this.Position = ControllableResponses.PlaceRobotToFlatSurface(position, _surface);
            if (this.Position == null)
                _exceptionFactory.GenerateSafeException($"the robot cannot place to expected postion");

            this.Status = RobotStatus.On;
        }

        public void ReportPosition()
        {
            if (this.Status != RobotStatus.On)
                _exceptionFactory.GenerateSafeException($"please place this robot first");
            
            OnProgressChangedEvent();
        }

        public void RotateToLeft()
        {
            if(this.Status != RobotStatus.On)
                _exceptionFactory.GenerateSafeException($"please place this robot first");
            
            if (!RotatableResponses.Rotate90DegreesToLeft(this.Position))
                _exceptionFactory.GenerateSafeException($"the robot cannot rotate 90 degrees to left");
        }

        public void RotateToRight()
        {
            if (this.Status != RobotStatus.On)
                _exceptionFactory.GenerateSafeException($"please place this robot first");
            
            if (!RotatableResponses.Rotate90DegreesToRight(this.Position))
                _exceptionFactory.GenerateSafeException($"the robot cannot rotate 90 degrees to right");
        }
    }
}