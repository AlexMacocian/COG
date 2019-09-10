namespace COG.Representations
{
    /// <summary>
    /// Base structure for a node.
    /// </summary>
    public struct BaseNode
    {
        /// <summary>
        /// Id of node.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref=""/> class.
        /// </summary>
        /// <param name="id">Id of node.</param>
        public BaseNode(int id)
        {
            Id = id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <returns>True if nodes have the same id.</returns>
        public static bool operator ==(BaseNode node1, BaseNode node2)
        {
            return node1.Id == node2.Id;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <returns>True if nodes have different id.</returns>
        public static bool operator !=(BaseNode node1, BaseNode node2)
        {
            return node1.Id != node2.Id;
        }
        /// <summary>
        /// Returns true if the provided object has the same reference
        /// as this.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if reference is equal.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// The GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
