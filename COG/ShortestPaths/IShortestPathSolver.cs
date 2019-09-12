using COG.Graphs;
using System;
using System.Collections.Generic;
using System.Text;

namespace COG.ShortestPaths
{
    /// <summary>
    /// Interface for Shortest Path solver.
    /// </summary>
    public interface IShortestPathSolver
    {
        /// <summary>
        /// Finds the shortest path between the start and end node.
        /// </summary>
        /// <param name="baseGraph">Graph containing the nodes.</param>
        /// <param name="endNode">End node id.</param>
        /// <param name="startNode">Start node id.</param>
        /// <returns>List of nodes representing the shortest path.</returns>
        List<int> Solve(BaseGraph baseGraph, int startNode, int endNode);
    }
}
