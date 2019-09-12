using COG.Graphs;
using COG.Representations;
using System.Collections.Generic;

namespace COG.ConectedComponents
{
    /// <summary>
    /// Solver for connected components using a simple depth first search. To be used for undirected graphs
    /// as it is quicker than other specialized algorithms.
    /// </summary>
    public class DepthFirstSearchCC : IConnectedComponentsSolver
    {
        /// <summary>
        /// The Solve
        /// </summary>
        /// <param name="baseGraph">The baseGraph<see cref="BaseGraph"/></param>
        /// <returns>The <see cref="List{Component}"/></returns>
        List<Component> IConnectedComponentsSolver.Solve(BaseGraph baseGraph)
        {
            List<Component> components = new List<Component>();
            Component component = null;
            Stack<int> dfsStack = new Stack<int>();
            int n = baseGraph.Nodes;
            bool[] visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    dfsStack.Push(i);
                    component = new Component();
                    components.Add(component);
                }
                while (dfsStack.Count > 0)
                {
                    int currNode = dfsStack.Pop();
                    visited[currNode] = true;
                    component.Nodes.Add(currNode);
                    foreach (Edge e in baseGraph.GetEdges(currNode))
                    {
                        if (!visited[e.To])
                        {
                            dfsStack.Push(e.To);
                        }
                    }
                }
            }
            return components;
        }
    }
}
