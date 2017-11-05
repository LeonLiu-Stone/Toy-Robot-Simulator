using System;
using Frameworks.Exceptions;
using Robots.Actions;
using Robots.Commands;
using Robots.Common;
using Robots.Surfaces;

namespace Robots.Models
{
    /// <summary>
    /// Declare common robot properties
    /// </summary>
    public class RobotBase : IRobot
    {
        private IExceptionFactory _exceptionFactory;

        public RobotBase(IExceptionFactory exceptionFactory)
        {
            _exceptionFactory = exceptionFactory;
        }

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>The model.</value>
        public RobotModel Model { get { return RobotModel.ToyRobot; } }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public RobotStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public RobotPosition Position { get; set; }

        /// <summary>
        /// Occurs when progress changed.
        /// </summary>
        public event ProgressChangedHandler ProgressChanged;

        /// <summary>
        /// Ons the progress changed event.
        /// </summary>
        protected void OnProgressChangedEvent() => ProgressChanged?.Invoke(this, new ProgressChangedEventArgs(Position));

        /// <summary>
        /// Execute the specified commandLine.
        /// </summary>
        /// <returns>The execute.</returns>
        /// <param name="commandLine">Command line.</param>
        public void Execute(string commandLine)
        {
            Invoker invoker = new Invoker(_exceptionFactory);
            ICommand command = invoker.GetCommand(commandLine, this);
            command.Execute();
        }
    }
}