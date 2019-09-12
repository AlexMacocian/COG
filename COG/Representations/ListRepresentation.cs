using System.Collections.Generic;

namespace COG.Representations
{
    /// <summary>
    /// List representation of a graph.
    /// </summary>
    public class ListRepresentation : BaseRepresentation
    {
        /// <summary>
        /// Defines the <see cref="AdjEntry" />
        /// </summary>
        private class AdjEntry
        {
            /// <summary>
            /// Defines the ToId
            /// </summary>
            public int ToId;

            /// <summary>
            /// Defines the Cost
            /// </summary>
            public double Cost;
        }

        /// <summary>
        /// Defines the adjList
        /// </summary>
        private List<List<AdjEntry>> adjList;

        /// <summary>
        /// Defines the edges
        /// </summary>
        private int edges;

        /// <summary>
        /// Gets or sets the Nodes
        /// Number of nodes in the graph.
        /// </summary>
        public override int Nodes
        {
            get => adjList.Count;
            set
            {
                if (adjList.Capacity < value)
                {
                    adjList.Capacity = value;
                    for (int i = 0; i < value; i++)
                    {
                        if (adjList[i] == null)
                        {
                            adjList[i] = new List<AdjEntry>();
                        }
                    }
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
        /// <returns>1 is an edge exists and 0 if no edge exists.</returns>
        /// <remarks>
        /// When setting an edge value, this representation is unweighted, thus, if the value is equal and over 1, it will be set to 1, 
        /// otherwise it will be set to 0. If you want specific costs, use a weighted representation.
        /// </remarks>
        public override double this[int index1, int index2] { get => GetEdgeCost(index1, index2); set => SetEdgeCost(index1, index2, value >= 1 ? 1 : 0); }
        /// <summary>
        /// Initializes a new instance of the <see cref="ListRepresentation"/> class.
        /// </summary>
        /// <param name="N">Forecasted number of nodes.</param>
        public ListRepresentation(int N) : base(N)
        {
            adjList = new List<List<AdjEntry>>(N);
            for (int i = 0; i < N; i++)
            {
                adjList.Add(new List<AdjEntry>());
            }
        }

        /// <summary>
        /// Adds edge to the graph.
        /// </summary>
        /// <param name="edge">Edge to be added.</param>
        public override void AddEdge(Edge edge)
        {
            this[edge.From, edge.To] = 1;
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
        /// Get all edges from specified node.
        /// </summary>
        /// <param name="nodeId">Id of specified node.</param>
        /// <returns>List of edges from provided node.</returns>
        public override List<Edge> GetEdges(int nodeId)
        {
            List<Edge> edges = new List<Edge>(adjList[nodeId].Count);
            foreach (AdjEntry entry in adjList[nodeId])
            {
                Edge edge = new Edge
                {
                    From = nodeId,
                    To = entry.ToId,
                    Cost = entry.Cost
                };
                edges.Add(edge);
            }
            return edges;
        }

        /// <summary>
        /// The GetEdgeCost
        /// </summary>
        /// <param name="fromId">The fromId<see cref="int"/></param>
        /// <param name="toId">The toId<see cref="int"/></param>
        /// <returns>The <see cref="double"/></returns>
        private double GetEdgeCost(int fromId, int toId)
        {
            foreach (AdjEntry entry in adjList[fromId])
            {
                if (entry.ToId == toId)
                {
                    return entry.Cost;
                }
            }
            return 0;
        }

        /// <summary>
        /// The GetEntry
        /// </summary>
        /// <param name="fromId">The fromId<see cref="int"/></param>
        /// <param name="toId">The toId<see cref="int"/></param>
        /// <returns>The <see cref="AdjEntry"/></returns>
        private AdjEntry GetEntry(int fromId, int toId)
        {
            foreach (AdjEntry entry in adjList[fromId])
            {
                if (entry.ToId == toId)
                {
                    return entry;
                }
            }
            return null;
        }

        /// <summary>
        /// The SetEdgeCost
        /// </summary>
        /// <param name="fromId">The fromId<see cref="int"/></param>
        /// <param name="toId">The toId<see cref="int"/></param>
        /// <param name="cost">The cost<see cref="double"/></param>
        private void SetEdgeCost(int fromId, int toId, double cost)
        {
            if (cost > 0)
            {
                AdjEntry entry = GetEntry(fromId, toId);
                if (entry != null)
                {
                    entry.Cost = 1;
                }
                else
                {
                    AdjEntry newEntry = new AdjEntry
                    {
                        ToId = toId,
                        Cost = 1
                    };
                    adjList[fromId].Add(newEntry);
                    edges++;
                }
            }
            else
            {
                AdjEntry entry = GetEntry(fromId, toId);
                if (entry != null)
                {
                    adjList[fromId].Remove(entry);
                    edges--;
                }
            }
        }
    }
}
