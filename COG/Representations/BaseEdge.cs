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
        public int From { get; set; }
        /// <summary>
        /// Id of destination node.
        /// </summary>
        public int To { get; set; }
        /// <summary>
        /// Cost of the edge.
        /// </summary>
        public double Cost { get; set; }
        /// <summary>
        /// Creates a new instance of BaseEdge.
        /// </summary>
        /// <param name="from">ID of source node.</param>
        /// <param name="to">ID of destination node.</param>
        /// <param name="cost">Cost of edge.</param>
        public BaseEdge(int from, int to, double cost)
        {
            this.From = from;
            this.To = to;
            this.Cost = cost;
        }
        /// <summary>
        /// Creates a new instance of BaseEdge.
        /// </summary>
        /// <param name="from">Source node.</param>
        /// <param name="to">Destination node.</param>
        /// <param name="cost">Cost of edge.</param>
        public BaseEdge(BaseNode from, BaseNode to, double cost)
        {
            this.From = from.Id;
            this.To = to.Id;
            this.Cost = cost;
        }
    }
}
