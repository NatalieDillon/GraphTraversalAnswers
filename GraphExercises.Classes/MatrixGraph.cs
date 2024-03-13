using System.Text;

namespace GraphExercises.Classes
{
    public class MatrixGraph : IGraph
    {
        private readonly List<string> _vertices = new();
        private readonly double[,] _edges;
        private readonly int _capacity = 100;
              
        public MatrixGraph()
        {
            _edges = new double[_capacity, _capacity];
            InitialiseArray();
        }

        private void InitialiseArray()
        {
            for (int i = 0; i < _capacity; i++)
            {
                for (int j = 0; j < _capacity; j++)
                {
                    _edges[i, j] = -1;
                }
            }
        }

        public void AddEdge(string startVertex, string endVertex, double weight)
        {
            int startIndex = CheckAndAddVertex(startVertex);
            int endIndex = CheckAndAddVertex(endVertex);
            _edges[startIndex, endIndex] = weight;
        }

        private int CheckAndAddVertex(string vertex)
        {
            int index = _vertices.IndexOf(vertex);
            if (index == -1)
            {
                if (_vertices.Count >= _capacity)
                {
                    throw new InvalidOperationException("Matrix is full");
                }
                _vertices.Add(vertex);
                index = _vertices.Count - 1;
            }
            return index;
        }

        public string Display()
        {
            StringBuilder sb = new();
            int columnWidth = _vertices.Max(name => name.Length);
            columnWidth = columnWidth < 6 ? 6 : columnWidth;
            sb.Append(new string(' ', columnWidth + 3));
            foreach (string s in _vertices)
            {
                sb.Append($" {s.PadLeft(columnWidth)}  ");
            }
            sb.Append('\n');
            for (int i = 0; i < _vertices.Count; i++)
            {
                sb.Append($" {_vertices[i].PadLeft(columnWidth)}  ");
                for (int j = 0; j < _vertices.Count; j++)
                {
                    sb.Append($" {_edges[i, j].ToString().PadLeft(columnWidth)}  ");
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }

        public bool IsConnected(string startVertex, string endVertex)
        {
            int startIndex = _vertices.IndexOf(startVertex);
            int endIndex = _vertices.IndexOf(endVertex);
            if (startIndex != -1 && endIndex != -1)
            {
                return _edges[startIndex, endIndex] != -1;
            }
            return false;
        }

        public List<string> Neighbours(string vertex)
        {
            List<string> nodes = new();
            int startIndex = _vertices.IndexOf(vertex);
            if (startIndex != -1)
            {
                for (int i = 0; i < _vertices.Count; i++)
                {
                    if (_edges[startIndex, i] != -1)
                    {
                        nodes.Add(_vertices[i]);
                    }
                }
            }
            return nodes;
        }

    }
}
