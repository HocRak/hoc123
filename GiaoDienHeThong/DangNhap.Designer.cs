namespace GiaoDienHeThong
{
    partial class DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            pictureBox2 = new PictureBox();
            textBox_TaiKhoan = new TextBox();
            button_DangNhap = new Button();
            linkLabel_Dangky = new LinkLabel();
            linkLabel_QuenMk = new LinkLabel();
            pictureBox3 = new PictureBox();
            textBox_MatKhau = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(30, 85);
            pictureBox2.Margin = new Padding(0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(38, 34);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // textBox_TaiKhoan
            // 
            textBox_TaiKhoan.BackColor = SystemColors.Control;
            textBox_TaiKhoan.Font = new Font("Segoe UI", 12F);
            textBox_TaiKhoan.Location = new Point(77, 85);
            textBox_TaiKhoan.Name = "textBox_TaiKhoan";
            textBox_TaiKhoan.Size = new Size(313, 34);
            textBox_TaiKhoan.TabIndex = 3;
            // 
            // button_DangNhap
            // 
            button_DangNhap.BackColor = Color.Black;
            button_DangNhap.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            button_DangNhap.FlatAppearance.BorderSize = 0;
            button_DangNhap.FlatStyle = FlatStyle.Flat;
            button_DangNhap.Font = new Font("Tahoma", 10.2F);
            button_DangNhap.ForeColor = Color.White;
            button_DangNhap.Location = new Point(276, 244);
            button_DangNhap.Name = "button_DangNhap";
            button_DangNhap.Size = new Size(114, 33);
            button_DangNhap.TabIndex = 5;
            button_DangNhap.Text = "Đăng nhập";
            button_DangNhap.UseVisualStyleBackColor = false;
            button_DangNhap.Click += button_DangNhap_Click;
            // 
            // linkLabel_Dangky
            // 
            linkLabel_Dangky.AutoSize = true;
            linkLabel_Dangky.BackColor = Color.Transparent;
            linkLabel_Dangky.Font = new Font("Tahoma", 10.2F);
            linkLabel_Dangky.ForeColor = Color.White;
            linkLabel_Dangky.LinkColor = Color.White;
            linkLabel_Dangky.Location = new Point(77, 205);
            linkLabel_Dangky.Name = "linkLabel_Dangky";
            linkLabel_Dangky.Size = new Size(175, 21);
            linkLabel_Dangky.TabIndex = 6;
            linkLabel_Dangky.TabStop = true;
            linkLabel_Dangky.Text = "Đăng ký tài khoản mới";
            linkLabel_Dangky.TextAlign = ContentAlignment.MiddleCenter;
            linkLabel_Dangky.LinkClicked += linkLabel_Dangky_LinkClicked;
            // 
            // linkLabel_QuenMk
            // 
            linkLabel_QuenMk.BackColor = Color.Transparent;
            linkLabel_QuenMk.Font = new Font("Tahoma", 10.2F);
            linkLabel_QuenMk.LinkColor = Color.White;
            linkLabel_QuenMk.Location = new Point(267, 205);
            linkLabel_QuenMk.Name = "linkLabel_QuenMk";
            linkLabel_QuenMk.Size = new Size(123, 21);
            linkLabel_QuenMk.TabIndex = 7;
            linkLabel_QuenMk.TabStop = true;
            linkLabel_QuenMk.Text = "Quên mật khẩu";
            linkLabel_QuenMk.LinkClicked += linkLabel_QuenMk_LinkClicked;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = SystemColors.Control;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(30, 164);
            pictureBox3.Margin = new Padding(0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(38, 34);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // textBox_MatKhau
            // 
            textBox_MatKhau.BackColor = SystemColors.Control;
            textBox_MatKhau.Font = new Font("Segoe UI", 12F);
            textBox_MatKhau.Location = new Point(77, 161);
            textBox_MatKhau.Name = "textBox_MatKhau";
            textBox_MatKhau.PasswordChar = '*';
            textBox_MatKhau.Size = new Size(313, 34);
            textBox_MatKhau.TabIndex = 10;
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 15;
            // 
            // panel2
            // 
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(textBox_MatKhau);
            panel2.Controls.Add(linkLabel_Dangky);
            panel2.Controls.Add(linkLabel_QuenMk);
            panel2.Controls.Add(textBox_TaiKhoan);
            panel2.Controls.Add(button_DangNhap);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(457, 306);
            panel2.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Tahoma", 16.2F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(77, 23);
            label4.Name = "label4";
            label4.Size = new Size(97, 34);
            label4.TabIndex = 13;
            label4.Text = "LOGIN";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.ForeColor = Color.White;
            label3.Location = new Point(77, 138);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 12;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.White;
            label2.Location = new Point(77, 62);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 11;
            label2.Text = "Username";
            // 
            // DangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuText;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(457, 306);
            Controls.Add(panel2);
            Controls.Add(label1);
            ForeColor = SystemColors.ControlDarkDark;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "DangNhap";
            Text = "ĐĂNG NHẬP";
            FormClosing += DangNhap_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox2;
        private TextBox textBox_TaiKhoan;
        private Button button_DangNhap;
        private LinkLabel linkLabel_Dangky;
        private LinkLabel linkLabel_QuenMk;
        private PictureBox pictureBox3;
        private TextBox textBox_MatKhau;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}