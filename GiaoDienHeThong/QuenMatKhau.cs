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
    public partial class QuenMatKhau : Form
    {
        Modify modify = new Modify();
        public QuenMatKhau()
        {
            InitializeComponent();
            label_mk.Text = "";
        }

        private void button_LayMk_Click(object sender, EventArgs e)
        {
            string email = textBox_Email.Text;
            if (email.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập email đăng ký!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            else
            {
                string query = " Select * From TaiKhoan where Email = '" + email + "' ";
                if (modify.TaiKhoans(query).Count != 0)
                {
                    label_mk.ForeColor = Color.Red;
                    label_mk.Text = " Mật khẩu đã đăng ký: " + modify.TaiKhoans(query)[0].Matkhau;
                }
                else
                {
                    label_mk.ForeColor = Color.Red;
                    label_mk.Text = "Email này chưa được đăng ký !";
                }
            }
        }

        private void QuenMatKhau_Load(object sender, EventArgs e)
        {

        }
    }
}
