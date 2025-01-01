using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public class Dijk_VertexState
    {
        public int vertex { get; set; }
        public bool isVisited { get; set; }
        public double Cost { get; set; }
        public string Path { get; set; }

        public Dijk_VertexState()
        {
            vertex = -1;
            isVisited = false;
            Cost = -1;
            Path = "";
        }
        public Dijk_VertexState(int vertex, bool isVisited, double cost, string path)
        {
            this.vertex = vertex;
            this.isVisited = isVisited;
            Cost = cost;
            Path = path;
        }

        public Dijk_VertexState(Dijk_VertexState X)
        {
            this.vertex = X.vertex;
            this.isVisited = X.isVisited;
            Cost = X.Cost;
            Path = X.Path;
        }
    }
    public class FormState
    {
        public string ThuTuDuyet {  get; set; }
        public Bitmap PrevBuffer {  get; set; }

        public bool isChosen {  get; set; }

        public Dijk_VertexState temp {  get; set; }
        public FormState(Bitmap buffer)
        {
            PrevBuffer = (Bitmap)buffer.Clone();
        }

        public FormState(Bitmap buffer, string X)
        {
            PrevBuffer = (Bitmap)buffer.Clone();
            ThuTuDuyet = X;
        }

        public FormState(Bitmap buffer, bool _isChosen)
        {
            PrevBuffer = (Bitmap)buffer.Clone();
            isChosen = _isChosen;
        }

        public FormState(Bitmap buffer, Dijk_VertexState X)
        {
            PrevBuffer = (Bitmap)buffer.Clone();
            temp = new Dijk_VertexState(X);
        }
    }
}
