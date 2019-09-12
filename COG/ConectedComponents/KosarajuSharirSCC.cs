using COG.Graphs;
using COG.Representations;
using System.Collections.Generic;

namespace COG.ConectedComponents
{
    /// <summary>
    /// Strongly-Connected-Components Solver algorithm based on an algorithm proposed by Kosaraju and Sharir.
    /// </summary>
    public sealed class KosarajuSharirSCC : IConnectedComponentsSolver
    {
        /// <summary>
        /// The Solve
        /// </summary>
        /// <param name="baseGraph">The baseGraph<see cref="BaseGraph"/></param>
        /// <returns>The <see cref="List{Component}"/></returns>
        List<Component> IConnectedComponentsSolver.Solve(BaseGraph baseGraph)
        {
            List<Component> components = new List<Component>();
            /*
             * Get the transpose of the graph.
             */
            BaseGraph transposedGraph = new BaseGraph(new MatrixRepresentation(baseGraph.Nodes));
            baseGraph.GetTranspose(transposedGraph);

            bool[] visited = new bool[baseGraph.Nodes];
            for (int i = 0; i < baseGraph.Nodes; i++)
            {
                visited[i] = false;
            }
            Stack<int> orderStack = new Stack<int>();

            /*
             * Perform a DFS on the graph, keeping track of the order of the traversal.
             */
            for (int i = 0; i < baseGraph.Nodes; i++)
            {
                if (!visited[i])
                {
                    DFS1(visited, orderStack, i, baseGraph);
                }
            }

            for (int i = 0; i < baseGraph.Nodes; i++)
            {
                visited[i] = false;
            }
            Component component = null;
            /*
             * Perform now a DFS on the transpose of the graph, adding the node indices into components.
             */
            for (int i = 0; i < baseGraph.Nodes; i++)
            {
                int v = orderStack.Pop();
                if (!visited[v])
                {
                    component = new Component();
                    components.Add(component);
                    DFS2(visited, component, v, transposedGraph);
                }
            }
            return components;
        }

        /// <summary>
        /// The DFS1
        /// </summary>
        /// <param name="visited">The visited<see cref="bool[]"/></param>
        /// <param name="orderStack">The orderStack<see cref="Stack{int}"/></param>
        /// <param name="v">The v<see cref="int"/></param>
        /// <param name="baseGraph">The baseGraph<see cref="BaseGraph"/></param>
        private void DFS1(bool[] visited, Stack<int> orderStack, int v, BaseGraph baseGraph)
        {
            visited[v] = true;
            foreach (Edge edge in baseGraph.GetEdges(v))
            {
                if (!visited[edge.To])
                {
                    DFS1(visited, orderStack, edge.To, baseGraph);
                }
            }
            orderStack.Push(v);
        }

        /// <summary>
        /// The DFS2
        /// </summary>
        /// <param name="visited">The visited<see cref="bool[]"/></param>
        /// <param name="component">The component<see cref="Component"/></param>
        /// <param name="v">The v<see cref="int"/></param>
        /// <param name="transposeGraph">The transposeGraph<see cref="BaseGraph"/></param>
        private void DFS2(bool[] visited, Component component, int v, BaseGraph transposeGraph)
        {
            visited[v] = true;
            component.Nodes.Add(v);
            foreach (Edge e in transposeGraph.GetEdges(v))
            {
                if (!visited[e.To])
                {
                    DFS2(visited, component, e.To, transposeGraph);
                }
            }
        }
    }
}
