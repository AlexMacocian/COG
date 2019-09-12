using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace COG.ShortestPaths
{
    /// <summary>
    /// Exception to be used when shortest path algorithms fail to find a path.
    /// </summary>
    public class NoPathFoundException : Exception
    {
        public NoPathFoundException()
        {
        }

        public NoPathFoundException(string message) : base(message)
        {
        }

        public NoPathFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoPathFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
