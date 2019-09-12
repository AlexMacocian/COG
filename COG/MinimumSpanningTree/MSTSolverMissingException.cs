using System;
using System.Runtime.Serialization;

namespace COG.MinimumSpanningTree
{
    /// <summary>
    /// Exception for missing solver for MST.
    /// </summary>
    public class MSTSolverMissingException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MSTSolverMissingException"/> class.
        /// </summary>
        public MSTSolverMissingException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MSTSolverMissingException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        public MSTSolverMissingException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MSTSolverMissingException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        /// <param name="innerException">The innerException<see cref="Exception"/></param>
        public MSTSolverMissingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MSTSolverMissingException"/> class.
        /// </summary>
        /// <param name="info">The info<see cref="SerializationInfo"/></param>
        /// <param name="context">The context<see cref="StreamingContext"/></param>
        protected MSTSolverMissingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
