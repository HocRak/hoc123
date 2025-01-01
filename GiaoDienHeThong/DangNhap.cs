using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace GiaoDienHeThong
{
    public partial class DangNhap : Form
    {
        Modify modify = new Modify();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void linkLabel_QuenMk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhau quenMatKhau = new QuenMatKhau();
            quenMatKhau.ShowDialog();

        }

        private void linkLabel_Dangky_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKy dangky = new DangKy();
            dangky.ShowDialog();
        }

        private void button_DangNhap_Click(object sender, EventArgs e)
        {
            string tentk = textBox_TaiKhoan.Text;
            string matkhau = textBox_MatKhau.Text;
            if (tentk.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản");
                return;
            }
            else if (matkhau.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                return;
            }
            else
            {
                string query = "Select * from TaiKhoan where TenTaiKhoan ='" + tentk + "' and MatKhau = '" + matkhau + "' ";
                if (modify.TaiKhoans(query).Count() > 0)
                {
                    MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK);

                    CauTrucDuLieu cauTrucDuLieu = new CauTrucDuLieu();
                    cauTrucDuLieu.username = tentk;
                    cauTrucDuLieu.password = matkhau;
                    Hide();
                    cauTrucDuLieu.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
