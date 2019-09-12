using System.Collections.Generic;

namespace COG.ConectedComponents
{
    /// <summary>
    /// Class to contain the list of nodes belonging to the same component.
    /// </summary>
    public sealed class Component
    {
        /// <summary>
        /// Defines the nodes
        /// </summary>
        private List<int> nodes = new List<int>();

        /// <summary>
        /// Gets or sets the Nodes
        /// </summary>
        public List<int> Nodes { get => nodes; set => nodes = value; }
    }
}
