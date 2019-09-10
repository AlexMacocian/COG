using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace COG.MinimumSpanningTree
{
    /// <summary>
    /// Exception for missing solver for MST.
    /// </summary>
    public class MSTSolverMissingException : Exception
    {
        /// <summary>
        /// Creates a new instance of MSTSolverMissingException
        /// </summary>
        public MSTSolverMissingException()
        {
        }
        /// <summary>
        /// Creates a new instance of MSTSolverMissingException
        /// </summary>
        public MSTSolverMissingException(string message) : base(message)
        {
        }
        /// <summary>
        /// Creates a new instance of MSTSolverMissingException
        /// </summary>
        public MSTSolverMissingException(string message, Exception innerException) : base(message, innerException)
        {
        }
        /// <summary>
        /// Creates a new instance of MSTSolverMissingException
        /// </summary>
        protected MSTSolverMissingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
