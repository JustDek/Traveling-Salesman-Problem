using System;
using System.Collections.Generic;

namespace BinaryOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph gr = new Graph(4);
            gr.AddEdge(1, 2, 10);
            gr.AddEdge(2, 4, 25);
            gr.AddEdge(2, 3, 35);
            gr.AddEdge(4, 3, 30);
            gr.AddEdge(1, 4, 20);
            gr.AddEdge(1, 3, 15);

            gr.nodes.Remove(0);
            int res = TSP(0, gr.nodes, gr);
            Console.WriteLine(res);
        }

        public static int TSP(int current, List<int> points, Graph gr, int prev = -1)
        {
            List<int> weights = new List<int>();

            if (points.Count < 1)
            {
                return gr.adjacencyMatrix[current, 0];
            }

            foreach (int point in points)
            {
                List<int> _points = new List<int>(points);
                _points.Remove(point);
                weights.Add(gr.adjacencyMatrix[current, point] + TSP(point, _points, gr, current));
            }

            weights.Sort();

            return weights[0];
        }
    }

    class Graph
    {
        public int[,] adjacencyMatrix;
        public List<int> nodes;

        public Graph(int len)
        {
            adjacencyMatrix = new int[len, len];
            nodes = new List<int>();
            fullMatrix(adjacencyMatrix, len);
            
        }

        public void AddEdge(int fromNode, int toNode, int weight)
        {
            if (fromNode != toNode)
            {
                adjacencyMatrix[fromNode - 1, toNode - 1] = weight;
                adjacencyMatrix[toNode - 1, fromNode - 1] = weight;
            }
        }

        private void fullMatrix(int[,] matrix, int len)
        {
            for (int i = 0; i < len; i++)
            {
                nodes.Add(i);
                for (int j = 0; j < len; j++)
                {
                    matrix[i, j] = 0;
                }
            }
        } 
    }
}
