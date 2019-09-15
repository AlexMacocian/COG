using COG.Graphs;
using COG.Representations;
using COG.Traversals;
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
            DepthFirstSearch depthFirstSearch = new DepthFirstSearch();
            int n = baseGraph.Nodes;
            int curNode = -1;
            bool[] visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    depthFirstSearch.Initialize(baseGraph, i);
                    component = new Component();
                    components.Add(component);
                }
                while (depthFirstSearch.Traverse(out curNode))
                {
                    visited[curNode] = true;
                    component.Nodes.Add(curNode);
                }
            }
            return components;
        }
    }
}
