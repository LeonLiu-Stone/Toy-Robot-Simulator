using System;
namespace Frameworks.Logging
{
    /// <summary>
    /// Currently, it is just a mork class
    /// In a real project, it will depend on what loggin framework the company use
    /// </summary>
    public class Log4Net : ILogger
    {
        public string AdminEmail
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string AdminMobile
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string LogDirPath
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void LogToEmail(string msg) { }

        public void LogToEmail(string msg, string ccEmailList) { }

        public void LogToEmail(string msg, Exception ex) { }

        public void LogToEmail(string msg, Exception ex, string ccEmailList) { }

        public void LogToFileDebug(string msg) { }

        public void LogToFileDebug(string msg, Exception ex) { }

        public void LogToFileError(string msg) { }

        public void LogToFileError(string msg, Exception ex) { }

        public void LogToFileFatal(string msg) { }

        public void LogToFileFatal(string msg, Exception ex) { }

        public void LogToFileWarning(string msg) { }

        public void LogToFileWarning(string msg, Exception ex) { }

        public void LogToSMS(string msg) { }

        public void LogToSMS(string msg, Exception ex) { }
    }
}
