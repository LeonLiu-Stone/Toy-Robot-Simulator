using System;
using Robots.Actions;

namespace Robots.Commands
{
    public class ReportCommand : BaseCommand<IControllable>, ICommand
    {
        public ReportCommand(IRobot robot) : base(robot) {}

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <value>The command.</value>
        public override RobotCommand Command { get { return RobotCommand.REPORT; } }

        /// <summary>
        /// Execute the specified robot.
        /// </summary>
        /// <returns>The execute.</returns>
        public void Execute()
        {
            ((IControllable)Robot).ReportPosition();
        }
    } 
}