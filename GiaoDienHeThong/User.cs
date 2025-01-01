using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDienHeThong
{
    public partial class User : Form
    {
        public string tentaikhoan;
        public string matkhau;
        public User()
        {
            InitializeComponent();

        }

        private void button_DangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn đăng xuất không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Hide();

                CauTrucDuLieu formB = (CauTrucDuLieu)Application.OpenForms["CauTrucDuLieu"];
                formB.Hide();

                DangNhap dangNhap = new DangNhap();
                dangNhap.ShowDialog();
            }
        }

        private void User_Load(object sender, EventArgs e)
        {
            label_tk.Text = tentaikhoan;
            label_matkhau.Text = matkhau;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
