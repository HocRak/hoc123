namespace GiaoDienHeThong
{
    partial class User
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User));
            button_DangXuat = new Button();
            label_matkhau = new Label();
            label1 = new Label();
            label_tk = new Label();
            label2 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // button_DangXuat
            // 
            button_DangXuat.BackColor = Color.FromArgb(7, 49, 99);
            button_DangXuat.FlatAppearance.BorderSize = 0;
            button_DangXuat.FlatAppearance.MouseOverBackColor = Color.FromArgb(18, 96, 57);
            button_DangXuat.FlatStyle = FlatStyle.Flat;
            button_DangXuat.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_DangXuat.ForeColor = Color.White;
            button_DangXuat.Location = new Point(12, 159);
            button_DangXuat.Name = "button_DangXuat";
            button_DangXuat.Size = new Size(173, 41);
            button_DangXuat.TabIndex = 0;
            button_DangXuat.Text = "Đăng xuất";
            button_DangXuat.UseVisualStyleBackColor = false;
            button_DangXuat.Click += button_DangXuat_Click;
            // 
            // label_matkhau
            // 
            label_matkhau.BackColor = Color.FromArgb(7, 50, 101);
            label_matkhau.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_matkhau.ForeColor = Color.White;
            label_matkhau.Location = new Point(165, 102);
            label_matkhau.Name = "label_matkhau";
            label_matkhau.Size = new Size(216, 37);
            label_matkhau.TabIndex = 6;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(2, 34, 72);
            label1.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 102);
            label1.Name = "label1";
            label1.Size = new Size(126, 37);
            label1.TabIndex = 3;
            label1.Text = "Mật khẩu";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_tk
            // 
            label_tk.BackColor = Color.FromArgb(4, 38, 76);
            label_tk.FlatStyle = FlatStyle.Flat;
            label_tk.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_tk.ForeColor = Color.White;
            label_tk.Location = new Point(165, 35);
            label_tk.Name = "label_tk";
            label_tk.Size = new Size(216, 37);
            label_tk.TabIndex = 7;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(1, 21, 48);
            label2.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 35);
            label2.Name = "label2";
            label2.Size = new Size(126, 37);
            label2.TabIndex = 4;
            label2.Text = "Tên tài khoản";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(7, 49, 99);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(18, 96, 57);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(208, 159);
            button1.Name = "button1";
            button1.Size = new Size(173, 41);
            button1.TabIndex = 8;
            button1.Text = "Quay lại";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // User
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(189, 232, 249);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(393, 220);
            Controls.Add(button1);
            Controls.Add(label_matkhau);
            Controls.Add(label_tk);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button_DangXuat);
            FormBorderStyle = FormBorderStyle.None;
            Name = "User";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tài khoản";
            Load += User_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button_DangXuat;
        private Label label_matkhau;
        private Label label1;
        private Label label_tk;
        private Label label2;
        private Button button1;
    }
}