using System;
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
            IExceptionFactory exceptionFactory = new ExceptionFactory();
            var robot = new ToyRobot(new TableSurface());
            robot.ProgressChanged += OnProgressChanged;

            Console.WriteLine("Please any key to start");
            Console.ReadKey();
            Console.WriteLine();

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
            Console.ReadKey();
        }

        private static void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine($"{e.Position.X} {e.Position.Y} {e.Position.Direction.ToString()}");
        }
    }
}