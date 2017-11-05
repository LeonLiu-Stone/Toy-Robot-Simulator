using System;
using Robots.Actions;

namespace Robots.Commands
{
    public class MoveCommand : BaseCommand<IMovable>, ICommand
    {
        public MoveCommand(IRobot robot) : base(robot) {}

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <value>The command.</value>
        public override RobotCommand Command { get { return RobotCommand.MOVE; } }

        /// <summary>
        /// Execute the specified robot.
        /// </summary>
        /// <returns>The execute.</returns>
        public void Execute()
        {
            ((IMovable)Robot).MoveForward();
        }
    } 
}