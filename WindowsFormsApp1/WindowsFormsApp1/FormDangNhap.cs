using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }
        public bool admin = false;

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            if(textBoxDangNhap.Text == "admin" && textBoxMatKhau.Text == "123456")
            {
                ClassDangNhap.DangNhap = true;
                MessageBox.Show("Đăng nhập thành công!!", "chú ý",MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                ClassDangNhap.DangNhap = false;
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
