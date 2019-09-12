using COG.Graphs;
using COG.Representations;
using System.Collections.Generic;

namespace COG.MinimumSpanningTree
{
    /// <summary>
    /// Interface for Minimum Spanning Tree solver.
    /// </summary>
    public interface IMSTSolver
    {
        /// <summary>
        /// Obtain the minimum spanning tree.
        /// </summary>
        /// <param name="baseGraph">Graph to perform MST on.</param>
        /// <returns>List of edges defining the minimum spanning tree.</returns>
        List<Edge> Solve(BaseGraph baseGraph);
    }
}
