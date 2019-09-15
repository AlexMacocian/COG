using System;
using System.Collections.Generic;
using System.Text;
using COG.Graphs;
using COG.Representations;

namespace COG.Traversals
{
    /// <summary>
    /// BFS algorithm for graph traversing.
    /// </summary>
    public class BreadthFirstSearch : ITraversal
    {
        private BaseGraph baseGraph;
        private Queue<int> nodeQueue;
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
            nodeQueue = new Queue<int>();
            nodeQueue.Enqueue(startNode);
        }

        /// <summary>
        /// Perform one traversing step on the graph.
        /// </summary>
        /// <param name="currentNode">The id of the node the traversing algorithm is currently at.</param>
        /// <returns>True if the traversing is taking place. False if the traversing has ended.</returns>
        public bool Traverse(out int currentNode)
        {
            if(nodeQueue.Count > 0)
            {
                currentNode = nodeQueue.Dequeue();
                while(visited[currentNode] != false)
                {
                    if(nodeQueue.Count > 0)
                    {
                        currentNode = nodeQueue.Dequeue();
                    }
                    else
                    {
                        return false;
                    }                
                }
                visited[currentNode] = true;
                foreach(Edge edge in baseGraph.GetEdges(currentNode))
                {
                    if (!visited[edge.To])
                    {
                        nodeQueue.Enqueue(edge.To);
                    }
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
