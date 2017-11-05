using System;
using Robots.Actions;

namespace Robots.Commands
{
    public abstract class BaseCommand<T>
    {
        public BaseCommand(IRobot robot)
        {
            Robot = (T)robot;
        }

        /// <summary>
        /// Gets the robot.
        /// </summary>
        /// <value>The robot.</value>
        public T Robot { get; }

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <value>The command.</value>
        public abstract RobotCommand Command { get; }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        public virtual string Params { get; }

        /// <summary>
        /// Gets the excute result.
        /// </summary>
        /// <value>The excute result.</value>
        public virtual object ExcuteResult { get; }
    }
}