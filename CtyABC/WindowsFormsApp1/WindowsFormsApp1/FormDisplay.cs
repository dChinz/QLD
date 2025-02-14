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
    public partial class FormDisplay : Form
    {
        public FormDisplay()
        {
            InitializeComponent();

            buttonKhachHang.Tag = "khachhang";
            buttonHoaDon.Tag = "hoadon";
            buttonHangHoa.Tag = "hanghoa";
            buttonPThuChi.Tag = "pthuchi";
            buttonCTHD.Tag = "cthd";
        }

        private void buttonHangHoa_Click(object sender, EventArgs e)
        {
            if(sender is Button button && button.Tag is  string moduleName)
            {
                FormControl f = new FormControl(moduleName);
                f.Show();
            }
        }

        private void buttonKhachHang_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is string moduleName)
            {
                FormControl f = new FormControl(moduleName);
                f.Show();
            }
        }

        private void buttonHoaDon_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is string moduleName)
            {
                FormControl f = new FormControl(moduleName);
                f.Show();
            }
        }

        private void buttonPThuChi_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is string moduleName)
            {
                FormControl f = new FormControl(moduleName);
                f.Show();
            }
        }

        private void buttonCTHD_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is string moduleName)
            {
                FormControl f = new FormControl(moduleName);
                f.Show();
            }
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
