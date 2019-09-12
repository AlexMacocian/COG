using System.Collections.Generic;

namespace COG.Representations
{
    /// <summary>
    /// Base class for representations of graphs.
    /// To be used for inheritance.
    /// </summary>
    public abstract class BaseRepresentation
    {
        /// <summary>
        /// Gets or sets the Nodes.
        /// Number of nodes in the graph.
        /// </summary>
        public abstract int Nodes { get; set; }

        /// <summary>
        /// Gets the Edges.
        /// Number of vertices in the graph.
        /// </summary>
        public abstract int Edges { get; }


        /// <summary>
        /// Returns cost of edge between the provided nodes.
        /// </summary>
        /// <param name="index1">Source node.</param>
        /// <param name="index2">Destination node.</param>
        /// <returns>Cost of the edge.</returns>
        public abstract double this[int index1, int index2] { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepresentation"/> class.
        /// </summary>
        /// <param name="N">Forecast number of nodes in the graph.</param>
        public BaseRepresentation(int N = 0)
        {
        }

        /// <summary>
        /// Add an edge to the representation.
        /// </summary>
        /// <param name="edge">Structure containing the edge data.</param>
        public abstract void AddEdge(Edge edge);

        /// <summary>
        /// Remove an edge from the representation.
        /// </summary>
        /// <param name="edge">Structure containing the edge data.</param>
        public abstract void RemoveEdge(Edge edge);

        /// <summary>
        /// Get list of edges from provided node id.
        /// </summary>
        /// <param name="nodeId">Id of node.</param>
        /// <returns>List of edges from the current node.</returns>
        public abstract List<Edge> GetEdges(int nodeId);
    }
}
