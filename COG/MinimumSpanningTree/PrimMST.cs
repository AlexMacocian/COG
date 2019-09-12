using COG.Graphs;
using COG.Representations;
using System.Collections.Generic;

namespace COG.MinimumSpanningTree
{
    /// <summary>
    /// MST solver using Prim's algorithm.
    /// </summary>
    public sealed class PrimMST : IMSTSolver
    {
        /// <summary>
        /// The Solve
        /// </summary>
        /// <param name="baseGraph">The baseGraph<see cref="BaseGraph"/></param>
        /// <returns>The <see cref="List{Edge}"/></returns>
        List<Edge> IMSTSolver.Solve(BaseGraph baseGraph)
        {
            List<Edge> edges = new List<Edge>();
            int[] parent = new int[baseGraph.Nodes];
            double[] keys = new double[baseGraph.Nodes];
            bool[] mstSet = new bool[baseGraph.Nodes];
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i] = double.MaxValue;
            }
            keys[0] = 0;
            parent[0] = -1;
            for (int i = 0; i < baseGraph.Nodes - 1; i++)
            {
                int index = MinimumKey(keys, mstSet);
                if (index == -1)
                {
                    throw new MSTException("Couldn't find a minimum spanning tree for this graph. Most probably the graph is not connected/strongly-connected.");
                }
                mstSet[index] = true;
                foreach (Edge edge in baseGraph.GetEdges(index))
                {
                    if (mstSet[edge.To] == false && edge.Cost < keys[edge.To])
                    {
                        parent[edge.To] = index;
                        keys[edge.To] = edge.Cost;
                    }
                }
            }

            for (int i = 1; i < baseGraph.Nodes; i++)
            {
                Edge edge = new Edge
                {
                    From = parent[i],
                    To = i
                };
                edge.Cost = baseGraph[edge.From, edge.To];
                edges.Add(edge);
            }
            return edges;
        }

        /// <summary>
        /// The MinimumKey
        /// </summary>
        /// <param name="keys">The keys<see cref="double[]"/></param>
        /// <param name="mstSet">The mstSet<see cref="bool[]"/></param>
        /// <returns>The <see cref="int"/></returns>
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
