using System;
using Frameworks.Logging;

namespace Frameworks.Exceptions
{
    /// <summary>
    /// Realise a Exception factory interface to provate common exception-related methods
    /// </summary>
    public class ExceptionFactory : IExceptionFactory
    {
        /// <summary>
        /// Declare an instance of logger
        /// it is just a demo, has not been fully completed yet.
        /// </summary>
        private ILogger _logger;

        /// <summary>
        /// Declare an instance
        /// </summary>
        public ExceptionFactory()
        {
            // it is better to use a real open soucr framework, such as log4net.
            _logger = new Log4Net();
        }

        /// <summary>
        /// Declare an instance by passing an instance of logger.
        /// </summary>
        /// <param name="logger"></param>
        public ExceptionFactory(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Usually used when jumping logical
        /// </summary>
        /// <param name="msg">message</param>
        public void GenerateSafeException(string msg)
        {
            throw new SafeException(msg);
        }

        /// <summary>
        /// Usually used when a low-leverl failure is detected
        /// </summary>
        /// <param name="msg">message</param>
        public void GenerateWarningException(string msg)
        {
            _logger.LogToFileWarning(msg);

            throw new WarningException(msg);
        }

        /// <summary>
        /// Usually used when a middle-leverl failure is detected
        /// </summary>
        /// <param name="msg">message</param>
        public void GenerateErrorException(string msg)
        {
            _logger.LogToFileError(msg);
            _logger.LogToEmail(msg);

            throw new ErrorException(msg);
        }

        /// <summary>
        /// Usually used when a high-leverl failure is detected
        /// </summary>
        /// <param name="msg">message</param>
        public void GenerateFatalException(string msg)
        {
            _logger.LogToFileFatal(msg);
            _logger.LogToEmail(msg);
            _logger.LogToSMS(msg);

            throw new FatalException(msg);
        }
    }
}
