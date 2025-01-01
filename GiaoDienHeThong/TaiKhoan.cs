using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaoDienHeThong
{
    internal class TaiKhoan
    {
        public TaiKhoan(string tenTaiKhoan, string matKhau)
        {
            TenTaiKhoan = tenTaiKhoan;
            MatKhau = matKhau;
        }

        private string TenTaiKhoan;
        private string MatKhau;

        public string Tentaikhoan{ get => TenTaiKhoan; set => TenTaiKhoan = value; }
        public string Matkhau { get => MatKhau; set => MatKhau = value; }
    }
}
