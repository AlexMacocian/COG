using System;
using System.Collections.Generic;
using System.Text;
using COG.Representations;

namespace COG.Graphs
{
    /// <summary>
    /// Class for directed graphs.
    /// </summary>
    public sealed class DirectedGraph : BaseGraph
    {
        
        /// <summary>
        /// Creates a new instance of directed graph.
        /// </summary>
        /// <param name="representation"></param>
        public DirectedGraph(BaseRepresentation representation) : base(representation)
        {
        }
    }
}
