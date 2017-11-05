﻿using System;

namespace Frameworks.Exceptions
{
    /// <summary>
    /// the basic class of all custom exceptions
    /// </summary>
    public class CustomException : Exception
    {
        public CustomException() : base() { }

        public CustomException(string message) : base(message) { }

        public CustomException(string message, Exception innerException) : base(message, innerException) { }
    }

    /// <summary>
    /// a logical jumping exception
    /// </summary>
    public class SafeException : CustomException
    {
        public SafeException() : base() { }

        public SafeException(string message) : base(message) { }

        public SafeException(string message, Exception innerException) : base(message, innerException) { }
    }

    /// <summary>
    /// A debug-level exception
    /// </summary>
    public class InfoException : CustomException
    {
        public InfoException() : base() { }

        public InfoException(string message) : base(message) { }

        public InfoException(string message, Exception innerException) : base(message, innerException) { }
    }

    /// <summary>
    /// an exception for a low-level failure
    /// </summary>
    public class WarningException : CustomException
    {
        public WarningException() : base() { }

        public WarningException(string message) : base(message) { }

        public WarningException(string message, Exception innerException) : base(message, innerException) { }
    }

    /// <summary>
    /// an exception for a middle-level failure
    /// </summary>
    public class ErrorException : CustomException
    {
        public ErrorException() : base() { }

        public ErrorException(string message) : base(message) { }

        public ErrorException(string message, Exception innerException) : base(message, innerException) { }
    }

    /// <summary>
    /// an exception for a high-level failure
    /// </summary>
    public class FatalException : CustomException
    {
        public FatalException() : base() { }

        public FatalException(string message) : base(message) { }

        public FatalException(string message, Exception innerException) : base(message, innerException) { }
    }
}
