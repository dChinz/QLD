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
    public partial class FormControl : Form
    {
        private string _moduleName;

        public FormControl(string moduleName)
        {
            InitializeComponent();

            _moduleName = moduleName;
        }

        private void buttonCapNhat_Click(object sender, EventArgs e)
        {
            switch(_moduleName)
            {
                case "hanghoa":
                    FormHang formHang = new FormHang();
                    formHang.Show();
                    break;
                case "khachhang":
                    FormKH formKH = new FormKH();
                    formKH.Show();
                    break;
                case "hoadon":
                    FormHD formHD = new FormHD();
                    formHD.Show();
                    break;
                case "pthuchi":
                    FormPThuChi formPThuChi = new FormPThuChi();
                    formPThuChi.Show();
                    break;
                case "cthd":
                    FormCTHD formCTHD = new FormCTHD();
                    formCTHD.Show();
                    break;
                default:
                    MessageBox.Show("Không có module hợp lệ");
                    break;
            }
        }

        private void buttonXuLi_Click(object sender, EventArgs e)
        {
            FormXuLy f = new FormXuLy();
            f.Show();
        }

        private void buttonThongKe_Click(object sender, EventArgs e)
        {
           

            switch (_moduleName)
            {
                case "hanghoa":
                    
                    break;
                case "khachhang":
                   
                    break;
                case "hoadon":
                   FormReportHD formReportHD = new FormReportHD();
                    formReportHD.Show();
                    break;
                case "pthuchi":
                    FormBaoCaoPThuChi f = new FormBaoCaoPThuChi();
                    f.Show();
                    break;
                case "cthd":
                    
                    break;
                default:
                    MessageBox.Show("Không có module hợp lệ");
                    break;
            }
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormControl_Load(object sender, EventArgs e)
        {

        }
    }
}
