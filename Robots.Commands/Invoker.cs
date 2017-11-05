﻿using System;
using Frameworks.Exceptions;
using Robots.Actions;

namespace Robots.Commands
{
    /// <summary>
    /// a commands factory
    /// </summary>
    public class Invoker
    {
        private IExceptionFactory _exceptionFactory;

        public Invoker(IExceptionFactory exceptionFactory)
        {
            _exceptionFactory = exceptionFactory;
        }

        /// <summary>
        /// get a command instance by a given command string
        /// </summary>
        /// <returns>The command instance</returns>
        /// <param name="commandLine">a string of command line</param>
        public ICommand GetCommand(string commandLine, IRobot robot)
        {
            ICommand cmd = null;
            var (action, parameters) = getCommandInfo();

            try
            {
                switch (action)
                {
                    //case RobotCommand.Place:
                    //    cmd = new PlaceCommand();
                    //    break;
                    case RobotCommand.MOVE:
                        cmd = new MoveCommand(robot);
                        break;
                    //case RobotCommand.Left:
                    //    cmd = new LeftCommand();
                    //    break;
                    //case RobotCommand.Right:
                    //    cmd = new RightCommand();
                    //    break;
                    //case RobotCommand.Report:
                    //cmd = new ReportCommand();
                    //break;
                    default:
                        _exceptionFactory.GenerateWarningException($"Unkown command {commandLine}");
                        break;
                }
            }
            catch (InvalidCastException)
            {
                _exceptionFactory.GenerateSafeException($"The current robot is not able to execute the {action.ToString()} command");
            }
            return cmd;

            (RobotCommand action, string parameters) getCommandInfo()
            {
                commandLine = commandLine.Trim();
                int index = commandLine.IndexOf(" ", StringComparison.CurrentCulture);
                var robotCommand = (RobotCommand)Enum.Parse(typeof(RobotCommand), (index > 0 ? commandLine.Substring(0, index) : commandLine).ToUpper());
                var commandParams = index > 0 ? commandLine.Substring(index + 1) : string.Empty;
                return (robotCommand, commandParams);
            }

        }
    }
}
