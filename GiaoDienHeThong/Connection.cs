using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

namespace GiaoDienHeThong
{
    internal class Connection
    {
        private static string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\ĐỒ ÁN CUỐI KỲ IT008\Do-An-Cuoi-Ky-IT008\Mô Phỏng Cây Đỏ Đen\Form Main\TaiKhoan.mdf"";Integrated Security=True";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
