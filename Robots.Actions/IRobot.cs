using System;

namespace Robots.Actions
{
    /// <summary>
    /// Private an interface for all robot's basic actions.
    /// </summary>
    public interface IRobot
    {
        /// <summary>
        /// Execute the specified commandLine.
        /// </summary>
        /// <returns>The execute.</returns>
        /// <param name="commandLine">Command line.</param>
        void Execute(string commandLine);
    }
}