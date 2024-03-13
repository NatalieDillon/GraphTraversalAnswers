using GraphTraversal.Classes;
using System.Collections.Generic;

namespace GraphTraversal.Tests
{
    [TestClass]
    public class TestGraph
    {
        private Graph CreateAndPopulateGraph1()
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
            graph.AddEdge("E", "D");
            graph.AddEdge("E", "H");
            graph.AddEdge("F", "B");
            graph.AddEdge("F", "G");
            graph.AddEdge("G", "C");
            graph.AddEdge("G", "F");
            graph.AddEdge("H", "E");
            graph.AddEdge("H", "I");
            graph.AddEdge("I", "H");
            return graph;
        }

        private Graph CreateAndPopulateGraph2()
        {
            Graph graph = new();
            graph.AddEdge("1", "2");
            graph.AddEdge("1", "9");
            graph.AddEdge("2", "1");
            graph.AddEdge("3", "4");
            graph.AddEdge("3", "5");
            graph.AddEdge("3", "6");
            graph.AddEdge("3", "9");
            graph.AddEdge("4", "3");
            graph.AddEdge("5", "3");
            graph.AddEdge("5", "8");
            graph.AddEdge("6", "3");
            graph.AddEdge("6", "7");
            graph.AddEdge("7", "6");
            graph.AddEdge("7", "8");
            graph.AddEdge("7", "9");

            graph.AddEdge("8", "5");
            graph.AddEdge("8", "7");
            graph.AddEdge("9", "1");
            graph.AddEdge("9", "3");
            graph.AddEdge("9", "7");
            return graph;
    }
        
        [TestMethod]
        public void TestBFS1FromA()
        {
            var graph = CreateAndPopulateGraph1();
            var expected = new List<string> { "A", "C", "E", "D", "G", "H", "F", "I", "B" };
            var result = graph.BreadthFirstSearch("A");
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestBFS1FromG()
        {
            var graph = CreateAndPopulateGraph1();
            var expected = new List<string> { "G", "C", "F", "A", "D", "B", "E", "H", "I" };
            var result = graph.BreadthFirstSearch("G");
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestDFS1FromA()
        {
            var graph = CreateAndPopulateGraph1();
            var expected = new List<string> { "A", "C", "D", "E", "H", "I", "G", "F", "B" };
            var result = graph.DepthFirstSearch("A");
            CollectionAssert.AreEqual(expected, result);
        }


        [TestMethod]
        public void TestIterativeDFS1FromA()
        {
            var graph = CreateAndPopulateGraph1();
            var expected = new List<string> { "A", "E", "H", "I", "D", "C", "G", "F", "B" };
            var result = graph.DepthFirstSearchIterative("A");
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestBFS2From1()
        {
            var graph = CreateAndPopulateGraph2();
            var expected = new List<string> { "1", "2", "9", "3", "7", "4", "5", "6", "8" };
            var result = graph.BreadthFirstSearch("1");
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestBFS2From5()
        {
            var graph = CreateAndPopulateGraph2();
            var expected = new List<string> { "5", "3", "8", "4", "6", "9", "7", "1", "2" };
            var result = graph.BreadthFirstSearch("5");
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestDFS2From1()
        {
            var graph = CreateAndPopulateGraph2();
            var expected = new List<string> { "1", "2", "9", "3", "4", "5", "8", "7", "6" };
            var result = graph.DepthFirstSearch("1");
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestDFS2From7()
        {
            var graph = CreateAndPopulateGraph2();
            var expected = new List<string> { "7", "6", "3", "4", "5", "8", "9", "1", "2" };
            var result = graph.DepthFirstSearch("7");
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestIterativeDFS2From1()
        {
            var graph = CreateAndPopulateGraph2();
            var expected = new List<string> { "1", "9", "7", "8", "5", "3", "6", "4", "2" };
            var result = graph.DepthFirstSearchIterative("1");
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestIterativeDFS2From7()
        {
            var graph = CreateAndPopulateGraph2();
            var expected = new List<string> { "7", "9", "3", "6", "5", "8", "4", "1", "2" };
            var result = graph.DepthFirstSearchIterative("7");
            CollectionAssert.AreEqual(expected, result);
        }
    }
}