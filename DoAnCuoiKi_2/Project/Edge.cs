using QuickGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Edge : IEdge<int>, IComparable<Edge>
    {
        public int Source { get; set; }
        public int Target { get; set; }
        public double Weight { get; set; }

        public int CompareTo(Edge other)
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }
}
