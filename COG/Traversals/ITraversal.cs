using COG.Graphs;
using System;
using System.Collections.Generic;
using System.Text;

namespace COG.Traversals
{
    /// <summary>
    /// Interface for graph traversal algorithms
    /// </summary>
    public interface ITraversal
    {
        /// <summary>
        /// Initialize the graph traversal with the starting node.
        /// </summary>
        /// <param name="graph">Graph to begin traversing.</param>
        /// <param name="startNode">Starting node for the traversal.</param>
        void Initialize(BaseGraph graph, int startNode);

        /// <summary>
        /// Traverses the graph one call at a time, returning false if the traversal has finished.
        /// </summary>
        /// <param name="currentNode">Returns the current node obtained during traversing.</param>
        /// <returns>True if traversing is taking place, false if traversing has ended.</returns>
        bool Traverse(out int currentNode);
    }
}
