namespace GraphTraversal.Classes
{
    public interface IGraph
    {
        // Returns true if there is an edge between start vertex and end vertex
        bool HasEdge(string startVertex, string endVertex);

        // Returns true if the graph contains the vertex
        bool ContainsVertex(string vertex);

        // Returns the neighbours of the vertex given
        List<string> Neighbours(string vertex);

        // Displays the graph in an appropriate way
        string Display();

        // Adds an edge to the graph       
        void AddEdge(string startIndex, string endIndex, double weight=1);       

        List<string> BreadthFirstSearch(string startVertex);

        List<string> DepthFirstSearch(string startVertex);

        List<string> DepthFirstSearchIterative(string startVertex);
    }
}