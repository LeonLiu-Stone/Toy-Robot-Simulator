using System;
using Frameworks.Exceptions;
using Robots.Actions;
using Robots.Surfaces;

namespace Robots.Commands
{
    public class PlaceCommand : BaseCommand<IControllable>, ICommand
    {
        /// <summary>
        /// The position.
        /// </summary>
        private RobotPosition _position;

        public PlaceCommand(IRobot robot, string parameters, IExceptionFactory exceptionFactory) : base(robot) 
        {
            var parameterArray = parameters.Trim().Split(' ');
            try
            {
                _position = new RobotPosition();
                _position.X = int.Parse(parameterArray[0]);
                _position.Y = int.Parse(parameterArray[1]);
                _position.Direction = (CompassDirections)Enum.Parse(typeof(CompassDirections), parameterArray[2].ToUpper());
            }
            catch
            {
                exceptionFactory.GenerateSafeException($"invalid parameters [{parameters}] for the {Command.ToString()} command");
            }
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <value>The command.</value>
        public override RobotCommand Command { get { return RobotCommand.PLACE; } }

        /// <summary>
        /// Execute the specified robot.
        /// </summary>
        /// <returns>The execute.</returns>
        public void Execute()
        {
            ((IControllable)Robot).Place(_position);
        }
    } 
}