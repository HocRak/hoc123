using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuickGraph;

namespace Project
{
    public partial class dothi : Form
    {
        private List<FormState> History = new List<FormState>();

        Random random = new Random();
        private AdjacencyGraph<int, Edge> UndirectedGraph = new AdjacencyGraph<int, Edge>();
        private AdjacencyGraph<int, Edge> DirectedGraph = new AdjacencyGraph<int, Edge>();
        private List<(int, Point)> position = new List<(int, Point)>();
        private int diameter = 40;
        private Bitmap buffer;
        private string ThuTuDuyet;
        private bool isUndirected = false;
        private bool isDirected = false;
        private bool isWeight = false;
        private List<int>[] LinkedToUnVertex;
        private List<int>[] LinkedToDiVertex;
        private int NumNode = 100;
        private List<(int, int)> Order = new List<(int, int)>();
        private List<Edge> Sorted_Edge = new List<Edge>();
        private List<Edge> result = new List<Edge>();
        private int index = 0;
        private int start_vertex = -1;
        private int index_FormState = 0;
        private int speed;
        private CancellationTokenSource cts;
        private Task currentTask;

        public class Algo_Status
        {
            public bool isBFS;
            public bool isDFS;
            public bool isKruskal;
            public bool isDijkstra;

            public Algo_Status()
            {
                isBFS = false;
                isDFS = false;
                isKruskal = false;
                isDijkstra = false;
            }
        }

        MyDijkstra Dijk;
        Algo_Status Status;

        public List<(int, Point)> Position { get => Position1; set => Position1 = value; }
        public List<FormState> History1 { get => History; set => History = value; }
        public List<(int, Point)> Position1 { get => position; set => position = value; }
        public AdjacencyGraph<int, Edge> UndirectedGraph1 { get => UndirectedGraph; set => UndirectedGraph = value; }
        public AdjacencyGraph<int, Edge> DirectedGraph1 { get => DirectedGraph; set => DirectedGraph = value; }
        public Bitmap Buffer { get => buffer; set => buffer = value; }
        public List<int>[] LinkedToUnVertex1 { get => LinkedToUnVertex; set => LinkedToUnVertex = value; }
        public List<int>[] LinkedToDiVertex1 { get => LinkedToDiVertex; set => LinkedToDiVertex = value; }
        public bool IsDirected { get => isDirected; set => isDirected = value; }

        public dothi()
        {
            InitializeComponent();
        }

        public Point calc(Point p1, Point p2)
        {
            double a = (double)(p1.Y - p2.Y) / (p1.X - p2.X);
            double b = (double)p1.Y - a * p1.X;
            int x;
            double p = 0.75;
            double z = 0.25;
            if (p1.X > p2.X)
                x = (int)(p2.X + z * (p1.X - p2.X));
            else
                x = (int)(p1.X + p * (p2.X - p1.X));
            return new Point(x, (int)(x * a + b));
        }
        public void DrawArrowhead(Graphics g, Pen pen, Point startPoint, Point endPoint, int arrowLength, int arrowWidth)
        {

            // Tính toán các điểm của mũi tên
            float angle = (float)Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
            float rad = (float)Math.PI / 180.0f;
            Point intersect = calc(startPoint, endPoint);

            PointF[] points =
            {
            intersect,
            new PointF(intersect.X - arrowLength * (float)Math.Cos(angle - 30 * rad),
                       intersect.Y - arrowLength * (float)Math.Sin(angle - 30 * rad)),
            new PointF(intersect.X - arrowLength * (float)Math.Cos(angle + 30 * rad),
                       intersect.Y - arrowLength * (float)Math.Sin(angle + 30 * rad))
            };

            // Vẽ mũi tên
            g.FillPolygon(pen.Brush, points);
        }
        public bool isOverlapped(Point newCenter)
        {
            foreach (var item in Position)
            {
                Point p = item.Item2;
                double distance = Math.Sqrt(Math.Pow(p.X - newCenter.X, 2) + Math.Pow(p.Y - newCenter.Y, 2));
                if (distance <= diameter + 25)
                    return true;
            }
            return false;
        }

        private void init(int vertex)
        {
            Point temp = getPosition(vertex, Position);
            if (temp == new Point(-1, -1))
            {
                while (true)
                {
                    int x = random.Next(grBDoThi.Width - diameter);
                    int y = random.Next(grBDoThi.Height - diameter);
                    Point newCenter = new Point();
                    newCenter.X = x + diameter / 2;
                    newCenter.Y = y + diameter / 2;
                    if (!isOverlapped(newCenter))
                    {
                        Position.Add((vertex, newCenter));
                        break;
                    }

                }
            }
        }

        private void Update(int u, int v, double w)
        {
            Graphics bufferGraphics = Graphics.FromImage(Buffer);
            Point Source = getPosition(u, Position);
            Point Target = getPosition(v, Position);

            DrawEdge(Source, Target, bufferGraphics, Pens.Black);
            DrawVertex(Source, bufferGraphics, Brushes.Blue);
            DrawVertex(Target, bufferGraphics, Brushes.Blue);

            DrawNumber(u.ToString(), Source, bufferGraphics);
            DrawNumber(v.ToString(), Target, bufferGraphics);
            if (IsDirected)
                DrawArrowhead(bufferGraphics, new Pen(Color.Black, 3), Source, Target, 20, 20);
            if (isWeight)
                DrawWeight(Source, Target, w.ToString(), bufferGraphics);
        }

        private void ReDraw()
        {
            Buffer = new Bitmap(grBDoThi.Width, grBDoThi.Height);
            using (Graphics bufferGraphics = Graphics.FromImage(Buffer))
            {
                Point Source = new Point();
                Point Target = new Point();
                if (isUndirected)
                {
                    foreach (var edge in UndirectedGraph1.Edges)
                    {
                        Source = getPosition(edge.Source, Position);
                        Target = getPosition(edge.Target, Position);

                        DrawEdge(Source, Target, bufferGraphics, Pens.Black);
                        DrawVertex(Source, bufferGraphics, Brushes.Blue);
                        DrawVertex(Target, bufferGraphics, Brushes.Blue);

                        DrawNumber(edge.Source.ToString(), Source, bufferGraphics);
                        DrawNumber(edge.Target.ToString(), Target, bufferGraphics);
                        if (isWeight)
                            DrawWeight(Source, Target, edge.Weight.ToString(), bufferGraphics);
                    }
                }

                if (IsDirected)
                {
                    foreach (var edge in DirectedGraph1.Edges)
                    {
                        Source = getPosition(edge.Source, Position);
                        Target = getPosition(edge.Target, Position);

                        DrawEdge(Source, Target, bufferGraphics, Pens.Black);
                        DrawVertex(Source, bufferGraphics, Brushes.Blue);
                        DrawVertex(Target, bufferGraphics, Brushes.Blue);

                        DrawNumber(edge.Source.ToString(), Source, bufferGraphics);
                        DrawNumber(edge.Target.ToString(), Target, bufferGraphics);
                        DrawArrowhead(bufferGraphics, Pens.Black, Source, Target, 20, 20);
                        if (isWeight)
                            DrawWeight(Source, Target, edge.Weight.ToString(), bufferGraphics);
                    }
                }
            }
        }

        private void grBDoThi_Paint(object sender, PaintEventArgs e)
        {
            bool ok = isUndirected | IsDirected;
            if (ok)
            {
                Graphics g = e.Graphics;

                g.DrawImage(Buffer, 0, 0);
                g.Dispose();
            }
        }

        public void DrawVertex(Point Pos, Graphics g, Brush brush)
        {
            g.FillEllipse(brush, Pos.X - diameter / 2, Pos.Y - diameter / 2, diameter, diameter);
        }

        public void DrawEdge(Point Source, Point Target, Graphics g, Pen pen)
        {
            g.DrawLine(pen, Source, Target);
        }

        public void DrawWeight(Point Source, Point Target, string weight, Graphics g)
        {
            Font font = new Font("Arial", 12, FontStyle.Regular);
            int x1 = Source.X;
            int y1 = Source.Y;
            int x2 = Target.X;
            int y2 = Target.Y;


            double t = 0.5;
            int x = (int)(x1 + t * (x2 - x1));
            int y = (int)(y1 + t * (y2 - y1));

            // Vẽ chuỗi tại mỗi điểm, xoay theo góc của đường thẳng
            g.TranslateTransform(x, y);
            //g.RotateTransform((float)angle);
            g.DrawString(weight, font, Brushes.Black, 0, 0);
            g.ResetTransform();
        }
        public void DrawNumber(string stringNumber, Point Num, Graphics g)
        {
            g.DrawString(stringNumber, new Font("Arial", 16), Brushes.Black, Num.X - diameter / 4, Num.Y - diameter / 3);
        }
        public Point getPosition(int vertex, List<(int, Point)> Position)
        {
            foreach (var p in Position)
            {
                if (p.Item1 == vertex)
                    return p.Item2;
            }

            return new Point(-1, -1);
        }


        private void BFS()
        {
            List<int>[] linked;
            linked = IsDirected ? (List<int>[])LinkedToDiVertex1.Clone() : (List<int>[])LinkedToUnVertex1.Clone();
            BFS bfs = new BFS(NumNode, linked, Position);
            ThuTuDuyet = "";
            
            if (!IsDirected && !isUndirected)
                MessageBox.Show("Bạn chưa chọn loại đồ thị!");
            else
            {
                try
                {
                    lbTitle.Text = "BFS";
                    start_vertex = int.Parse(tSTBDinh.Text.Trim());
                    groupBox1.Visible = true;
                    bfs.Run(start_vertex);
                    Order = bfs.Order1;
                    backgroundWorker1.RunWorkerAsync();
                }
                catch
                {
                    MessageBox.Show("Bạn chưa chọn đỉnh bắt đầu!");
                }

            }
        }

        private void DFS()
        {
            List<int>[] linked;
            linked = IsDirected ? (List<int>[])LinkedToDiVertex1.Clone() : (List<int>[])LinkedToUnVertex1.Clone();
            DFS dfs = new DFS(NumNode, linked, Position);
            ThuTuDuyet = "";

            if (!IsDirected && !isUndirected)
                MessageBox.Show("Bạn chưa chọn loại đồ thị!");
            else
            {
                try
                {
                    start_vertex = int.Parse(tSTBDinh.Text.Trim());
                    lbTitle.Text = "DFS";
                    groupBox1.Visible = true;
                    dfs.Run(start_vertex);
                    Order = dfs.Order1;
                    backgroundWorker1.RunWorkerAsync();
                }

                catch
                {
                    MessageBox.Show("Bạn chưa chọn đỉnh bắt đầu!");
                }
            }
        }


        private void BFSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Status = new Algo_Status();
            Status.isBFS = true;
            dataGridView1.Visible = false;
            listView1.Visible = false;
            BFS();
        }


        private void DFSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Status = new Algo_Status();
            Status.isDFS = true;
            dataGridView1.Visible = false;
            listView1.Visible = false;
            DFS();
        }

        private void tSBThem_Click(object sender, EventArgs e)
        {
            try
            {
                //Them du lieu vao lsvDSCanh
                string stringEdge = tSTBCanh.Text.Trim();
                tSTBCanh.Text = null;

                string[] splits = stringEdge.Split(' ');
                //Them dinh va canh vao do thi
                int u = int.Parse(splits[0]);
                int v = int.Parse(splits[1]);
                //Xac dinh w
                double w = 0;
                if (splits.Length > 2)
                    w = double.Parse(splits[2]);

                LinkedToUnVertex1[u].Add(v);
                LinkedToUnVertex1[v].Add(u);
                LinkedToDiVertex1[u].Add(v);

                ListViewItem item = new ListViewItem(stringEdge);
                lsvDSCanh.Items.Add(item);
                UndirectedGraph1.AddVertex(u);
                UndirectedGraph1.AddVertex(v);
                UndirectedGraph1.AddEdge(new Edge { Source = u, Target = v, Weight = w });
                UndirectedGraph1.AddEdge(new Edge { Source = v, Target = u, Weight = w });

                DirectedGraph1.AddVertex(u);
                DirectedGraph1.AddVertex(v);
                DirectedGraph1.AddEdge(new Edge { Source = u, Target = v, Weight = w });

                init(u);
                init(v);
                Update(u, v, w);

                ListView lst = new ListView();
                foreach (ListViewItem Item in lsvDSCanh.Items)
                {
                    ListViewItem newItem = (ListViewItem)Item.Clone();
                    lst.Items.Add(newItem);
                }

                grBDoThi.Invalidate();
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng (a' 'b' 'c) hoặc (a' 'b)!\n\n" + "Đỉnh tối đa là 100!");
            }
        }

        private void tSBXoa_Click(object sender, EventArgs e)
        {
            if (lsvDSCanh.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lsvDSCanh.SelectedItems)
                {
                    lsvDSCanh.Items.Remove(item);
                    string stringEdge = item.SubItems[0].Text.Trim();
                    string[] splits = stringEdge.Split(' ');
                    int Source = int.Parse(splits[0]);
                    int Target = int.Parse(splits[1]);

                    //Xóa cạnh vô hướng
                    var edgeToRemove = UndirectedGraph1.Edges.FirstOrDefault(edge => edge.Source == Source && edge.Target == Target);
                    UndirectedGraph1.RemoveEdge(edgeToRemove);
                    edgeToRemove = UndirectedGraph1.Edges.FirstOrDefault(edge => edge.Source == Target && edge.Target == Source);
                    UndirectedGraph1.RemoveEdge(edgeToRemove);

                    if (!UndirectedGraph1.ContainsVertex(Source) || !UndirectedGraph1.ContainsVertex(Target))
                    {
                        UndirectedGraph1.RemoveVertex(Source);
                        UndirectedGraph1.RemoveVertex(Target);
                        Position.Remove((Source, getPosition(Source, Position)));
                        Position.Remove((Target, getPosition(Target, Position)));
                    }
                    else
                    {
                        var LinkedToSource = UndirectedGraph1.Edges.Where(ed => ed.Source == Source || ed.Target == Source);
                        var LinkedToTarget = UndirectedGraph1.Edges.Where(ed => ed.Source == Target || ed.Target == Target);
                        if (!LinkedToSource.Any())
                        {
                            UndirectedGraph1.RemoveVertex(Source);
                            Position.Remove((Source, getPosition(Source, Position)));
                        }
                        if (!LinkedToTarget.Any())
                        {
                            UndirectedGraph1.RemoveVertex(Target);
                            Position.Remove((Target, getPosition(Target, Position)));
                        }
                    }

                    //Xóa cạnh có hướng
                    edgeToRemove = DirectedGraph1.Edges.FirstOrDefault(edge => edge.Source == Source && edge.Target == Target);
                    DirectedGraph1.RemoveEdge(edgeToRemove);

                    if (!DirectedGraph1.ContainsVertex(Source) || !DirectedGraph1.ContainsVertex(Target))
                    {
                        DirectedGraph1.RemoveVertex(Source);
                        DirectedGraph1.RemoveVertex(Target);
                        Position.Remove((Source, getPosition(Source, Position)));
                        Position.Remove((Target, getPosition(Target, Position)));
                    }
                    else
                    {
                        var LinkedToSource = DirectedGraph1.Edges.Where(ed => ed.Source == Source || ed.Target == Source);
                        var LinkedToTarget = DirectedGraph1.Edges.Where(ed => ed.Source == Target || ed.Target == Target);
                        if (!LinkedToSource.Any())
                        {
                            DirectedGraph1.RemoveVertex(Source);
                            Position.Remove((Source, getPosition(Source, Position)));
                        }
                        if (!LinkedToTarget.Any())
                        {
                            DirectedGraph1.RemoveVertex(Target);
                            Position.Remove((Target, getPosition(Target, Position)));
                        }
                    }
                }
            }
            ReDraw();
            grBDoThi.Invalidate();
        }

        private void ĐỒ_THỊ_Load(object sender, EventArgs e)
        {
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 5;
            trackBar1.Value = 2;
            trackBar1.TickFrequency = 1;
            LinkedToUnVertex1 = new List<int>[NumNode];
            LinkedToDiVertex1 = new List<int>[NumNode];
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            for (int i = 0; i < NumNode; i++)
            {
                LinkedToUnVertex1[i] = new List<int>();
                LinkedToDiVertex1[i] = new List<int>();
            }
            Buffer = new Bitmap(grBDoThi.Width, grBDoThi.Height);

            btnStepBack.Enabled = false;
            btnStepForward.Enabled = false;
        }

        private void rBVoHuong_CheckedChanged(object sender, EventArgs e)
        {
            isUndirected = !isUndirected;
            if (isUndirected)
            {
                ReDraw();
                grBDoThi.Invalidate();
            }
        }

        private void rBCoHuong_CheckedChanged(object sender, EventArgs e)
        {
            IsDirected = !IsDirected;
            if (IsDirected)
            {
                ReDraw();
                grBDoThi.Invalidate();
            }
        }

        private void btnSkipBack_Click(object sender, EventArgs e)
        {
            try
            {
                cts.Cancel();
                index_FormState = 0;
                FormState tmp = History1[0];
                using (Graphics g = grBDoThi.CreateGraphics())
                {
                    g.DrawImage(tmp.PrevBuffer, 0, 0);
                }

                showDataGridView(isDirected ? DirectedGraph : UndirectedGraph);
                lbThuTuDuyet.Text = "";
                foreach (ListViewItem item in listView1.Items)
                {
                    item.ForeColor = Color.Black;
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn thuật toán trước!");
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (btnPause.Text == "Pause")
            {
                btnPause.Text = "Continue";
                btnPause.ForeColor = Color.Red;
                btnStepBack.Enabled = true;
                btnStepForward.Enabled = true;
                if(cts != null) cts.Cancel();
                currentTask = null;
                index_FormState--;
            }
            else
            {
                btnPause.Text = "Pause";
                btnPause.ForeColor = Color.Blue;
                btnStepBack.Enabled = false;
                btnStepForward.Enabled = false;
                if (currentTask == null || currentTask.IsCompleted || currentTask.IsCanceled)
                {
                    cts = new CancellationTokenSource();
                    currentTask = Task.Run(() => Visualize(cts.Token));
                }
            }
        }

        private async Task Visualize(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (index_FormState >= History1.Count)
                    break;
                FormState formState = History1[index_FormState];
                this.Invoke(new Action(() =>
                {
                    lbThuTuDuyet.Text = formState.ThuTuDuyet;
                    if (formState.isChosen)
                        listView1.Items[index_FormState - 1].ForeColor = Color.Red;
                    using (Graphics g = grBDoThi.CreateGraphics())
                    {
                        g.DrawImage(formState.PrevBuffer, 0, 0);
                    }

                    Dijk_VertexState X = formState.temp;
                    if (X != null)
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == X.vertex.ToString())
                            {
                                row.Cells[1].Value = X.isVisited;
                                row.Cells[2].Value = X.Cost;
                                row.Cells[3].Value = X.Path;
                            }
                        }
                    }
                }));
                index_FormState++;
                try
                {
                    await Task.Delay(speed, token);
                }
                catch
                {
                }
            }
        }
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            speed = trackBar1.Value * 500;
        }

        private void dijkstraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showDataGridView(IsDirected ? DirectedGraph1 : UndirectedGraph1);
            Status = new Algo_Status();
            Status.isDijkstra = true;
            groupBox1.Visible = false;
            listView1.Visible = false;
            Dijkstra();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            isWeight = !isWeight;
            ReDraw();
            grBDoThi.Invalidate();
        }

        private void showDataGridView(AdjacencyGraph<int, Edge> graph)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Vertex");
            dt.Columns.Add("IsVisited");
            dt.Columns.Add("Cost");
            dt.Columns.Add("Path");

            foreach (int vertex in graph.Vertices)
            {
                DataRow row = dt.NewRow();
                row["Vertex"] = vertex;
                row["IsVisited"] = "F";
                row["Cost"] = "INF";
                row["Path"] = "-1";
                dt.Rows.Add(row);
            }

            dataGridView1.DataSource = dt;

        }

        private string showPath(int v, MyDijkstra X)
        {
            string result = "";
            foreach (int u in X.Paths[v])
            {
                result += u.ToString() + " ";
            }

            return result;
        }
        private void Dijkstra()
        {
            try
            {
                start_vertex = int.Parse(tSTBDinh.Text.Trim());
                lbTitle.Text = "Dijkstra";
                dataGridView1.Visible = true;
                Dijk = new MyDijkstra(NumNode, start_vertex);
                Dijk.pq.Enqueue(-1, start_vertex);
                backgroundWorker1.RunWorkerAsync();
            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn đỉnh bắt đầu!");
            }
        }

        private void kruskalMSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Status = new Algo_Status();
            Status.isKruskal = true;
            lbTitle.Text = "Kruskal";
            groupBox1.Visible = false;
            dataGridView1.Visible = false;
            listView1.Clear();
            listView1.Visible = true;
            kruskal_MST();
        }

        private void kruskal_MST()
        {
            Kruskal_MST kruskal = new Kruskal_MST(NumNode);
            Sorted_Edge.Clear();
            index = 0;
            while (true)
            {
                if (index >= lsvDSCanh.Items.Count)
                {
                    index = 0;
                    break;
                }
                string temp = lsvDSCanh.Items[index++].Text.ToString();
                string[] splits = temp.Split(' ');
                Edge tempEdge = new Edge();
                tempEdge.Source = int.Parse(splits[0]);
                tempEdge.Target = int.Parse(splits[1]);
                tempEdge.Weight = 0;
                if (splits.Length > 2)
                    tempEdge.Weight = double.Parse(splits[2]);
                Sorted_Edge.Add(tempEdge);
            }
            Sorted_Edge.Sort();

            foreach (Edge ed in Sorted_Edge)
            {
                string Txt = ed.Source.ToString() + " " + ed.Target.ToString() + " " + ed.Weight.ToString();
                ListViewItem item = new ListViewItem(Txt);
                listView1.Items.Add(item);
            }

            if (!IsDirected && !isUndirected)
                MessageBox.Show("Bạn chưa chọn loại đồ thị!");
            else
            {
                kruskal.kruskalMST(Sorted_Edge);
                Sorted_Edge = kruskal.Order1;
                result = kruskal.Result;
                backgroundWorker1.RunWorkerAsync();
            }
        }
        private void btnStepBack_Click(object sender, EventArgs e)
        {
            try
            {
                index_FormState = Math.Max(0, index_FormState - 1);
                FormState formState = History1[index_FormState];
                using (Graphics g = grBDoThi.CreateGraphics())
                {
                    g.DrawImage(formState.PrevBuffer, 0, 0);
                }

                lbThuTuDuyet.Text = formState.ThuTuDuyet;
                if (formState.isChosen)
                    listView1.Items[index_FormState - 1].ForeColor = Color.Red;

                Dijk_VertexState X = formState.temp;
                if (X != null)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == X.vertex.ToString())
                        {
                            row.Cells[1].Value = X.isVisited;
                            row.Cells[2].Value = X.Cost;
                            row.Cells[3].Value = X.Path;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn thuật toán trước!");
            }

        }

        private void btnStepForward_Click(object sender, EventArgs e)
        {
            try
            {
                index_FormState = Math.Min(History1.Count - 1, index_FormState + 1);
                FormState formState = History1[index_FormState];
                using (Graphics g = grBDoThi.CreateGraphics())
                {
                    g.DrawImage(formState.PrevBuffer, 0, 0);
                }

                lbThuTuDuyet.Text = formState.ThuTuDuyet;
                if (formState.isChosen)
                    listView1.Items[index_FormState - 1].ForeColor = Color.Red;

                Dijk_VertexState X = formState.temp;

                if (X != null)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == X.vertex.ToString())
                        {
                            row.Cells[1].Value = X.isVisited;
                            row.Cells[2].Value = X.Cost;
                            row.Cells[3].Value = X.Path;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn thuật toán trước!");
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (Status.isKruskal)
                preComputeKruskal();
            else if (Status.isBFS)
                preComputeBFS();
            else if (Status.isDFS)
                preComputeDFS();
            else
                preComputeDijkstra();

        }

        private void preComputeBFS()
        {
            History1.Clear();

            ThuTuDuyet = "";
            Bitmap bmp = (Bitmap)Buffer.Clone();
            History1.Add(new FormState(bmp, ThuTuDuyet));

            foreach ((int, int) pair in Order)
            {
                int vertex = pair.Item1;
                int par = pair.Item2;
                if (ThuTuDuyet != "")
                    ThuTuDuyet += " ----> ";
                ThuTuDuyet += vertex.ToString();
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    DrawVertex(getPosition(vertex, Position), g, Brushes.Red);
                    DrawNumber(vertex.ToString(), getPosition(vertex, Position), g);
                    if (vertex != par)
                    {
                        DrawVertex(getPosition(par, Position), g, Brushes.Red);
                        DrawNumber(par.ToString(), getPosition(par, Position), g);
                        DrawEdge(getPosition(vertex, Position), getPosition(par, Position1), g, Pens.Red);
                    }
                }
                History1.Add(new FormState(bmp, ThuTuDuyet));
            }
        }

        private void preComputeDFS()
        {
            History1.Clear();

            ThuTuDuyet = "";
            Bitmap bmp = (Bitmap)Buffer.Clone();
            History1.Add(new FormState(bmp, ThuTuDuyet));
            foreach ((int, int) pair in Order)
            {
                int vertex = pair.Item1;
                int par = pair.Item2;
                if (ThuTuDuyet != "")
                    ThuTuDuyet += " ----> ";
                ThuTuDuyet += vertex.ToString();
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    DrawVertex(getPosition(vertex, Position), g, Brushes.Red);
                    DrawNumber(vertex.ToString(), getPosition(vertex, Position), g);
                    if (vertex != par)
                    {
                        DrawVertex(getPosition(par, Position), g, Brushes.Red);
                        DrawNumber(par.ToString(), getPosition(par, Position), g);
                        DrawEdge(getPosition(vertex, Position), getPosition(par, Position1), g, Pens.Red);
                    }
                }
                History1.Add(new FormState(bmp, ThuTuDuyet));
            }
        }

        private void preComputeKruskal()
        {
            History1.Clear();
            List<Edge> Sorted = Sorted_Edge.ToList();

            Bitmap bmp = (Bitmap)Buffer.Clone();
            History1.Add(new FormState(bmp, false));

            var graph = IsDirected ? DirectedGraph1 : UndirectedGraph1;
            while (Sorted.Count > 0)
            {
                Edge edgeToFind = graph.Edges.FirstOrDefault(edge => edge.Source == Sorted[0].Source && edge.Target == Sorted[0].Target && edge.Weight == Sorted[0].Weight);
                Sorted.RemoveAt(0);
                int u = edgeToFind.Source;
                int v = edgeToFind.Target;

                Point pos_u = getPosition(u, Position);
                Point pos_v = getPosition(v, Position);

                if (result.Any(edge => edge.Source == edgeToFind.Source && edge.Target == edgeToFind.Target && edge.Weight == edgeToFind.Weight))
                {
                    using (Graphics bufferGraphics = Graphics.FromImage(bmp))
                    {
                        DrawVertex(pos_u, bufferGraphics, Brushes.Red);
                        DrawNumber(u.ToString(), pos_u, bufferGraphics);

                        DrawVertex(pos_v, bufferGraphics, Brushes.Red);
                        DrawNumber(v.ToString(), pos_v, bufferGraphics);

                        DrawEdge(pos_u, pos_v, bufferGraphics, Pens.Red);
                    }
                    History1.Add(new FormState(bmp, true));
                }
                else
                {
                    using (Graphics bufferGraphics = Graphics.FromImage(bmp))
                    {
                        DrawVertex(pos_u, bufferGraphics, Brushes.Green);
                        DrawNumber(u.ToString(), pos_u, bufferGraphics);

                        DrawVertex(pos_v, bufferGraphics, Brushes.Green);
                        DrawNumber(v.ToString(), pos_v, bufferGraphics);

                        DrawEdge(pos_u, pos_v, bufferGraphics, Pens.Green);
                    }
                    History1.Add(new FormState(bmp, false));
                }

            }
        }

        private void preComputeDijkstra()
        {
            History.Clear();

            List<int>[] LinkedToVertex = (isDirected ? LinkedToDiVertex : LinkedToUnVertex);

            History.Add(new FormState(buffer));

            while (!Dijk.pq.IsEmpty)
            {

                Bitmap bmp = (Bitmap)buffer.Clone();
                Graphics bufferGraphics = Graphics.FromImage(bmp);


                var temp_pq = Dijk.pq.Dequeue();
                int vertex = temp_pq.Value;

                if (!Dijk.isVisited[vertex])
                {

                    Dijk.isVisited[vertex] = true;

                    Dijk_VertexState tmp = new Dijk_VertexState(vertex, true, Dijk.dist[vertex], showPath(vertex, Dijk));


                    Point temp = getPosition(vertex, Position);
                    DrawVertex(temp, bufferGraphics, Brushes.Red);
                    DrawNumber(vertex.ToString(), temp, bufferGraphics);

                    History.Add(new FormState(bmp, tmp));
                    Dijk.now_vertex = vertex;

                    Bitmap bmp2 = (Bitmap)bmp.Clone();
                    foreach (int v in LinkedToVertex[Dijk.now_vertex])
                    {
                        var graph = isDirected ? DirectedGraph : UndirectedGraph;
                        Edge edgeToFind = graph.Edges.FirstOrDefault(edge => edge.Source == Dijk.now_vertex && edge.Target == v);
                        if (Dijk.dist[v] > Dijk.dist[Dijk.now_vertex] + edgeToFind.Weight)
                        {
                            Dijk.dist[v] = Dijk.dist[Dijk.now_vertex] + edgeToFind.Weight;
                            Dijk.Paths[v] = Dijk.Paths[Dijk.now_vertex].ToList();
                            Dijk.Paths[v].Add(v);
                            Dijk.pq.Enqueue(Dijk.dist[v], v);
                        }
                        tmp = new Dijk_VertexState(v, Dijk.isVisited[v], Dijk.dist[v], showPath(v, Dijk));
                        using (Graphics g = Graphics.FromImage(bmp2))
                        {
                            Point pos_u = getPosition(Dijk.now_vertex, Position);
                            Point pos_v = getPosition(v, Position);
                            DrawVertex(pos_v, g, Brushes.Green);
                            g.DrawLine(Pens.Green, pos_u, pos_v);
                            DrawNumber(v.ToString(), pos_v, g);
                        }

                        History.Add(new FormState(bmp2, tmp));
                    }

                }
            }
        }
        private void btnSkipForward_Click(object sender, EventArgs e)
        {
            try
            {
                cts.Cancel();
                index_FormState = History1.Count - 1;
                FormState formState = History1[index_FormState];
                using (Graphics g = grBDoThi.CreateGraphics())
                {
                    g.DrawImage(formState.PrevBuffer, 0, 0);
                }

                lbThuTuDuyet.Text = formState.ThuTuDuyet;

                for (int i = 0; i < History1.Count; i++)
                {
                    if (History1[i].isChosen)
                    {
                        listView1.Items[i - 1].ForeColor = Color.Red;
                    }

                    Dijk_VertexState X = History1[i].temp;
                    if (X != null)
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == X.vertex.ToString())
                            {
                                row.Cells[1].Value = X.isVisited;
                                row.Cells[2].Value = X.Cost;
                                row.Cells[3].Value = X.Path;
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn thuật toán trước!");
            } 
            
        }

        private async void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (btnPause.Text == "Pause")
            {
                cts = new CancellationTokenSource();
                index_FormState = 0;
                await Visualize(cts.Token);
            } 
            else
            {
                index_FormState = 0;
                if(cts != null) cts.Cancel();
                using (Graphics g = grBDoThi.CreateGraphics())
                {
                    g.DrawImage(buffer, 0, 0);
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell changedCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                changedCell.Style.ForeColor = Color.Red;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.RowIndex != changedCell.RowIndex)
                        {
                            cell.Style.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }

        private void tSBRefresh_Click(object sender, EventArgs e)
        {
            lbTitle.Text = "MÔ PHỎNG ĐỒ THỊ";
            using (Graphics g = grBDoThi.CreateGraphics())
            {
                g.DrawImage(buffer, 0, 0);
            }
            listView1.Clear();
            lbThuTuDuyet.Text = "";
            
            listView1.Visible = false;
            groupBox1.Visible = false;
            dataGridView1.Visible = false;
            index_FormState = 0;
            cts.Cancel();
        }
    }


}
