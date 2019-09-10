using System;
using System.Collections.Generic;
using System.Text;

namespace COG.Representations
{
    /// <summary>
    /// Weighted matrix representation for a graph.
    /// </summary>
    public class WeightedMatrixRepresentation : BaseRepresentation
    {
        #region Fields
        private int edges;
        private double[,] adjMatrix;
        #endregion
        #region Properties
        /// <summary>
        /// Number of nodes in the graph.
        /// </summary>
        public override int Nodes
        {
            get => (int)Math.Sqrt(adjMatrix.Length);
            set
            {
                if (adjMatrix.Length < value)
                {
                    double[,] newMatrix = new double[value, value];
                    Array.Copy(adjMatrix, newMatrix, adjMatrix.Length);
                    adjMatrix = newMatrix;
                }
            }
        }
        /// <summary>
        /// Number of edges in the graph.
        /// </summary>
        public override int Edges { get => edges; }
        /// <summary>
        /// Access edges using indexes.
        /// </summary>
        /// <param name="index1">Starting node id.</param>
        /// <param name="index2">Ending node id.</param>
        /// <returns>Edge weight if an edge exists and 0 if no edge exists.</returns>
        public override double this[int index1, int index2] { get => adjMatrix[index1, index2];
            set
            {
                double prevValue = adjMatrix[index1, index2];
                if (value > 0 && prevValue == 0)
                {
                    edges++;
                }
                else if(value == 0 && prevValue > 0)
                {
                    edges--;
                }
                adjMatrix[index1, index2] = value;
            }
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Creates an instance of a matrix representation for a graph.
        /// </summary>
        /// <param name="N">Forecasted number of nodes.</param>
        /// <remarks>
        /// The number of nodes doesn't have to be exact, but exceeding the matrix size will cause the matrix to resize
        /// causing a costly operation.
        /// The instance holds N*N double values in a 2D array.
        /// </remarks>
        public WeightedMatrixRepresentation(int N) : base(N)
        {
            adjMatrix = new double[N, N];
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Adds edge to the graph.
        /// </summary>
        /// <param name="edge">Edge to be added.</param>
        /// <remarks>
        /// If edge cost is 0, the edge will not be added.
        /// </remarks>
        public override void AddEdge(BaseEdge edge)
        {
            this[edge.From, edge.To] = edge.Cost;
        }
        /// <summary>
        /// Removes the specified edge from the graph.
        /// </summary>
        /// <param name="edge">Edge structure containing the edge informations.</param>
        /// <remarks>
        /// You don't need to provide an exact reference. The structure edge is used only to provide the 
        /// fromId and toId in order to identify the edge to be removed.
        /// </remarks>
        public override void RemoveEdge(BaseEdge edge)
        {
            this[edge.From, edge.To] = 0;       
        }
        /// <summary>
        /// Gets a list of all edges from specified node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns>All edges from specified node.</returns>
        public override List<BaseEdge> GetEdges(BaseNode node)
        {
            List<BaseEdge> edges = new List<BaseEdge>();
            for(int i = 0; i < Nodes; i++)
            {
                if(adjMatrix[node.Id, i] > 0)
                {
                    BaseEdge baseEdge = new BaseEdge();
                    baseEdge.Cost = adjMatrix[node.Id, i];
                    baseEdge.From = node.Id;
                    baseEdge.To = i;
                    edges.Add(baseEdge);
                }
            }
            return edges;
        }
        #endregion
        #region Private Methods

        #endregion
    }
}
