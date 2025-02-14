using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormBaoCaoPThuChi : Form
    {
        public FormBaoCaoPThuChi()
        {
            InitializeComponent();
        }

        private void FormBaoCaoPThuChi_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader doc;
        string nguon = @"Data Source=DESKTOP-GK5VJ4R;Initial Catalog=CtyABC;Integrated Security=True";



        private void button1_Click(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(nguon);
            ketnoi.Open();
            string sqlSV = @"SELECT PhieuThuChi.KieuPhieu, PhieuThuChi.Ngay, KhachHang.TenKH, KhachHang.DiaChi, PhieuThuChi.SoPhieu, KhachHang.MaKH, KhachHang.SoDT, PhieuThuChi.SoTien
                            FROM  PhieuThuChi INNER JOIN
                                    KhachHang ON PhieuThuChi.MaKH = KhachHang.MaKH
                            WHERE (PhieuThuChi.SoPhieu = @SoPhieu)";
      
            DataTable PTHuChi = new DataTable();
            using (SqlCommand thuchien = new SqlCommand(sqlSV, ketnoi))
            {
                thuchien.Parameters.Add("@SoPhieu", SqlDbType.Int).Value = textBox1.Text;

                SqlDataAdapter sda = new SqlDataAdapter(thuchien);
                sda.Fill(PTHuChi);
            }

            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "D:\\XDPHQLD\\CtyABC\\WindowsFormsApp1\\WindowsFormsApp1\\ReportPThuChiTheoKH.rdlc";

            reportViewer1.LocalReport.DataSources.Clear();
            if (PTHuChi.Rows.Count == 0)
            {
                MessageBox.Show("no data");
            }
            else
            {
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetPThuChiTheoKH", PTHuChi));
            }

            reportViewer1.RefreshReport();
            ketnoi.Close();
        }
    }
}
