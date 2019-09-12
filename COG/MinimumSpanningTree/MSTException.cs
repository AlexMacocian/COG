using System;
using System.Runtime.Serialization;

namespace COG.MinimumSpanningTree
{
    /// <summary>
    /// Defines the <see cref="MSTException" />
    /// </summary>
    class MSTException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MSTException"/> class.
        /// </summary>
        public MSTException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MSTException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        public MSTException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MSTException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        /// <param name="innerException">The innerException<see cref="Exception"/></param>
        public MSTException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MSTException"/> class.
        /// </summary>
        /// <param name="info">The info<see cref="SerializationInfo"/></param>
        /// <param name="context">The context<see cref="StreamingContext"/></param>
        protected MSTException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
