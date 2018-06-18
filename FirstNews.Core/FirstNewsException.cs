using System;
using System.Runtime.Serialization;

namespace FirstNews.Core
{
    /// <summary>
    /// Base exception type for those are thrown by Abp system for Abp specific exceptions.
    /// </summary>
    [Serializable]
    public class FirstNewsException : Exception
    {
        /// <summary>
        /// Creates a new <see cref="FirstNewsException"/> object.
        /// </summary>
        public FirstNewsException() { }

        /// <summary>
        /// Creates a new <see cref="FirstNewsException"/> object.
        /// </summary>
        public FirstNewsException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }

        /// <summary>
        /// Creates a new <see cref="FirstNewsException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        public FirstNewsException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Creates a new <see cref="FirstNewsException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public FirstNewsException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
