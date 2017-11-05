using System;
using Robots.Actions;

namespace Robots.Commands
{
    /// <summary>
    /// private a common interface for all robat commands
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Execute a particular command.
        /// </summary>
        void Execute();
    }
}