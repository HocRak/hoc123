using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class DFS
    {
        private int numNode;
        private bool[] visited;
        private List<int>[] linked;
        private List<(int, Point)> p;
        private int[] par;
        private List<(int, int)> Order = new List<(int, int)>();

        public int NumNode { get => numNode; set => numNode = value; }
        public bool[] Visited { get => visited; set => visited = value; }
        public List<int>[] Linked { get => linked; set => linked = value; }
        public List<(int, int)> Order1 { get => Order; set => Order = value; }

        public DFS(int n, List<int>[] L, List<(int, Point)> p)
        {
            numNode = n;
            visited = new bool[n];
            linked = L;
            this.p = p;
            par = new int[n];
            for (int i = 0; i < n; i++) par[i] = i;
        }

        public void Run(int src)
        {
            Stack<int> s = new Stack<int>();
            s.Push(src);
            visited[src] = true;
            {
                while (s.Count != 0)
                {
                    int u = s.Pop();
                    Order1.Add((u, par[u]));
                    foreach (int v in Linked[u])
                        if (!visited[v])
                        {
                            par[v] = u;
                            visited[v] = true;
                            s.Push(v);
                        }
                }
            }
        }
    }
}
