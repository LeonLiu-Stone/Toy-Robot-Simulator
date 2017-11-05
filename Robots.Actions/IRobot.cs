using System;

namespace Robots.Actions
{
    /// <summary>
    /// Private an interface for all robot's basic actions.
    /// </summary>
    public interface IRobot
    {
        void Execute(string commandLine);
    }
}