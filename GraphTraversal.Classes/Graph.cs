using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTraversal.Classes
{
    public class Graph : IGraph
    {
        // Represented as an adjacency list - dictionary of dictionaries
        private readonly Dictionary<string, Dictionary<string, double>> _graph = new();

        public bool ContainsVertex(string vertex)
        {
            return _graph.ContainsKey(vertex);
        }

		public void AddEdge(string startVertex, string endVertex, double weight = 1)
		{
			_graph.TryAdd(startVertex, []);
			_graph.TryAdd(endVertex, []);
			_graph[startVertex].TryAdd(endVertex, weight);
		}

		public List<string> BreadthFirstSearch(string startVertex)
        {
            HashSet<string> visited = [];
            List<string> path = [];
            Queue<string> queue = [];
            string currentVertex = startVertex;
            queue.Enqueue(currentVertex);
            visited.Add(currentVertex);
            path.Add(currentVertex);
            while (queue.Count > 0)
            {
                currentVertex = queue.Dequeue();
                foreach (string neighbour in _graph[currentVertex].Keys)
                {
                    if (!visited.Contains(neighbour))
                    {
                        queue.Enqueue(neighbour);
                        visited.Add(neighbour);
                        path.Add(neighbour);
                    }
                }
            }
            return path;
        }

        public List<string> DepthFirstSearch(string startVertex)
        {
            HashSet<string> visited = [];
            List<string> path = [];
            DepthFirstSearch(visited, path, startVertex);
            return path;
        }

        private void DepthFirstSearch(HashSet<string> visited, List<string> path, string vertex)
        {
            visited.Add(vertex);
            path.Add(vertex);
            foreach (string neighbour in _graph[vertex].Keys)
            {
                if (!visited.Contains(neighbour))
                {
                    DepthFirstSearch(visited, path, neighbour);
                }
            }
        }

        public List<string> DepthFirstSearchIterative(string startVertex)
        {
            HashSet<string> visited = [];
            Stack<string> stack = [];
            List<string> path = [];
            string currentVertex = startVertex;
            stack.Push(currentVertex);
            while (stack.Count > 0)
            {
                currentVertex = stack.Pop();
                if (!visited.Contains(currentVertex))
                {
                    visited.Add(currentVertex);
                    path.Add(currentVertex);
                }
                foreach (string neighbour in _graph[currentVertex].Keys)
                {
                    if (!visited.Contains(neighbour))
                    {
                        stack.Push(neighbour);
                    }
                }
            }
            return path;
        }

        public virtual string Display()
        {
            StringBuilder sb = new();
            foreach (var vertex in _graph)
            {
                string entry = $"{vertex.Key}: ";
                entry += "[";
                foreach (var adjacencyList in vertex.Value)
                {
                   entry += $"{adjacencyList.Key}:{adjacencyList.Value}, ";
                   
                }
                entry = entry.TrimEnd().TrimEnd(',');
                entry += "]\n";
                sb.Append(entry);
            }
            return sb.ToString();
        }

		public bool HasEdge(string startVertex, string endVertex)
		{
			bool hasEdge = false;
			if (_graph.TryGetValue(startVertex, out var adjacencyList))
			{
				hasEdge = adjacencyList.ContainsKey(endVertex);
			}
			return hasEdge;
		}

		public List<string> Neighbours(string vertex)
		{
			List<string> neighbours = [];
			if (_graph.TryGetValue(vertex, out var adjacencyList))
			{
				neighbours.AddRange(adjacencyList.Keys);
			}
			return neighbours;
		}
	}
}
