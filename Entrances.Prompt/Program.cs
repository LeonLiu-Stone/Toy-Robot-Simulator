﻿using System;
using Frameworks.Exceptions;
using Robots.Common;
using Robots.Models;
using Robots.Surfaces;

namespace Entrances.Prompt
{
    class Program
    {
        static void Main(string[] args)
        {
            ExceptionFactory exceptionFactory = new ExceptionFactory();
            var robot = new ToyRobot(new TableSurface(), exceptionFactory);
            robot.ProgressChanged += OnProgressChanged;

            string commandLine = string.Empty;
            while (true)
            {
                try
                {
                    Console.WriteLine("Please input a command, or input Quit to exit.");
                    commandLine = Console.ReadLine();
                    if (commandLine.Trim().ToLower().Equals("quit")) break;
                    robot.Execute(commandLine);
                }
                catch (SafeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    // log this exception 
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("This demo is finished. Thanks for your time!");
        }

        private static void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine($"{e.Position.X} {e.Position.Y} {e.Position.Direction.ToString()}");
        }
    }
}