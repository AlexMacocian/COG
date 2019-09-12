using COG.Representations;

namespace COG.Graphs
{
    /// <summary>
    /// Class for directed graphs.
    /// </summary>
    public sealed class DirectedGraph : BaseGraph
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DirectedGraph"/> class.
        /// </summary>
        /// <param name="representation"></param>
        public DirectedGraph(BaseRepresentation representation) : base(representation)
        {
        }
    }
}
