using System;
using System.Collections.Generic;
using System.Text;
using COG.Representations;

namespace COG.Graphs
{
    /// <summary>
    /// Class for undirected graphs.
    /// </summary>
    public sealed class UndirectedGraph : BaseGraph
    {
        /// <summary>
        /// Creates a new instance of undirected graph.
        /// </summary>
        /// <param name="representation">Representation of the graph nodes.</param>
        public UndirectedGraph(BaseRepresentation representation) : base(representation)
        {

        }
        /// <summary>
        /// Add an edge to the undirected graph.
        /// </summary>
        /// <param name="baseEdge">Structure containing the edge details.</param>
        public override void AddEdge(BaseEdge baseEdge)
        {
            /*
             * Add the edge to the graph, reverse the points and add it again.
             */ 
            base.AddEdge(baseEdge); 
            int to = baseEdge.To;
            baseEdge.To = baseEdge.From;
            baseEdge.From = to;
            base.AddEdge(baseEdge);
        }
    }
}
