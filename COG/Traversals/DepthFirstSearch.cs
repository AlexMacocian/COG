using COG.Graphs;
using COG.Representations;
using System;
using System.Collections.Generic;
using System.Text;

namespace COG.Traversals
{
    /// <summary>
    /// DFS algorithm for graph traversing.
    /// </summary>
    public class DepthFirstSearch
    {
        private BaseGraph baseGraph;
        private Stack<int> nodeQueue;
        private bool[] visited;

        /// <summary>
        /// Initialize the BFS algorithm.
        /// </summary>
        /// <param name="graph">Graph to perform the algorithm on.</param>
        /// <param name="startNode">Starting node for the algorithm.</param>
        public void Initialize(BaseGraph graph, int startNode)
        {
            baseGraph = graph;
            visited = new bool[graph.Nodes];
            nodeQueue = new Stack<int>();
            nodeQueue.Push(startNode);
        }

        /// <summary>
        /// Perform one traversing step on the graph.
        /// </summary>
        /// <param name="currentNode">The id of the node the traversing algorithm is currently at.</param>
        /// <returns>True if the traversing is taking place. False if the traversing has ended.</returns>
        public bool Traverse(out int currentNode)
        {
            if (nodeQueue.Count > 0)
            {
                currentNode = nodeQueue.Pop();
                visited[currentNode] = true;
                foreach (Edge edge in baseGraph.GetEdges(currentNode))
                {
                    nodeQueue.Push(edge.To);
                }
                return true;
            }
            else
            {
                currentNode = -1;
                return false;
            }
        }
    }
}
