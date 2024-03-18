using System.Diagnostics;
using System.Linq;
using GraphTraversal.Classes;

namespace GraphTraversal
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, Graph!");

            Console.WriteLine();
            TestGraph();

        }

        private static void TestGraph()
        {
            Graph graph = new();
            graph.AddEdge("A", "C");
            graph.AddEdge("A", "E");
            graph.AddEdge("B", "F");
            graph.AddEdge("C", "A");
            graph.AddEdge("C", "D");
            graph.AddEdge("C", "G");
            graph.AddEdge("D", "C");
            graph.AddEdge("D", "E");
            graph.AddEdge("E", "A");
            graph.AddEdge("E", "D");
            graph.AddEdge("E", "H");
            graph.AddEdge("F", "B");
            graph.AddEdge("F", "G");
            graph.AddEdge("G", "C");
            graph.AddEdge("G", "F");
            graph.AddEdge("H", "E");
            graph.AddEdge("H", "I");
            graph.AddEdge("I", "H");

            Console.WriteLine(graph.Display());

            Console.Write("From which vertex would you like to traverse the graph? : ");
            string vertex = Console.ReadLine() ?? string.Empty;
            if (!graph.ContainsVertex(vertex))
            {
                Console.WriteLine("Sorry that vertex does not exist");
            }
            else
            {
                Console.WriteLine($"BFS: [{string.Join(",", graph.BreadthFirstSearch(vertex))}]");
                Console.WriteLine($"DFS: [{string.Join(",", graph.DepthFirstSearch(vertex))}]");
                Console.WriteLine($"DFS (iterative): [{string.Join(",", graph.DepthFirstSearchIterative(vertex))}]");
            }

        }
    }
}