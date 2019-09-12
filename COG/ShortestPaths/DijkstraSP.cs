using System;
using System.Collections.Generic;
using System.Text;
using COG.Graphs;
using COG.Representations;

namespace COG.ShortestPaths
{
    /// <summary>
    /// Class implementing Dijkstra's algorithm for shortest paths in a graph.
    /// </summary>
    public class DijkstraSP : IShortestPathSolver
    {
        List<int> IShortestPathSolver.Solve(BaseGraph baseGraph, int startNode, int endNode)
        {
            int n = baseGraph.Nodes;
            List<int> path = new List<int>();
            /*
             * Create a queue for the BFS exploration. First item in the tuple is the current node id, second item is the 
             * closest node to the current node and last item is the cost in the path.
             */ 
            Queue<Tuple<int, int, double>> bfsQueue = new Queue<Tuple<int, int, double>>();

            Tuple<int, int, double>[] pathCosts = new Tuple<int, int, double>[n];
            for(int i = 0; i < n; i++)
            {
                pathCosts[i] = new Tuple<int, int, double>(i, -1, double.MaxValue);
            }
            pathCosts[startNode] = new Tuple<int, int, double>(startNode, startNode, 0);
            foreach (Edge edge in baseGraph.GetEdges(startNode))
            {
                pathCosts[edge.To] = new Tuple<int, int, double>(edge.To, startNode, edge.Cost);
                bfsQueue.Enqueue(pathCosts[edge.To]);
            }

            while(bfsQueue.Count > 0)
            {
                Tuple<int, int, double> tuple = bfsQueue.Dequeue();
                int nodeId = tuple.Item1;
                int closestNodeId = tuple.Item2;
                double cost = tuple.Item3;
                foreach(Edge edge in baseGraph.GetEdges(nodeId))
                {
                    if(pathCosts[edge.To].Item3 > cost + edge.Cost)
                    {
                        pathCosts[edge.To] = new Tuple<int, int, double>(edge.To, nodeId, cost + edge.Cost);
                        bfsQueue.Enqueue(pathCosts[edge.To]);
                    }
                }
            }

            if(pathCosts[endNode].Item2 == -1)
            {
                throw new NoPathFoundException("No path found from node id {" + startNode + "} to node id {" + endNode + "}");
            }
            else
            {
                int curNode = endNode;
                while(curNode != startNode)
                {
                    path.Add(curNode);
                    curNode = pathCosts[curNode].Item2;
                }
                path.Add(startNode);
                path.Reverse();
                return path;
            }
        }
    }
}
