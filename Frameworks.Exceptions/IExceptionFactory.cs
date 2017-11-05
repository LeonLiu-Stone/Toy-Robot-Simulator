using System;
namespace Frameworks.Exceptions
{
    /// <summary>
    /// Private a mechanism for generating custom exceptions
    /// </summary>
    public interface IExceptionFactory
    {
        /// <summary>
        /// Usually used when jumping logical
        /// </summary>
        /// <param name="msg">message</param>
        void GenerateSafeException(string msg);

        /// <summary>
        /// Usually used when a low-leverl failure is detected
        /// </summary>
        /// <param name="msg">message</param>
        void GenerateWarningException(string msg);

        /// <summary>
        /// Usually used when a middle-leverl failure is detected
        /// </summary>
        /// <param name="msg">message</param>
        void GenerateErrorException(string msg);

        /// <summary>
        /// Usually used when a high-leverl failure is detected
        /// </summary>
        /// <param name="msg">message</param>
        void GenerateFatalException(string msg);
    }
}
