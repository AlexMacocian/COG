using System;
using System.Collections.Generic;

namespace COG.Representations
{
    /// <summary>
    /// Weighted matrix representation for a graph.
    /// </summary>
    public class WeightedMatrixRepresentation : BaseRepresentation
    {
        /// <summary>
        /// Defines the edges
        /// </summary>
        private int edges;

        /// <summary>
        /// Defines the adjMatrix
        /// </summary>
        private double[,] adjMatrix;

        /// <summary>
        /// Defines the nodes
        /// </summary>
        private int nodes;

        /// <summary>
        /// Gets or sets the Nodes
        /// Number of nodes in the graph.
        /// </summary>
        public override int Nodes
        {
            get => nodes;
            set
            {
                if (adjMatrix.GetLength(0) < value)
                {
                    double[,] newMatrix = new double[value, value];
                    Array.Copy(adjMatrix, newMatrix, adjMatrix.Length);
                    adjMatrix = newMatrix;
                }
            }
        }

        /// <summary>
        /// Gets the Edges
        /// Number of edges in the graph.
        /// </summary>
        public override int Edges { get => edges; }


        /// <summary>
        /// Access edges using indexes.
        /// </summary>
        /// <param name="index1">Starting node id.</param>
        /// <param name="index2">Ending node id.</param>
        /// <returns>Edge weight if an edge exists and 0 if no edge exists.</returns>
        public override double this[int index1, int index2]
        {
            get => adjMatrix[index1, index2];
            set
            {
                double prevValue = adjMatrix[index1, index2];
                if (value > 0 && prevValue == 0)
                {
                    edges++;
                }
                else if (value == 0 && prevValue > 0)
                {
                    edges--;
                }
                adjMatrix[index1, index2] = value;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="WeightedMatrixRepresentation"/> class.
        /// </summary>
        /// <param name="N">Forecasted number of nodes.</param>
        public WeightedMatrixRepresentation(int N) : base(N)
        {
            adjMatrix = new double[N, N];
            nodes = N;
        }

        /// <summary>
        /// Adds edge to the graph.
        /// </summary>
        /// <param name="edge">Edge to be added.</param>
        public override void AddEdge(Edge edge)
        {
            this[edge.From, edge.To] = edge.Cost;
        }

        /// <summary>
        /// Removes the specified edge from the graph.
        /// </summary>
        /// <param name="edge">Edge structure containing the edge informations.</param>
        public override void RemoveEdge(Edge edge)
        {
            this[edge.From, edge.To] = 0;
        }

        /// <summary>
        /// Gets a list of all edges from specified node.
        /// </summary>
        /// <param name="nodeId">Id of specified node.</param>
        /// <returns>All edges from specified node.</returns>
        public override List<Edge> GetEdges(int nodeId)
        {
            List<Edge> edges = new List<Edge>();
            for (int i = 0; i < Nodes; i++)
            {
                if (adjMatrix[nodeId, i] > 0)
                {
                    Edge baseEdge = new Edge
                    {
                        Cost = adjMatrix[nodeId, i],
                        From = nodeId,
                        To = i
                    };
                    edges.Add(baseEdge);
                }
            }
            return edges;
        }
    }
}
