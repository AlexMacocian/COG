namespace COG.Representations
{
    /// <summary>
    /// Bas edge structure holding edge values.
    /// </summary>
    public struct Edge
    {
        /// <summary>
        /// Gets or sets the From.
        /// Id of source node.
        /// </summary>
        public int From { get; set; }

        /// <summary>
        /// Gets or sets the To.
        /// Id of destination node.
        /// </summary>
        public int To { get; set; }

        /// <summary>
        /// Gets or sets the Cost.
        /// Cost of the edge.
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref=""/> class.
        /// </summary>
        /// <param name="from">ID of source node.</param>
        /// <param name="to">ID of destination node.</param>
        /// <param name="cost">Cost of edge.</param>
        public Edge(int from, int to, double cost)
        {
            From = from;
            To = to;
            Cost = cost;
        }
    }
}
