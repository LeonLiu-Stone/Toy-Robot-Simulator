using System;
using Robots.Actions;

namespace Robots.Commands
{
    public class RightCommand : BaseCommand<IRotatable>, ICommand
    {
        public RightCommand(IRobot robot) : base(robot) {}

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <value>The command.</value>
        public override RobotCommand Command { get { return RobotCommand.RIGHT; } }

        /// <summary>
        /// Execute the specified robot.
        /// </summary>
        /// <returns>The execute.</returns>
        public void Execute()
        {
            ((IRotatable)Robot).RotateToRight();
        }
    } 
}