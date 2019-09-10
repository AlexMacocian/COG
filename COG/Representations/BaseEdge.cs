using System;
using System.Collections.Generic;
using System.Text;

namespace COG.Representations
{
    /// <summary>
    /// Bas edge structure holding edge values.
    /// </summary>
    public struct BaseEdge
    {
        /// <summary>
        /// Id of source node.
        /// </summary>
        public int From;
        /// <summary>
        /// Id of destination node.
        /// </summary>
        public int To;
        /// <summary>
        /// Cost of the edge.
        /// </summary>
        public double Cost;
    }
}
