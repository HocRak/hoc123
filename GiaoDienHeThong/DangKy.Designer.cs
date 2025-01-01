namespace GiaoDienHeThong
{
    partial class DangKy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangKy));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox_TenTaiKhoan = new TextBox();
            textBox_MatKhau = new TextBox();
            textBox_XacNhanMatKhau = new TextBox();
            textBox_Email = new TextBox();
            button_DangKy = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 10.8F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(88, 93);
            label1.Name = "label1";
            label1.Size = new Size(126, 27);
            label1.TabIndex = 1;
            label1.Text = "Tên tài khoản:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Times New Roman", 10.8F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(88, 153);
            label2.Name = "label2";
            label2.Size = new Size(90, 27);
            label2.TabIndex = 2;
            label2.Text = "Mật khẩu:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Times New Roman", 10.8F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(88, 204);
            label3.Name = "label3";
            label3.Size = new Size(169, 27);
            label3.TabIndex = 3;
            label3.Text = "Xác nhận mật khẩu:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Times New Roman", 10.8F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(88, 266);
            label4.Name = "label4";
            label4.Size = new Size(141, 27);
            label4.TabIndex = 4;
            label4.Text = "Email đăng ký:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_TenTaiKhoan
            // 
            textBox_TenTaiKhoan.Location = new Point(251, 93);
            textBox_TenTaiKhoan.Name = "textBox_TenTaiKhoan";
            textBox_TenTaiKhoan.Size = new Size(265, 27);
            textBox_TenTaiKhoan.TabIndex = 5;
            // 
            // textBox_MatKhau
            // 
            textBox_MatKhau.Location = new Point(251, 153);
            textBox_MatKhau.Name = "textBox_MatKhau";
            textBox_MatKhau.PasswordChar = '*';
            textBox_MatKhau.Size = new Size(265, 27);
            textBox_MatKhau.TabIndex = 6;
            // 
            // textBox_XacNhanMatKhau
            // 
            textBox_XacNhanMatKhau.Location = new Point(251, 204);
            textBox_XacNhanMatKhau.Name = "textBox_XacNhanMatKhau";
            textBox_XacNhanMatKhau.PasswordChar = '*';
            textBox_XacNhanMatKhau.Size = new Size(265, 27);
            textBox_XacNhanMatKhau.TabIndex = 7;
            // 
            // textBox_Email
            // 
            textBox_Email.Location = new Point(251, 266);
            textBox_Email.Name = "textBox_Email";
            textBox_Email.Size = new Size(265, 27);
            textBox_Email.TabIndex = 8;
            // 
            // button_DangKy
            // 
            button_DangKy.BackColor = Color.White;
            button_DangKy.FlatStyle = FlatStyle.Flat;
            button_DangKy.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_DangKy.ForeColor = Color.Black;
            button_DangKy.Location = new Point(433, 311);
            button_DangKy.Name = "button_DangKy";
            button_DangKy.Size = new Size(137, 34);
            button_DangKy.TabIndex = 9;
            button_DangKy.Text = "Đăng ký";
            button_DangKy.UseVisualStyleBackColor = false;
            button_DangKy.Click += button_DangKy_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.Window;
            label5.Location = new Point(88, 45);
            label5.Name = "label5";
            label5.Size = new Size(199, 23);
            label5.TabIndex = 10;
            label5.Text = "Đăng ký tài khoản mới";
            // 
            // DangKy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(226, 252, 249);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(623, 386);
            Controls.Add(label5);
            Controls.Add(button_DangKy);
            Controls.Add(textBox_Email);
            Controls.Add(textBox_XacNhanMatKhau);
            Controls.Add(textBox_MatKhau);
            Controls.Add(textBox_TenTaiKhoan);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "DangKy";
            Text = "ĐĂNG KÝ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox_TenTaiKhoan;
        private TextBox textBox_MatKhau;
        private TextBox textBox_XacNhanMatKhau;
        private TextBox textBox_Email;
        private Button button_DangKy;
        private Label label5;
        
    }
}