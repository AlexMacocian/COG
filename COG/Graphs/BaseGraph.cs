using COG.ConectedComponents;
using COG.MinimumSpanningTree;
using COG.Representations;
using COG.ShortestPaths;
using System.Collections.Generic;

namespace COG.Graphs
{
    /// <summary>
    /// Base graph class.
    /// </summary>
    public class BaseGraph
    {
        /// <summary>
        /// Graph representation.
        /// </summary>
        protected BaseRepresentation representation;

        /// <summary>
        /// Solver for MST.
        /// </summary>
        protected IMSTSolver mstSolver;

        /// <summary>
        /// Solver for connected components.
        /// </summary>
        protected IConnectedComponentsSolver ccSolver;

        /// <summary>
        /// Solver for shortest paths.
        /// </summary>
        protected IShortestPathSolver spSolver;

        /// <summary>
        /// Gets or sets the Nodes.
        /// Number of nodes in the graph.
        /// </summary>
        public int Nodes { get => representation.Nodes; set => representation.Nodes = value; }

        /// <summary>
        /// Gets the Edges.
        /// Number of edges in the graph.
        /// </summary>
        public virtual int Edges { get => representation.Edges; }


        /// <summary>
        /// Gets or sets the edges of the graph.
        /// </summary>
        /// <param name="node1">Source node.</param>
        /// <param name="node2">Destination node.</param>
        /// <returns>Double value representing the cost of the searched edge.</returns>
        public virtual double this[int node1, int node2]
        {
            get => representation != null ? representation[node1, node2] : throw new MissingRepresentationException("Graph has no representation.");
            set
            {
                if (representation != null)
                {
                    representation[node1, node2] = value;
                }
                else
                {
                    throw new MissingRepresentationException("Graph has no representation.");
                }
            }
        }
        /// <summary>
        /// Gets or sets the MSTSolver.
        /// </summary>
        public IMSTSolver MSTSolver { get => mstSolver; set => mstSolver = value; }

        /// <summary>
        /// Gets or sets the ConnectedComponentsSolver.
        /// </summary>
        public IConnectedComponentsSolver ConnectedComponentsSolver { get => ccSolver; set => ccSolver = value; }

        /// <summary>
        /// Gets or sets the ShortestPathSolver.
        /// </summary>
        public IShortestPathSolver ShortestPathSolver { get => spSolver; set => spSolver = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseGraph"/> class.
        /// </summary>
        /// <param name="representation">Graph representation.</param>
        public BaseGraph(BaseRepresentation representation)
        {
            this.representation = representation;
        }

        /// <summary>
        /// Return the minimum spanning tree.
        /// </summary>
        /// <returns>List of edges defining the MST.</returns>
        public virtual List<Edge> GetMinimumSpanningTree()
        {
            if (mstSolver == null)
            {
                throw new MSTSolverMissingException("Graph doesn't have a solver for minimum spanning trees.");
            }
            else
            {
                return mstSolver.Solve(this);
            }
        }

        /// <summary>
        /// Return the components of the graph.
        /// </summary>
        /// <returns>List of all components.</returns>
        public virtual List<Component> GetConnectedComponents()
        {
            if (ccSolver != null)
            {
                return ccSolver.Solve(this);
            }
            else
            {
                throw new MissingConnectedComponentsSolverException("Graph doesn't have a solver for connected components.");
            }
        }

        /// <summary>
        /// Return shortest path between provided nodes.
        /// </summary>
        /// <param name="startNode">Starting node id.</param>
        /// <param name="endNode">Destination node id.</param>
        /// <returns>List sorted in the order from start to end.</returns>
        public virtual List<int> GetShortestPath(int startNode, int endNode)
        {
            if(spSolver != null)
            {
                return spSolver.Solve(this, startNode, endNode);
            }
            else
            {
                throw new MissingShortestPathsSolverException("Graph doesn't have a solver for shortest paths.");
            }
        }

        /// <summary>
        /// Add an edge to the graph.
        /// </summary>
        /// <param name="baseEdge">Structure containing the edge details.</param>
        public virtual void AddEdge(Edge baseEdge)
        {
            representation.AddEdge(baseEdge);
        }

        /// <summary>
        /// Remove edge from the graph.
        /// </summary>
        /// <param name="baseEdge">Structure containing the edge details.</param>
        public virtual void RemoveEdge(Edge baseEdge)
        {
            representation.RemoveEdge(baseEdge);
        }

        /// <summary>
        /// Get a list of all edges from given node id.
        /// </summary>
        /// <param name="nodeId">Id of given node.</param>
        /// <returns>List of all edges from given node.</returns>
        public virtual List<Edge> GetEdges(int nodeId)
        {
            return representation.GetEdges(nodeId);
        }

        /// <summary>
        /// Populate the provided <see cref="BaseGraph"/> with the transpose of current graph.
        /// </summary>
        /// <param name="transposeGraph">Graph to be populated with the transposed edges.</param>
        public virtual void GetTranspose(BaseGraph transposeGraph)
        {
            for (int i = 0; i < Nodes; i++)
            {
                foreach (Edge baseEdge in GetEdges(i))
                {
                    Edge baseEdgeT = new Edge(baseEdge.To, baseEdge.From, baseEdge.Cost);
                    transposeGraph.AddEdge(baseEdgeT);
                }
            }
        }
    }
}
