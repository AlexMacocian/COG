using System;
using System.Collections.Generic;
using System.Text;

namespace COG.Representations
{
    /// <summary>
    /// Weighted list representation for a graph.
    /// </summary>
    public class WeightedListRepresentation : BaseRepresentation
    {
        #region Fields
        private class AdjEntry
        {
            public int ToId;
            public double Cost;
        }
        private List<List<AdjEntry>> adjList;
        private int edges;
        #endregion
        #region Properties
        /// <summary>
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
        /// Number of edges in the graph.
        /// </summary>
        public override int Edges { get => edges; }
        /// <summary>
        /// Access edges using indexes.
        /// </summary>
        /// <param name="index1">Starting node id.</param>
        /// <param name="index2">Ending node id.</param>
        /// <returns>Edge weight if an edge exists and 0 if no edge exists.</returns>
        public override double this[int index1, int index2] { get => GetEdgeCost(index1, index2); set => SetEdgeCost(index1, index2, value); }
        #endregion
        #region Constructors
        /// <summary>
        /// Creates an instance of a matrix representation for a graph.
        /// </summary>
        /// <param name="N">Forecasted number of nodes.</param>
        /// <remarks>
        /// The number of nodes doesn't have to be exact, but exceeding the provided size might cause the array behind the list to resize
        /// causing a costly operation.
        /// </remarks>
        public WeightedListRepresentation(int N) : base(N)
        {
            adjList = new List<List<AdjEntry>>(N);
            for (int i = 0; i < N; i++)
            {
                adjList.Add(new List<AdjEntry>());
            }
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Adds edge to the graph.
        /// </summary>
        /// <param name="edge">Edge to be added.</param>
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
            SetEdgeCost(edge.From, edge.To, 0);
        }
        /// <summary>
        /// Get all the edges from specified node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns>List of all edges from provided node.</returns>
        public override List<BaseEdge> GetEdges(BaseNode node)
        {
            List<BaseEdge> edges = new List<BaseEdge>(adjList[node.Id].Count);
            foreach(AdjEntry entry in adjList[node.Id])
            {
                BaseEdge edge = new BaseEdge();
                edge.From = node.Id;
                edge.To = entry.ToId;
                edge.Cost = entry.Cost;
                edges.Add(edge);
            }
            return edges;
        }
        #endregion
        #region Private Methods
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
        private void SetEdgeCost(int fromId, int toId, double cost)
        {
            if (cost > 0)
            {
                AdjEntry entry = GetEntry(fromId, toId);
                if (entry != null)
                {
                    entry.Cost = cost;
                }
                else
                {
                    AdjEntry newEntry = new AdjEntry();
                    newEntry.ToId = toId;
                    newEntry.Cost = cost;
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
        #endregion
    }
}
