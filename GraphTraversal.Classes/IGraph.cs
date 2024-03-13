namespace GraphTraversal.Classes
{
    public interface IGraph
    {
        // Returns true if there is an edge between start index and end index
        bool HasEdge(string startVertex, string endVertex);

        // Returns the neighbours of the vertex given
        List<string> Neighbours(string vertex);

        // Displays the graph in an appropriate way
        string Display();

        // Adds an edge to the graph       
        void AddEdge(string startIndex, string endIndex, double weight);       

        List<string> BreadthFirstSearch(string startVertex);

        List<string> DepthFirstSearch(string startVertex);

        List<string> DepthFirstSearchIterative(string startVertex);
    }
}