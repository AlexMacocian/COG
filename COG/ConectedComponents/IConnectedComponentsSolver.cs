using COG.Graphs;
using System.Collections.Generic;

namespace COG.ConectedComponents
{
    /// <summary>
    /// Interface for connected components solvers.
    /// </summary>
    public interface IConnectedComponentsSolver
    {
        /// <summary>
        /// Obtain a list of connected components in the graph.
        /// </summary>
        /// <param name="baseGraph">Graph to obtain connected components from.</param>
        /// <returns>List of components obtained from the graph.</returns>
        List<Component> Solve(BaseGraph baseGraph);
    }
}
