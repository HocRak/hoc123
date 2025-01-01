using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDienHeThong
{
    public partial class DangKy : Form
    {
        Modify modify = new Modify();
        public DangKy()
        {
            InitializeComponent();
        }
        public bool checkAccount(string ac)
        {
            return Regex.IsMatch(ac, "^[a-zA-Z0-9]{9,}$");
        }

        public bool checkEmail(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9_.]{3,20}@gmail.com(.vn|)$");
        }
        private void button_DangKy_Click(object sender, EventArgs e)
        {
            string tentk = textBox_TenTaiKhoan.Text;
            string matkhau = textBox_MatKhau.Text;
            string xnmatkhau = textBox_XacNhanMatKhau.Text;
            string email = textBox_Email.Text;

            if (!checkAccount(tentk))
            {
                MessageBox.Show("Tên tài khoản phải có ít nhất 9 ký tự , bao gồm các chữ hoa và chữ thường");
                return;
            }

            if (!checkAccount(matkhau))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 9 ký tự, bao gồm các ký tự chữ và số, chữ hoa và chữ thường!");
                return;
            }

            if (xnmatkhau != matkhau)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp với mật khẩu đăng ký");
                return;
            }

            if (!checkEmail(email))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng email!");
                return;
            }

            string query = "Select * From TaiKhoan where Email = '" + email + "'";
            if (modify.TaiKhoans(query).Count() > 0)
            {
                MessageBox.Show("Email này đã được đăng ký");
                return;
            }

            try
            {
                string queryInsert = "Insert into TaiKhoan values ('" + tentk + "','" + matkhau + "','" + email + "')";
                modify.Command(queryInsert);
                MessageBox.Show("Đăng ký tài khoản thành công","Thông báo");
                Close();
            }
            catch
            {
                MessageBox.Show("Tên tài khoản này đã được đăng ký. Vui lòng đăng ký tên tài khoản khác !", "Thông báo");
            }
        }
    }
}
