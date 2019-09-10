using System;
using System.Collections.Generic;
using System.Text;
using COG.Representations;

namespace COG.MinimumSpanningTree
{
    /// <summary>
    /// MST solver using Prim's algorithm.
    /// </summary>
    public sealed class PrimMST : IMSTSolver
    {
        /// <summary>
        /// Obtain the minimum spanning tree.
        /// </summary>
        /// <param name="representation">Graph representation.</param>
        /// <returns>List of edges defining the MST.</returns>
        public List<BaseEdge> Solve(BaseRepresentation representation)
        {
            List<BaseEdge> edges = new List<BaseEdge>();
            int[] parent = new int[representation.Nodes];
            double[] keys = new double[representation.Nodes];
            bool[] mstSet = new bool[representation.Nodes];
            for(int i = 0; i < keys.Length; i++)
            {
                keys[i] = double.MaxValue;
            }
            keys[0] = 0;
            parent[0] = -1;
            for(int i = 0; i < representation.Nodes - 1; i++)
            {
                int index = MinimumKey(keys, mstSet);
                if(index == -1)
                {
                    continue;
                }
                mstSet[index] = true;
                BaseNode node = new BaseNode();
                node.Id = index;
                foreach(BaseEdge edge in representation.GetEdges(node))
                {
                    if(mstSet[edge.To] == false && edge.Cost < keys[edge.To])
                    {
                        parent[edge.To] = index;
                        keys[edge.To] = edge.Cost;
                    }
                }
            }

            for (int i = 1; i < representation.Nodes; i++)
            {
                BaseEdge edge = new BaseEdge();
                edge.From = parent[i];
                edge.To = i;
                edge.Cost = representation[edge.From, edge.To];
                edges.Add(edge);
            }
            return edges;
        }
        
        private int MinimumKey(double[] keys, bool[] mstSet)
        {
            double min = double.MaxValue;
            int min_index = -1;

            for (int i = 0; i < mstSet.Length; i++)
            {
                if (mstSet[i] == false && keys[i] < min)
                {
                    min = keys[i];
                    min_index = i;
                }
            }
            return min_index;
        }
    }
}
