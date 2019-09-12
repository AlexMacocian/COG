using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace COG.ShortestPaths
{
    /// <summary>
    /// Exception used in case when no shortest path solver exists in the current graph.
    /// </summary>
    public class MissingShortestPathsSolverException : Exception
    {
        public MissingShortestPathsSolverException()
        {
        }

        public MissingShortestPathsSolverException(string message) : base(message)
        {
        }

        public MissingShortestPathsSolverException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingShortestPathsSolverException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
