using COG.MinimumSpanningTree;
using COG.Representations;
using System;
using System.Collections.Generic;
using System.Text;

namespace COG.Graphs
{
    /// <summary>
    /// Base graph class.
    /// </summary>
    public class BaseGraph
    {
        #region Fields
        /// <summary>
        /// Graph representation.
        /// </summary>
        protected BaseRepresentation representation;
        /// <summary>
        /// Solver for MST.
        /// </summary>
        protected IMSTSolver mstSolver;
        #endregion
        #region Properties
        /// <summary>
        /// Number of nodes in the graph.
        /// </summary>
        public int Nodes { get => representation.Nodes; set => representation.Nodes = value; }
        /// <summary>
        /// Number of edges in the graph.
        /// </summary>
        public virtual int Edges { get => representation.Edges; }
        /// <summary>
        /// Solver for minimum spanning tree.
        /// </summary>
        public IMSTSolver MSTSolver { get => mstSolver; set => mstSolver = value; }
        #endregion
        #region Constructors
        /// <summary>
        /// Creates a new instance of BaseGraph.
        /// </summary>
        /// <param name="representation">Graph representation.</param>
        public BaseGraph(BaseRepresentation representation)
        {
            this.representation = representation;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Return the minimum spanning tree.
        /// </summary>
        /// <returns>List of edges defining the MST.</returns>
        public virtual List<BaseEdge> GetMinimumSpanningTree()
        {
            if(mstSolver == null)
            {
                throw new MSTSolverMissingException();
            }
            else
            {
                return mstSolver.Solve(representation);
            }
        }
        /// <summary>
        /// Add an edge to the graph.
        /// </summary>
        /// <param name="baseEdge">Structure containing the edge details.</param>
        public virtual void AddEdge(BaseEdge baseEdge)
        {
            representation.AddEdge(baseEdge);
        }
        /// <summary>
        /// Remove edge from the graph.
        /// </summary>
        /// <param name="baseEdge">Structure containing the edge details.</param>
        public virtual void RemoveEdge(BaseEdge baseEdge)
        {
            representation.RemoveEdge(baseEdge);
        }
        /// <summary>
        /// Get a list of edges from given node.
        /// </summary>
        /// <param name="node">Node containing the edges.</param>
        /// <returns>List of edges from given node.</returns>
        public virtual List<BaseEdge> GetEdges(BaseNode node)
        {
            return representation.GetEdges(node);
        }
        #endregion
        #region Private Methods
        #endregion
    }
}
