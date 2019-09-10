using COG.Representations;
using System;
using System.Collections.Generic;
using System.Text;

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
        /// <param name="representation">Representation of the graph.</param>
        /// <returns>List of edges defining the minimum spanning tree.</returns>
        List<BaseEdge> Solve(BaseRepresentation representation);
    }
}
