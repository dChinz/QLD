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
    public partial class FormMonSVChuaQua : Form
    {
        public FormMonSVChuaQua()
        {
            InitializeComponent();
        }

        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader doc;
        string nguon = @"Data Source=DESKTOP-GK5VJ4R;Initial Catalog=LTMT4K14_HoangDucChinh_QLD;Integrated Security=True";
        string lenhsql;

        private void FormMonSVChuaQua_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(nguon);
            lenhsql = @"SELECT TenKhoa
                        FROM   Khoa";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            while (doc.Read())
            {
                comboBoxKhoa.Items.Add(doc[0]);
            }
            ketnoi.Close();
        }

        private void comboBoxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxNganh.Items.Clear();
            lenhsql = @"SELECT NganhHoc.TenNganh, Khoa.TenKhoa
                        FROM   NganhHoc INNER JOIN
                             Khoa ON NganhHoc.ID_Khoa = Khoa.ID
                        WHERE (Khoa.TenKhoa = @TenKhoa)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@TenKhoa", SqlDbType.NVarChar);
            thuchien.Parameters["@TenKhoa"].Value = comboBoxKhoa.Text;
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            while (doc.Read())
            {
                comboBoxNganh.Items.Add(doc[0]);
            }
            ketnoi.Close();
        }

        private void comboBoxNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxLop.Items.Clear();
            lenhsql = @"SELECT LopHoc.TenLop
                        FROM   LopHoc INNER JOIN
                                     NganhHoc ON LopHoc.ID_Nganh = NganhHoc.ID INNER JOIN
                                     Khoa ON NganhHoc.ID_Khoa = Khoa.ID
                        WHERE (NganhHoc.TenNganh = @TenNganh) AND (Khoa.TenKhoa = @TenKhoa)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@TenNganh", SqlDbType.NVarChar);
            thuchien.Parameters["@TenNganh"].Value = comboBoxNganh.Text;
            thuchien.Parameters.Add("@TenKhoa", SqlDbType.NVarChar);
            thuchien.Parameters["@TenKhoa"].Value = comboBoxKhoa.Text;
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            while (doc.Read())
            {
                comboBoxLop.Items.Add(doc[0]);
            }
            ketnoi.Close();
        }

        private void comboBoxLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxSV.Items.Clear();
            lenhsql = @"SELECT SinhVien.TenSinhVien
                        FROM   SinhVien INNER JOIN
                                     LopHoc ON SinhVien.ID_Lop = LopHoc.ID INNER JOIN
                                     NganhHoc ON LopHoc.ID_Nganh = NganhHoc.ID INNER JOIN
                                     Khoa ON NganhHoc.ID_Khoa = Khoa.ID
                        WHERE (LopHoc.TenLop = @TenLop) AND (NganhHoc.TenNganh = @TenNganh) AND (Khoa.TenKhoa = @TenKhoa)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@TenNganh", SqlDbType.NVarChar);
            thuchien.Parameters["@TenNganh"].Value = comboBoxNganh.Text;
            thuchien.Parameters.Add("@TenKhoa", SqlDbType.NVarChar);
            thuchien.Parameters["@TenKhoa"].Value = comboBoxKhoa.Text;
            thuchien.Parameters.Add("@TenLop", SqlDbType.NVarChar);
            thuchien.Parameters["@TenLop"].Value = comboBoxLop.Text;
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            while (doc.Read())
            {
                comboBoxSV.Items.Add(doc[0]);
            }
            ketnoi.Close();
        }

        private void buttonTao_Click(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(nguon);
            ketnoi.Open();
            string sqlSV = @"SELECT SinhVien.TenSinhVien, SinhVien.MaSinhVien, SinhVien.NgaySinh, MonHoc.TenMonHoc,
                        CASE 
                                WHEN COUNT(LanThi.LanThi) = 1 THEN MAX(Diem.Diem)
                                ELSE SUM(
                                    CASE WHEN LanThi.LanThi = 1 THEN Diem.Diem * 0.2 ELSE 0 END + 
                                    CASE WHEN LanThi.LanThi = 2 THEN Diem.Diem * 0.8 ELSE 0 END
                                )
                            END AS DiemCuoiCung
                            FROM   HocKy INNER JOIN
                             Khoa INNER JOIN
                             NganhHoc ON Khoa.ID = NganhHoc.ID_Khoa INNER JOIN
                             LopHoc ON NganhHoc.ID = LopHoc.ID_Nganh INNER JOIN
                             SinhVien ON LopHoc.ID = SinhVien.ID_Lop INNER JOIN
                             Diem ON SinhVien.ID = Diem.ID_SinhVien ON HocKy.ID_NganhHoc = NganhHoc.ID INNER JOIN
                             HinhThuc INNER JOIN
                             MonHoc ON HinhThuc.ID = MonHoc.ID_HinhThuc ON HocKy.ID = HinhThuc.ID_HocKy INNER JOIN
                             LanThi ON Diem.ID_LanThi = LanThi.ID AND MonHoc.ID = LanThi.ID_MonHoc
                            WHERE (Khoa.TenKhoa = @TenKhoa) AND (NganhHoc.TenNganh = @TenNganh) AND (LopHoc.TenLop = @TenLop) AND (SinhVien.TenSinhVien = @TenSinhVien) AND Diem.Diem < 5
                            GROUP BY 
                                SinhVien.TenSinhVien, 
                                SinhVien.MaSinhVien, 
                                SinhVien.NgaySinh, 
                                MonHoc.TenMonHoc";
            DataTable dtDiem = new DataTable();
            using (SqlCommand thuchien = new SqlCommand(sqlSV, ketnoi))
            {
                thuchien.Parameters.Add("@TenKhoa", SqlDbType.NVarChar).Value = comboBoxKhoa.Text;
                thuchien.Parameters.Add("@TenNganh", SqlDbType.NVarChar);
                thuchien.Parameters["@TenNganh"].Value = comboBoxNganh.Text;
                thuchien.Parameters.Add("@TenLop", SqlDbType.NVarChar);
                thuchien.Parameters["@TenLop"].Value = comboBoxLop.Text;
                thuchien.Parameters.Add("@TenSinhVien", SqlDbType.NVarChar).Value = comboBoxSV.Text;

                SqlDataAdapter sda = new SqlDataAdapter(thuchien);
                sda.Fill(dtDiem);
            }

            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "D:\\XDPHQLD\\QLD\\WindowsFormsApp1\\WindowsFormsApp1\\ReportCho1SV.rdlc";

            reportViewer1.LocalReport.DataSources.Clear();
            if (dtDiem.Rows.Count == 0)
            {
                MessageBox.Show("no data");
            }
            else
            {
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet", dtDiem));
            }

            reportViewer1.RefreshReport();
            ketnoi.Close();
        }
    }
}
