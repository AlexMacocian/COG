using System;
using System.Runtime.Serialization;

namespace COG.Graphs
{
    /// <summary>
    /// Exception used for missing representations in a graph.
    /// </summary>
    public class MissingRepresentationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MissingRepresentationException"/> class.
        /// </summary>
        public MissingRepresentationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MissingRepresentationException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        public MissingRepresentationException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MissingRepresentationException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        /// <param name="innerException">The innerException<see cref="Exception"/></param>
        public MissingRepresentationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MissingRepresentationException"/> class.
        /// </summary>
        /// <param name="info">The info<see cref="SerializationInfo"/></param>
        /// <param name="context">The context<see cref="StreamingContext"/></param>
        protected MissingRepresentationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
