using QuickGraph;
using QuickGraph.Collections;
using QuickGraph.Serialization.DirectedGraphML;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class MyDijkstra
    {
        public int now_vertex;
        public int numNode;
        public double[] dist;
        public List<int>[] Paths;
        public FibonacciHeap<double, int> pq = new FibonacciHeap<double, int>();
        public bool[] isVisited;
        public MyDijkstra(int N, int src)
        {
            now_vertex = -1;
            numNode = N;
            //LinkedToVertex = new List<int>[numNode];
            dist = new double[numNode];
            Paths = new List<int>[numNode];
            isVisited = new bool[numNode];
            for (int i = 0; i < numNode; i++)
            {
                //LinkedToVertex[i] = new List<int>();
                dist[i] = int.MaxValue;
                Paths[i] = new List<int>();
                isVisited[i] = false;
            }
            dist[src] = 0;
            Paths[src].Add(src);
        }

        public MyDijkstra(MyDijkstra X)
        {
            now_vertex = X.now_vertex;
            numNode = X.numNode;
            dist = (double[])X.dist.Clone();
            Paths = (List<int>[])X.Paths.Clone();
            pq = X.pq;
            isVisited = (bool[])X.isVisited.Clone();
        }
    }
}
