using System;
using System.Collections.Generic;
using System.Text;

namespace COG.Representations
{
    /// <summary>
    /// Base class for representations of graphs.
    /// To be used for inheritance.
    /// </summary>
    public abstract class BaseRepresentation
    {
        #region Fields
        #endregion
        #region Properties
        /// <summary>
        /// Number of nodes in the graph.
        /// </summary>
        public abstract int Nodes { get ; set ; }
        /// <summary>
        /// Number of vertices in the graph.
        /// </summary>
        public abstract int Edges { get ; }
        /// <summary>
        /// Returns cost of edge between the provided nodes.
        /// </summary>
        /// <param name="index1">Source node.</param>
        /// <param name="index2">Destination node.</param>
        /// <returns>Cost of the edge.</returns>
        public abstract double this [int index1, int index2] { get; set; }
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor for base representation of a graph.
        /// </summary>
        /// <param name="N">Forecast number of nodes in the graph.</param>
        public BaseRepresentation(int N = 0)
        {
            
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Add an edge to the representation.
        /// </summary>
        /// <param name="edge">Structure containing the edge data.</param>
        public abstract void AddEdge(BaseEdge edge);
        /// <summary>
        /// Remove an edge from the representation.
        /// </summary>
        /// <param name="edge">Structure containing the edge data.</param>
        public abstract void RemoveEdge(BaseEdge edge);
        /// <summary>
        /// Get list of edges from provided node.
        /// </summary>
        /// <param name="node">Source node of the returned edges.</param>
        public abstract List<BaseEdge> GetEdges(BaseNode node);
        #endregion
        #region Private Methods
        #endregion
    }
}
