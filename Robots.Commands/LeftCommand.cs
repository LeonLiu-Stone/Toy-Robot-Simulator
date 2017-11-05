using System;
using Robots.Actions;

namespace Robots.Commands
{
    public class LeftCommand : BaseCommand<IRotatable>, ICommand
    {
        public LeftCommand(IRobot robot) : base(robot) {}

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <value>The command.</value>
        public override RobotCommand Command { get { return RobotCommand.LEFT; } }

        /// <summary>
        /// Execute the specified robot.
        /// </summary>
        /// <returns>The execute.</returns>
        public void Execute()
        {
            ((IRotatable)Robot).RotateToLeft();
        }
    } 
}