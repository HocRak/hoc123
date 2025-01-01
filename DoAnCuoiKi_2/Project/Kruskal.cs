
using System.Collections.Generic;

namespace Project
{
    internal class Kruskal_MST
    {
        static int numNode;
        static int[] parent;
        public List<Edge> Result;
        public List<Edge> Order1;

        public Kruskal_MST(int N)
        {
            numNode = N;
            parent = new int[N];
            Result = new List<Edge>();
            Order1 = new List<Edge>();
        }

        public int find(int i)
        {
            while (parent[i] != i)
                i = parent[i];
            return i;
        }

        public void kruskalMST(List<Edge> e)
        {
            double mincost = 0;
            for (int i = 0; i < numNode; i++)
                parent[i] = i;

            for (int i = 0; i < e.Count; i++)
            {
                Edge edge = e[i];
                int u = find(edge.Source);
                int v = find(edge.Target);
                Order1.Add(edge);
                if (u != v)
                {
                    Result.Add(edge);
                    mincost += edge.Weight;
                    parent[u] = v;
                }
            }
        }
    }
}
