using System;

namespace Frameworks.Logging
{
    /// <summary>
    /// Provide common actions for logging
    /// it is just a demo to show what should be done!
    /// it is better to use a real open source framework
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Declare a directory full path, which used to save log files
        /// </summary>
        string LogDirPath { get; set; }

        /// <summary>
        /// Declare an email address, which will receive the log email
        /// </summary>
        string AdminEmail { get; set; }

        /// <summary>
        /// Declare a mobile admin, who will receive SMS
        /// </summary>
        string AdminMobile { get; set; }

        /// <summary>
        /// Save a debug log to file
        /// </summary>
        /// <param name="msg">message</param>
        void LogToFileDebug(string msg);

        /// <summary>
        /// Save an error log to file
        /// </summary>
        /// <param name="msg">message</param>
        /// <param name="ex">an exception</param>
        void LogToFileDebug(string msg, Exception ex);

        /// <summary>
        /// Save a warning log to file
        /// </summary>
        /// <param name="msg">message</param>
        void LogToFileWarning(string msg);

        /// <summary>
        /// Save an error log to file
        /// </summary>
        /// <param name="msg">message</param>
        /// <param name="ex">an exception</param>
        void LogToFileWarning(string msg, Exception ex);

        /// <summary>
        /// Save an error log to file
        /// </summary>
        /// <param name="msg">message</param>
        void LogToFileError(string msg);

        /// <summary>
        /// Save an error log to file
        /// </summary>
        /// <param name="msg">message</param>
        /// <param name="ex">an exception</param>
        void LogToFileError(string msg, Exception ex);

        /// <summary>
        /// Save a fotal log to file
        /// </summary>
        /// <param name="msg">message</param>
        void LogToFileFatal(string msg);

        /// <summary>
        /// Save a fotal log to file
        /// </summary>
        /// <param name="msg">message</param>
        /// <param name="ex">an exception</param>
        void LogToFileFatal(string msg, Exception ex);

        /// <summary>
        /// Send an email to admin
        /// </summary>
        /// <param name="msg">the body of email</param>
        void LogToEmail(string msg);

        /// <summary>
        /// Send an email to admin
        /// </summary>
        /// <param name="msg">the body of email</param>
        /// <param name="ex">an exception</param>
        void LogToEmail(string msg, Exception ex);

        /// <summary>
        /// Send an email to admin
        /// </summary>
        /// <param name="msg">the body of email</param>
        /// <param name="ccEmailList">a email list, seperated by comma</param>
        void LogToEmail(string msg, string ccEmailList);

        /// <summary>
        /// Send an email to admin
        /// </summary>
        /// <param name="msg">the body of email</param>
        /// <param name="ex">an exception</param>
        /// <param name="ccEmailList">a email list, seperated by comma</param>
        void LogToEmail(string msg, Exception ex, string ccEmailList);

        /// <summary>
        /// Send a SMS to admin
        /// </summary>
        /// <param name="msg">message</param>
        void LogToSMS(string msg);

        /// <summary>
        /// Send a SMS to admin
        /// </summary>
        /// <param name="msg">message</param>
        /// <param name="ex">an exception</param>
        void LogToSMS(string msg, Exception ex);
    }
}
