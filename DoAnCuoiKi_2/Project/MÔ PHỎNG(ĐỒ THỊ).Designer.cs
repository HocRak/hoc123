namespace Project
{
    partial class dothi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dothi));
            panel1 = new System.Windows.Forms.Panel();
            lbTitle = new System.Windows.Forms.Label();
            grBDoThi = new System.Windows.Forms.GroupBox();
            grbDSCanh = new System.Windows.Forms.GroupBox();
            lsvDSCanh = new System.Windows.Forms.ListView();
            DFS_BFS = new System.Windows.Forms.Timer(components);
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            tSTBDinh = new System.Windows.Forms.ToolStripTextBox();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            tSTBCanh = new System.Windows.Forms.ToolStripTextBox();
            tSBThem = new System.Windows.Forms.ToolStripButton();
            tSBXoa = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            BFSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            DFSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            dijkstraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            kruskalMSTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            tSBRefresh = new System.Windows.Forms.ToolStripButton();
            groupBox1 = new System.Windows.Forms.GroupBox();
            lbThuTuDuyet = new System.Windows.Forms.Label();
            grBLoai = new System.Windows.Forms.GroupBox();
            checkBox1 = new System.Windows.Forms.CheckBox();
            rBCoHuong = new System.Windows.Forms.RadioButton();
            rBVoHuong = new System.Windows.Forms.RadioButton();
            trackBar1 = new System.Windows.Forms.TrackBar();
            panel3 = new System.Windows.Forms.Panel();
            lbSpeed = new System.Windows.Forms.Label();
            btnSkipForward = new System.Windows.Forms.Button();
            btnStepForward = new System.Windows.Forms.Button();
            btnStepBack = new System.Windows.Forms.Button();
            btnPause = new System.Windows.Forms.Button();
            btnSkipBack = new System.Windows.Forms.Button();
            Dijkstra_1 = new System.Windows.Forms.Timer(components);
            dataGridView1 = new System.Windows.Forms.DataGridView();
            Dijkstra_2 = new System.Windows.Forms.Timer(components);
            Kruskal = new System.Windows.Forms.Timer(components);
            pnl_Kruskal = new System.Windows.Forms.Panel();
            listView1 = new System.Windows.Forms.ListView();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel1.SuspendLayout();
            grbDSCanh.SuspendLayout();
            toolStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            grBLoai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            pnl_Kruskal.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Black;
            panel1.Controls.Add(lbTitle);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1847, 75);
            panel1.TabIndex = 0;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.BackColor = System.Drawing.Color.Black;
            lbTitle.Font = new System.Drawing.Font("Showcard Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbTitle.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            lbTitle.Location = new System.Drawing.Point(12, 9);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new System.Drawing.Size(353, 46);
            lbTitle.TabIndex = 0;
            lbTitle.Text = "Graph visualize";
            lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grBDoThi
            // 
            grBDoThi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            grBDoThi.Location = new System.Drawing.Point(939, 120);
            grBDoThi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grBDoThi.Name = "grBDoThi";
            grBDoThi.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grBDoThi.Size = new System.Drawing.Size(908, 899);
            grBDoThi.TabIndex = 5;
            grBDoThi.TabStop = false;
            grBDoThi.Text = "Visualization";
            grBDoThi.Paint += grBDoThi_Paint;
            // 
            // grbDSCanh
            // 
            grbDSCanh.Controls.Add(lsvDSCanh);
            grbDSCanh.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            grbDSCanh.Location = new System.Drawing.Point(21, 414);
            grbDSCanh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grbDSCanh.Name = "grbDSCanh";
            grbDSCanh.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grbDSCanh.Size = new System.Drawing.Size(196, 528);
            grbDSCanh.TabIndex = 6;
            grbDSCanh.TabStop = false;
            grbDSCanh.Text = "Edges List";
            // 
            // lsvDSCanh
            // 
            lsvDSCanh.Dock = System.Windows.Forms.DockStyle.Fill;
            lsvDSCanh.Location = new System.Drawing.Point(3, 27);
            lsvDSCanh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            lsvDSCanh.Name = "lsvDSCanh";
            lsvDSCanh.Size = new System.Drawing.Size(190, 497);
            lsvDSCanh.TabIndex = 0;
            lsvDSCanh.UseCompatibleStateImageBehavior = false;
            lsvDSCanh.View = System.Windows.Forms.View.List;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripLabel1, tSTBDinh, toolStripSeparator1, toolStripLabel2, tSTBCanh, tSBThem, tSBXoa, toolStripSeparator2, toolStripSplitButton1, toolStripButton1, tSBRefresh });
            toolStrip1.Location = new System.Drawing.Point(0, 75);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(1847, 45);
            toolStrip1.TabIndex = 12;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.BackColor = System.Drawing.Color.Green;
            toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            toolStripLabel1.ForeColor = System.Drawing.Color.Black;
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new System.Drawing.Size(111, 42);
            toolStripLabel1.Text = "Start Vertex:";
            // 
            // tSTBDinh
            // 
            tSTBDinh.Name = "tSTBDinh";
            tSTBDinh.Size = new System.Drawing.Size(100, 45);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new System.Drawing.Size(55, 42);
            toolStripLabel2.Text = "Edge:";
            // 
            // tSTBCanh
            // 
            tSTBCanh.Name = "tSTBCanh";
            tSTBCanh.Size = new System.Drawing.Size(150, 45);
            // 
            // tSBThem
            // 
            tSBThem.BackColor = System.Drawing.Color.Black;
            tSBThem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            tSBThem.Font = new System.Drawing.Font("Showcard Gothic", 16.2F);
            tSBThem.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            tSBThem.Image = (System.Drawing.Image)resources.GetObject("tSBThem.Image");
            tSBThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            tSBThem.Name = "tSBThem";
            tSBThem.Size = new System.Drawing.Size(78, 42);
            tSBThem.Text = "ADD";
            tSBThem.Click += tSBThem_Click;
            // 
            // tSBXoa
            // 
            tSBXoa.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            tSBXoa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            tSBXoa.Font = new System.Drawing.Font("Showcard Gothic", 16.2F);
            tSBXoa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            tSBXoa.Image = (System.Drawing.Image)resources.GetObject("tSBXoa.Image");
            tSBXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            tSBXoa.Name = "tSBXoa";
            tSBXoa.Size = new System.Drawing.Size(120, 42);
            tSBXoa.Text = "DELETE";
            tSBXoa.Click += tSBXoa_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(6, 45);
            // 
            // toolStripSplitButton1
            // 
            toolStripSplitButton1.BackColor = System.Drawing.Color.Lime;
            toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { BFSToolStripMenuItem, DFSToolStripMenuItem, dijkstraToolStripMenuItem, kruskalMSTToolStripMenuItem });
            toolStripSplitButton1.Font = new System.Drawing.Font("Showcard Gothic", 16.2F);
            toolStripSplitButton1.ForeColor = System.Drawing.Color.Black;
            toolStripSplitButton1.Image = (System.Drawing.Image)resources.GetObject("toolStripSplitButton1.Image");
            toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripSplitButton1.Name = "toolStripSplitButton1";
            toolStripSplitButton1.Size = new System.Drawing.Size(197, 42);
            toolStripSplitButton1.Text = "Algorithm";
            // 
            // BFSToolStripMenuItem
            // 
            BFSToolStripMenuItem.Name = "BFSToolStripMenuItem";
            BFSToolStripMenuItem.Size = new System.Drawing.Size(297, 40);
            BFSToolStripMenuItem.Text = "&BFS";
            BFSToolStripMenuItem.Click += BFSToolStripMenuItem_Click;
            // 
            // DFSToolStripMenuItem
            // 
            DFSToolStripMenuItem.Name = "DFSToolStripMenuItem";
            DFSToolStripMenuItem.Size = new System.Drawing.Size(297, 40);
            DFSToolStripMenuItem.Text = "&DFS";
            DFSToolStripMenuItem.Click += DFSToolStripMenuItem_Click;
            // 
            // dijkstraToolStripMenuItem
            // 
            dijkstraToolStripMenuItem.Name = "dijkstraToolStripMenuItem";
            dijkstraToolStripMenuItem.Size = new System.Drawing.Size(297, 40);
            dijkstraToolStripMenuItem.Text = "&Dijkstra";
            dijkstraToolStripMenuItem.Click += dijkstraToolStripMenuItem_Click;
            // 
            // kruskalMSTToolStripMenuItem
            // 
            kruskalMSTToolStripMenuItem.Name = "kruskalMSTToolStripMenuItem";
            kruskalMSTToolStripMenuItem.Size = new System.Drawing.Size(297, 40);
            kruskalMSTToolStripMenuItem.Text = "&Kruskal_MST";
            kruskalMSTToolStripMenuItem.Click += kruskalMSTToolStripMenuItem_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new System.Drawing.Size(6, 45);
            // 
            // tSBRefresh
            // 
            tSBRefresh.BackColor = System.Drawing.Color.Silver;
            tSBRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            tSBRefresh.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
            tSBRefresh.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            tSBRefresh.Image = (System.Drawing.Image)resources.GetObject("tSBRefresh.Image");
            tSBRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            tSBRefresh.Name = "tSBRefresh";
            tSBRefresh.Size = new System.Drawing.Size(120, 42);
            tSBRefresh.Text = "Refresh";
            tSBRefresh.Click += tSBRefresh_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lbThuTuDuyet);
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            groupBox1.Location = new System.Drawing.Point(241, 414);
            groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Size = new System.Drawing.Size(334, 200);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Traversal Order";
            groupBox1.Visible = false;
            // 
            // lbThuTuDuyet
            // 
            lbThuTuDuyet.AutoSize = true;
            lbThuTuDuyet.Location = new System.Drawing.Point(53, 42);
            lbThuTuDuyet.Name = "lbThuTuDuyet";
            lbThuTuDuyet.Size = new System.Drawing.Size(0, 23);
            lbThuTuDuyet.TabIndex = 0;
            // 
            // grBLoai
            // 
            grBLoai.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            grBLoai.Controls.Add(checkBox1);
            grBLoai.Controls.Add(rBCoHuong);
            grBLoai.Controls.Add(rBVoHuong);
            grBLoai.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            grBLoai.ForeColor = System.Drawing.Color.Black;
            grBLoai.Location = new System.Drawing.Point(12, 190);
            grBLoai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grBLoai.Name = "grBLoai";
            grBLoai.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            grBLoai.Size = new System.Drawing.Size(613, 149);
            grBLoai.TabIndex = 16;
            grBLoai.TabStop = false;
            grBLoai.Text = "Type of Graph";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(12, 96);
            checkBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(165, 27);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "Weighted Graph";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // rBCoHuong
            // 
            rBCoHuong.AutoSize = true;
            rBCoHuong.Location = new System.Drawing.Point(12, 63);
            rBCoHuong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            rBCoHuong.Name = "rBCoHuong";
            rBCoHuong.Size = new System.Drawing.Size(154, 27);
            rBCoHuong.TabIndex = 1;
            rBCoHuong.Text = "Directed Graph";
            rBCoHuong.UseVisualStyleBackColor = true;
            rBCoHuong.CheckedChanged += rBCoHuong_CheckedChanged;
            // 
            // rBVoHuong
            // 
            rBVoHuong.AutoSize = true;
            rBVoHuong.Location = new System.Drawing.Point(12, 31);
            rBVoHuong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            rBVoHuong.Name = "rBVoHuong";
            rBVoHuong.Size = new System.Drawing.Size(174, 27);
            rBVoHuong.TabIndex = 0;
            rBVoHuong.Text = "Undirected Graph";
            rBVoHuong.UseVisualStyleBackColor = true;
            rBVoHuong.CheckedChanged += rBVoHuong_CheckedChanged;
            // 
            // trackBar1
            // 
            trackBar1.Location = new System.Drawing.Point(621, 14);
            trackBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new System.Drawing.Size(185, 56);
            trackBar1.TabIndex = 17;
            trackBar1.Value = 1;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // panel3
            // 
            panel3.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            panel3.Controls.Add(lbSpeed);
            panel3.Controls.Add(btnSkipForward);
            panel3.Controls.Add(btnStepForward);
            panel3.Controls.Add(btnStepBack);
            panel3.Controls.Add(btnPause);
            panel3.Controls.Add(btnSkipBack);
            panel3.Controls.Add(trackBar1);
            panel3.Location = new System.Drawing.Point(0, 914);
            panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(939, 80);
            panel3.TabIndex = 18;
            // 
            // lbSpeed
            // 
            lbSpeed.AutoSize = true;
            lbSpeed.Font = new System.Drawing.Font("Showcard Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbSpeed.ForeColor = System.Drawing.Color.Black;
            lbSpeed.Location = new System.Drawing.Point(661, 44);
            lbSpeed.Name = "lbSpeed";
            lbSpeed.Size = new System.Drawing.Size(170, 21);
            lbSpeed.TabIndex = 23;
            lbSpeed.Text = "Animation Speed";
            // 
            // btnSkipForward
            // 
            btnSkipForward.BackColor = System.Drawing.Color.Black;
            btnSkipForward.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnSkipForward.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            btnSkipForward.Location = new System.Drawing.Point(467, 14);
            btnSkipForward.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSkipForward.Name = "btnSkipForward";
            btnSkipForward.Size = new System.Drawing.Size(133, 46);
            btnSkipForward.TabIndex = 22;
            btnSkipForward.Text = "Skip Forward";
            btnSkipForward.UseVisualStyleBackColor = false;
            btnSkipForward.Click += btnSkipForward_Click;
            // 
            // btnStepForward
            // 
            btnStepForward.BackColor = System.Drawing.Color.Black;
            btnStepForward.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnStepForward.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            btnStepForward.Location = new System.Drawing.Point(333, 14);
            btnStepForward.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnStepForward.Name = "btnStepForward";
            btnStepForward.Size = new System.Drawing.Size(128, 46);
            btnStepForward.TabIndex = 21;
            btnStepForward.Text = "Step Forward";
            btnStepForward.UseVisualStyleBackColor = false;
            btnStepForward.Click += btnStepForward_Click;
            // 
            // btnStepBack
            // 
            btnStepBack.BackColor = System.Drawing.Color.Black;
            btnStepBack.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnStepBack.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            btnStepBack.Location = new System.Drawing.Point(127, 14);
            btnStepBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnStepBack.Name = "btnStepBack";
            btnStepBack.Size = new System.Drawing.Size(99, 46);
            btnStepBack.TabIndex = 20;
            btnStepBack.Text = "Step Back";
            btnStepBack.UseVisualStyleBackColor = false;
            btnStepBack.Click += btnStepBack_Click;
            // 
            // btnPause
            // 
            btnPause.BackColor = System.Drawing.Color.Black;
            btnPause.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnPause.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            btnPause.Location = new System.Drawing.Point(232, 14);
            btnPause.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnPause.Name = "btnPause";
            btnPause.Size = new System.Drawing.Size(95, 46);
            btnPause.TabIndex = 19;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = false;
            btnPause.Click += btnPause_Click;
            // 
            // btnSkipBack
            // 
            btnSkipBack.BackColor = System.Drawing.Color.Black;
            btnSkipBack.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnSkipBack.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
            btnSkipBack.Location = new System.Drawing.Point(12, 14);
            btnSkipBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSkipBack.Name = "btnSkipBack";
            btnSkipBack.Size = new System.Drawing.Size(109, 46);
            btnSkipBack.TabIndex = 18;
            btnSkipBack.Text = "Skip back";
            btnSkipBack.UseVisualStyleBackColor = false;
            btnSkipBack.Click += btnSkipBack_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(223, 638);
            dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 24;
            dataGridView1.Size = new System.Drawing.Size(424, 236);
            dataGridView1.TabIndex = 19;
            dataGridView1.Visible = false;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            // 
            // Kruskal
            // 
            Kruskal.Interval = 1000;
            // 
            // pnl_Kruskal
            // 
            pnl_Kruskal.Controls.Add(listView1);
            pnl_Kruskal.Location = new System.Drawing.Point(300, 414);
            pnl_Kruskal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pnl_Kruskal.Name = "pnl_Kruskal";
            pnl_Kruskal.Size = new System.Drawing.Size(325, 524);
            pnl_Kruskal.TabIndex = 20;
            // 
            // listView1
            // 
            listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            listView1.Location = new System.Drawing.Point(0, 0);
            listView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(325, 524);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = System.Windows.Forms.View.List;
            listView1.Visible = false;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // dothi
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1847, 1032);
            Controls.Add(panel3);
            Controls.Add(grBDoThi);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            Controls.Add(pnl_Kruskal);
            Controls.Add(grBLoai);
            Controls.Add(toolStrip1);
            Controls.Add(grbDSCanh);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "dothi";
            Text = "MÔ PHỎNG(ĐỒ THỊ)";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += ĐỒ_THỊ_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            grbDSCanh.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            grBLoai.ResumeLayout(false);
            grBLoai.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            pnl_Kruskal.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.GroupBox grBDoThi;
        private System.Windows.Forms.GroupBox grbDSCanh;
        private System.Windows.Forms.ListView lsvDSCanh;
        private System.Windows.Forms.Timer DFS_BFS;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tSTBDinh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tSTBCanh;
        private System.Windows.Forms.ToolStripButton tSBThem;
        private System.Windows.Forms.ToolStripButton tSBXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem BFSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DFSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dijkstraToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbThuTuDuyet;
        private System.Windows.Forms.GroupBox grBLoai;
        private System.Windows.Forms.RadioButton rBCoHuong;
        private System.Windows.Forms.RadioButton rBVoHuong;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnSkipBack;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer Dijkstra_1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer Dijkstra_2;
        private System.Windows.Forms.ToolStripMenuItem kruskalMSTToolStripMenuItem;
        private System.Windows.Forms.Timer Kruskal;
        private System.Windows.Forms.Panel pnl_Kruskal;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnStepBack;
        private System.Windows.Forms.Button btnSkipForward;
        private System.Windows.Forms.Button btnStepForward;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripButton tSBRefresh;
        private System.Windows.Forms.Label lbSpeed;
    }
}