
using banluu;
using Microsoft.Web.WebView2.WinForms;
using Project___Review_RBT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDienHeThong
{
    public partial class CauTrucDuLieu : Form
    {
        public string username;
        public string password;

        public CauTrucDuLieu()
        {
            InitializeComponent();
        }

        private void CauTrucDuLieu_Load(object sender, EventArgs e)
        {
            panel_main.Width = Width - panel_Tool.Width;
            panel_main.Height = Height;
            panel_main.GetType()
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(panel_main, true, null);
        }

        private void button_RBT_Click(object sender, EventArgs e)
        {
            RedBlackForm redBlackForm = new RedBlackForm();
            HienThi(redBlackForm);
        }


        private void HienThi(Form form)
        {
            form.MdiParent = this;
            panel_main.Controls.Clear();
            form.TopLevel = false;

            panel_main.Controls.Add(form);

            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Size = panel_main.Size;
            form.WindowState = FormWindowState.Maximized;

            form.Show();
        }


        private void button_user_Click(object sender, EventArgs e)
        {
            User us = new();

            us.tentaikhoan = username;
            us.matkhau = password;

            us.ShowDialog();
        }

        private void button_hash_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            HienThi(form1 as Form1);
        }

        private void button_LiThuyet_Click(object sender, EventArgs e)
        {
            KienThuc kienThuc = new KienThuc();
            HienThi(kienThuc);
        }

        private void button_BaiTap_Click(object sender, EventArgs e)
        {
            BaiTap baiTap = new BaiTap();
            HienThi(baiTap);
        }

        private void button_graph_Click(object sender, EventArgs e)
        {
            Project.dothi dothi = new Project.dothi();
            HienThi(dothi);
        }
    }
}
