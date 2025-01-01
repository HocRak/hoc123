using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace GiaoDienHeThong
{
    public partial class BaiTap : Form
    {
        private WebView2 webView;
        public BaiTap()
        {
            InitializeComponent();
        }

        private async void LoadWebView(string DSA)
        {
            // Đảm bảo khởi động WebView2 trước khi sử dụng
            await webView.EnsureCoreWebView2Async();
            webView.Source = new Uri(DSA);
        }

        private void BaiTap_Load(object sender, EventArgs e)
        {
            panel1.Width = Width;
            panel2.Width = Width;
            panel2.Height = Height - panel1.Height;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string DSA = "";
            if (comboBox1.SelectedIndex == 0)
            {
                DSA = "https://www.geeksforgeeks.org/explore?page=1&category=Hash&sortBy=submissions&itm_source=geeksforgeeks&itm_medium=main_header_outIndia&itm_campaign=DSA_Header";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                DSA = "https://www.geeksforgeeks.org/explore?page=1&category=Graph&sortBy=submissions&itm_source=geeksforgeeks&itm_medium=main_header_outIndia&itm_campaign=DSA_Header";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                DSA = "https://opendsa-server.cs.vt.edu/ODSA/Books/Everything/html/RedBlack.html";
            }
            panel2.Controls.Clear();
            webView = new WebView2
            {
                Dock = DockStyle.Fill
            };

            panel2.Controls.Add(webView);

            LoadWebView(DSA);
        }
    }
}
