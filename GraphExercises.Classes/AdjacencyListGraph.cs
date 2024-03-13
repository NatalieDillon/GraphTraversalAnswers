using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphExercises.Classes
{
    public class AdjacencyListGraph : IGraph
    {
        // Uses a dictionary of dictionaries
        private readonly Dictionary<string, Dictionary<string, double>> _graph = new();

        public void AddEdge(string startVertex, string endVertex, double weight)
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

        public string Display()
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

        public bool IsConnected(string startVertex, string endVertex)
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
