namespace GiaoDienHeThong
{
    partial class QuenMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuenMatKhau));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            textBox_Email = new TextBox();
            button_LayMk = new Button();
            label_mk = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(254, 257);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(274, 65);
            label1.Name = "label1";
            label1.Size = new Size(156, 27);
            label1.TabIndex = 2;
            label1.Text = "Email đã đăng ký";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_Email
            // 
            textBox_Email.Location = new Point(274, 95);
            textBox_Email.Name = "textBox_Email";
            textBox_Email.Size = new Size(233, 27);
            textBox_Email.TabIndex = 6;
            // 
            // button_LayMk
            // 
            button_LayMk.BackColor = Color.Black;
            button_LayMk.FlatStyle = FlatStyle.Flat;
            button_LayMk.ForeColor = Color.White;
            button_LayMk.Location = new Point(274, 203);
            button_LayMk.Name = "button_LayMk";
            button_LayMk.Size = new Size(233, 46);
            button_LayMk.TabIndex = 10;
            button_LayMk.Text = "Lấy lại mật khẩu";
            button_LayMk.UseVisualStyleBackColor = false;
            button_LayMk.Click += button_LayMk_Click;
            // 
            // label_mk
            // 
            label_mk.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_mk.ForeColor = Color.Red;
            label_mk.Location = new Point(274, 141);
            label_mk.Name = "label_mk";
            label_mk.Size = new Size(233, 38);
            label_mk.TabIndex = 11;
            label_mk.Text = "label3";
            label_mk.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(274, 27);
            label2.Name = "label2";
            label2.Size = new Size(167, 25);
            label2.TabIndex = 12;
            label2.Text = "Quên mật khẩu";
            // 
            // QuenMatKhau
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(1, 36, 90);
            ClientSize = new Size(518, 257);
            Controls.Add(label2);
            Controls.Add(label_mk);
            Controls.Add(button_LayMk);
            Controls.Add(textBox_Email);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            MaximizeBox = false;
            Name = "QuenMatKhau";
            Text = "QUÊN MẬT KHẨU";
            Load += QuenMatKhau_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox textBox_Email;
        private Button button_LayMk;
        private Label label_mk;
        private Label label2;
    }
}