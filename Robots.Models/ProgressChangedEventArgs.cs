using System;
using Robots.Surfaces;

namespace Robots.Models
{
    /// <summary>
    /// Progress changed handler.
    /// </summary>
    public delegate void ProgressChangedHandler(object sender, ProgressChangedEventArgs e);

    /// <summary>
    /// Report position event arguments.
    /// </summary>
    public class ProgressChangedEventArgs : EventArgs
    {
        public ProgressChangedEventArgs(RobotPosition position)
        {
            Position = position;
        }

        public RobotPosition Position { get; set; }
    }
}