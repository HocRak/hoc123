namespace GiaoDienHeThong
{
    partial class CauTrucDuLieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CauTrucDuLieu));
            label1 = new Label();
            button_hash = new Button();
            button_redblacktree = new Button();
            button_LiThuyet = new Button();
            button_BaiTap = new Button();
            button_graph = new Button();
            panel_Tool = new Panel();
            button_user = new Button();
            panel_main = new Panel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel2 = new Panel();
            label4 = new Label();
            panel_Tool.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(27, 30, 33);
            label1.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 3);
            label1.Name = "label1";
            label1.Size = new Size(158, 60);
            label1.TabIndex = 0;
            label1.Text = "DATA STRUCTURE";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button_hash
            // 
            button_hash.BackColor = Color.FromArgb(27, 30, 33);
            button_hash.FlatAppearance.BorderSize = 0;
            button_hash.FlatAppearance.MouseDownBackColor = SystemColors.Control;
            button_hash.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 45);
            button_hash.FlatStyle = FlatStyle.Flat;
            button_hash.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_hash.ForeColor = Color.White;
            button_hash.Image = (Image)resources.GetObject("button_hash.Image");
            button_hash.Location = new Point(-2, 419);
            button_hash.Name = "button_hash";
            button_hash.Size = new Size(160, 80);
            button_hash.TabIndex = 12;
            button_hash.Text = "Băm";
            button_hash.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_hash.UseVisualStyleBackColor = false;
            button_hash.Click += button_hash_Click;
            // 
            // button_redblacktree
            // 
            button_redblacktree.BackColor = Color.FromArgb(27, 30, 33);
            button_redblacktree.FlatAppearance.BorderSize = 0;
            button_redblacktree.FlatAppearance.MouseDownBackColor = SystemColors.Control;
            button_redblacktree.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 45);
            button_redblacktree.FlatStyle = FlatStyle.Flat;
            button_redblacktree.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_redblacktree.ForeColor = Color.White;
            button_redblacktree.Image = (Image)resources.GetObject("button_redblacktree.Image");
            button_redblacktree.Location = new Point(3, 247);
            button_redblacktree.Name = "button_redblacktree";
            button_redblacktree.Size = new Size(160, 80);
            button_redblacktree.TabIndex = 13;
            button_redblacktree.Text = "Cây đỏ đen";
            button_redblacktree.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_redblacktree.UseVisualStyleBackColor = false;
            button_redblacktree.Click += button_RBT_Click;
            // 
            // button_LiThuyet
            // 
            button_LiThuyet.BackColor = Color.FromArgb(27, 30, 33);
            button_LiThuyet.FlatAppearance.BorderSize = 0;
            button_LiThuyet.FlatAppearance.MouseDownBackColor = SystemColors.Control;
            button_LiThuyet.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 45);
            button_LiThuyet.FlatStyle = FlatStyle.Flat;
            button_LiThuyet.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_LiThuyet.ForeColor = Color.White;
            button_LiThuyet.Image = (Image)resources.GetObject("button_LiThuyet.Image");
            button_LiThuyet.Location = new Point(0, 75);
            button_LiThuyet.Name = "button_LiThuyet";
            button_LiThuyet.Size = new Size(160, 80);
            button_LiThuyet.TabIndex = 14;
            button_LiThuyet.Text = "Kiến thức";
            button_LiThuyet.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_LiThuyet.UseVisualStyleBackColor = false;
            button_LiThuyet.Click += button_LiThuyet_Click;
            // 
            // button_BaiTap
            // 
            button_BaiTap.BackColor = Color.FromArgb(27, 30, 33);
            button_BaiTap.FlatAppearance.BorderSize = 0;
            button_BaiTap.FlatAppearance.MouseDownBackColor = SystemColors.Control;
            button_BaiTap.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 45);
            button_BaiTap.FlatStyle = FlatStyle.Flat;
            button_BaiTap.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_BaiTap.ForeColor = Color.White;
            button_BaiTap.Image = (Image)resources.GetObject("button_BaiTap.Image");
            button_BaiTap.Location = new Point(2, 161);
            button_BaiTap.Name = "button_BaiTap";
            button_BaiTap.Size = new Size(160, 80);
            button_BaiTap.TabIndex = 15;
            button_BaiTap.Text = "Bài tập";
            button_BaiTap.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_BaiTap.UseVisualStyleBackColor = false;
            button_BaiTap.Click += button_BaiTap_Click;
            // 
            // button_graph
            // 
            button_graph.BackColor = Color.FromArgb(27, 30, 33);
            button_graph.FlatAppearance.BorderSize = 0;
            button_graph.FlatAppearance.MouseDownBackColor = SystemColors.Control;
            button_graph.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 45);
            button_graph.FlatStyle = FlatStyle.Flat;
            button_graph.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_graph.ForeColor = Color.White;
            button_graph.Image = (Image)resources.GetObject("button_graph.Image");
            button_graph.Location = new Point(-2, 333);
            button_graph.Name = "button_graph";
            button_graph.Size = new Size(160, 80);
            button_graph.TabIndex = 16;
            button_graph.Text = "Đồ thị";
            button_graph.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_graph.UseVisualStyleBackColor = false;
            button_graph.Click += button_graph_Click;
            // 
            // panel_Tool
            // 
            panel_Tool.BackColor = Color.FromArgb(27, 30, 33);
            panel_Tool.BorderStyle = BorderStyle.Fixed3D;
            panel_Tool.Controls.Add(button_user);
            panel_Tool.Controls.Add(button_graph);
            panel_Tool.Controls.Add(button_BaiTap);
            panel_Tool.Controls.Add(button_LiThuyet);
            panel_Tool.Controls.Add(button_redblacktree);
            panel_Tool.Controls.Add(button_hash);
            panel_Tool.Controls.Add(label1);
            panel_Tool.Dock = DockStyle.Left;
            panel_Tool.Location = new Point(0, 0);
            panel_Tool.Name = "panel_Tool";
            panel_Tool.Size = new Size(160, 693);
            panel_Tool.TabIndex = 12;
            // 
            // button_user
            // 
            button_user.BackColor = Color.FromArgb(27, 30, 33);
            button_user.FlatAppearance.BorderSize = 0;
            button_user.FlatAppearance.MouseDownBackColor = SystemColors.Control;
            button_user.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 45);
            button_user.FlatStyle = FlatStyle.Flat;
            button_user.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_user.ForeColor = Color.White;
            button_user.Image = (Image)resources.GetObject("button_user.Image");
            button_user.Location = new Point(0, 505);
            button_user.Name = "button_user";
            button_user.Size = new Size(160, 73);
            button_user.TabIndex = 17;
            button_user.Text = "Tài khoản";
            button_user.TextImageRelation = TextImageRelation.ImageBeforeText;
            button_user.UseVisualStyleBackColor = false;
            button_user.Click += button_user_Click;
            // 
            // panel_main
            // 
            panel_main.AutoScroll = true;
            panel_main.BackColor = Color.FromArgb(247, 248, 250);
            panel_main.BackgroundImageLayout = ImageLayout.Stretch;
            panel_main.BorderStyle = BorderStyle.Fixed3D;
            panel_main.Location = new Point(159, 0);
            panel_main.Name = "panel_main";
            panel_main.Size = new Size(1023, 626);
            panel_main.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(160, 627);
            panel2.Name = "panel2";
            panel2.Size = new Size(1022, 66);
            panel2.TabIndex = 14;
            // 
            // label4
            // 
            label4.Font = new Font("Showcard Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Gold;
            label4.Location = new Point(-3, 0);
            label4.Name = "label4";
            label4.Size = new Size(1019, 62);
            label4.TabIndex = 0;
            label4.Text = "Algorithm visualization";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            label4.Click += label4_Click;
            // 
            // CauTrucDuLieu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 16, 18);
            ClientSize = new Size(1182, 693);
            Controls.Add(panel2);
            Controls.Add(panel_Tool);
            Controls.Add(panel_main);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            Name = "CauTrucDuLieu";
            Text = "MÔ TẢ CẤU TRÚC DỮ LIỆU";
            WindowState = FormWindowState.Maximized;
            Load += CauTrucDuLieu_Load;
            panel_Tool.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Button button_hash;
        private Button button_redblacktree;
        private Button button_LiThuyet;
        private Button button_BaiTap;
        private Button button_graph;
        private Panel panel_Tool;
        private Button button_user;
        private Panel panel_main;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel panel2;
        private Label label4;
    }
}