using COG.Representations;

namespace COG.Graphs
{
    /// <summary>
    /// Class for undirected graphs.
    /// </summary>
    public sealed class UndirectedGraph : BaseGraph
    {
        /// <summary>
        /// Gets the Edges.
        /// Number of edges in the graph.
        /// </summary>
        public override int Edges { get => base.Edges / 2; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UndirectedGraph"/> class.
        /// </summary>
        /// <param name="representation">Representation of the graph nodes.</param>
        public UndirectedGraph(BaseRepresentation representation) : base(representation)
        {
        }

        /// <summary>
        /// Add an edge to the undirected graph.
        /// </summary>
        /// <param name="baseEdge">Structure containing the edge details.</param>
        public override void AddEdge(Edge baseEdge)
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

        /// <summary>
        /// Removes an edge from the undirected graph.
        /// </summary>
        /// <param name="baseEdge">Structure containing the edge details.</param>
        public override void RemoveEdge(Edge baseEdge)
        {
            base.RemoveEdge(baseEdge);
            int to = baseEdge.To;
            baseEdge.To = baseEdge.From;
            baseEdge.From = to;
            base.RemoveEdge(baseEdge);
        }
    }
}
