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
    public partial class FormReportHD : Form
    {
        public FormReportHD()
        {
            InitializeComponent();
        }

        private void FormReportHD_Load(object sender, EventArgs e)
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
            string sqlSV = @"SELECT        KhachHang.TenKH, KhachHang.DiaChi, KhachHang.SoDT, HoaDonNhapXuat.KieuHD, HoaDonNhapXuat.Ngay, HoaDonNhapXuat.MaKH, HoaDonNhapXuat.SoTienTT, CTHoaDonNhapXuat.SoHD, CTHoaDonNhapXuat.MaHang, 
                         CTHoaDonNhapXuat.SoLuong, CTHoaDonNhapXuat.Gia, Hang.TenHang, Hang.DonViTinh, Hang.DonGia
                            FROM            KhachHang INNER JOIN
                         HoaDonNhapXuat ON KhachHang.MaKH = HoaDonNhapXuat.MaKH INNER JOIN
                         CTHoaDonNhapXuat ON HoaDonNhapXuat.SoHD = CTHoaDonNhapXuat.SoHD INNER JOIN
                         Hang ON CTHoaDonNhapXuat.MaHang = Hang.MaHang
                            WHERE        (CTHoaDonNhapXuat.SoHD = @SoHD)";

            DataTable PTHuChi = new DataTable();
            using (SqlCommand thuchien = new SqlCommand(sqlSV, ketnoi))
            {
                thuchien.Parameters.Add("@SoHD", SqlDbType.Int).Value = textBox1.Text;

                SqlDataAdapter sda = new SqlDataAdapter(thuchien);
                sda.Fill(PTHuChi);
            }

            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "D:\\XDPHQLD\\CtyABC\\WindowsFormsApp1\\WindowsFormsApp1\\ReportHD.rdlc";

            reportViewer1.LocalReport.DataSources.Clear();
            if (PTHuChi.Rows.Count == 0)
            {
                MessageBox.Show("no data");
            }
            else
            {
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetHD", PTHuChi));
            }

            reportViewer1.RefreshReport();
            ketnoi.Close();
        }
    }
}
