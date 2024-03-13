using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTraversal.Classes
{
    public class Graph : IGraph
    {
        // Uses a dictionary of dictionaries
        private readonly Dictionary<string, Dictionary<string, double>> _graph = new();

        public virtual void AddEdge(string startVertex, string endVertex, double weight)
        {
            if (!_graph.ContainsKey(startVertex))
            {
                _graph.Add(startVertex, new());
            }
            var adjList = _graph[startVertex];
            if (!adjList.ContainsKey(endVertex))
            {
                adjList.Add(endVertex, weight);

            }
            if (!_graph.ContainsKey(endVertex))
            {
                _graph.Add(endVertex, new());
            }
        }

        public List<string> BreadthFirstSearch(string startVertex)
        {
            HashSet<string> visited = new();
            List<string> path = new();
            Queue<string> queue = new();
            string currentVertex = startVertex;
            queue.Enqueue(currentVertex);
            visited.Add(currentVertex);
            while (queue.Count > 0)
            {
                currentVertex = queue.Dequeue();
                path.Add(currentVertex);
                foreach (string neighbour in _graph[currentVertex].Keys)
                {
                    if (!visited.Contains(neighbour))
                    {
                        queue.Enqueue(neighbour);
                        visited.Add(neighbour);
                    }
                }
            }
            return path;
        }

        public List<string> DepthFirstSearch(string startVertex)
        {
            HashSet<string> visited = new();
            List<string> path = new();
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
            HashSet<string> visited = new();
            Stack<string> stack = new();
            List<string> path = new();
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
            if (_graph.ContainsKey(startVertex))
            {
                var values = _graph[startVertex];
                return values.Keys.FirstOrDefault(k => k.Equals(endVertex)) != null;
            }
            return false;
        }

        public List<string> Neighbours(string vertex)
        {
            List<string> neighbours = new();
            if (_graph.ContainsKey(vertex))
            {
                neighbours.AddRange(_graph[vertex].Keys);
            }
            return neighbours;
        }

       
    }
}
