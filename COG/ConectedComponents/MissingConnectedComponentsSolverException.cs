using System;
using System.Runtime.Serialization;

namespace COG.ConectedComponents
{
    /// <summary>
    /// Exception to be used when no CC solver is implemented in the graph.
    /// </summary>
    public class MissingConnectedComponentsSolverException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MissingConnectedComponentsSolverException"/> class.
        /// </summary>
        public MissingConnectedComponentsSolverException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MissingConnectedComponentsSolverException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        public MissingConnectedComponentsSolverException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MissingConnectedComponentsSolverException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        /// <param name="innerException">The innerException<see cref="Exception"/></param>
        public MissingConnectedComponentsSolverException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MissingConnectedComponentsSolverException"/> class.
        /// </summary>
        /// <param name="info">The info<see cref="SerializationInfo"/></param>
        /// <param name="context">The context<see cref="StreamingContext"/></param>
        protected MissingConnectedComponentsSolverException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
