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
using Microsoft.Reporting.WinForms;

namespace WindowsFormsApp1
{
    public partial class FormDanhSachDiem : Form
    {
        public FormDanhSachDiem()
        {
            InitializeComponent();
        }

        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader doc;
        string nguon = @"Data Source=DESKTOP-GK5VJ4R;Initial Catalog=LTMT4K14_HoangDucChinh_QLD;Integrated Security=True";
        string lenhsql;

        private void FormDanhSachDiem_Load(object sender, EventArgs e)
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
            this.reportViewer1.RefreshReport();
        }

        private void comboBoxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxNganh.Items.Clear();
            comboBoxLop.Items.Clear();
            comboBoxHocKy.Items.Clear();
            comboBoxHinhThuc.Items.Clear();
            comboBoxMonHoc.Items.Clear();
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
            comboBoxHocKy.Items.Clear();
            comboBoxHinhThuc.Items.Clear();
            comboBoxMonHoc.Items.Clear();
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
            //-------------------------------------------------------------------------------
            lenhsql = @"SELECT HocKy.TenHocKy
                        FROM   HocKy INNER JOIN
                               NganhHoc ON HocKy.ID_NganhHoc = NganhHoc.ID INNER JOIN
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
                comboBoxHocKy.Items.Add(doc[0]);
            }
            ketnoi.Close();
        }

        private void comboBoxHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxHinhThuc.Items.Clear();
            comboBoxMonHoc.Items.Clear();
            lenhsql = @"SELECT HinhThuc.HinhThuc
                        FROM   HinhThuc INNER JOIN
                                     HocKy ON HinhThuc.ID_HocKy = HocKy.ID INNER JOIN
                                     NganhHoc ON HocKy.ID_NganhHoc = NganhHoc.ID INNER JOIN
                                     Khoa ON NganhHoc.ID_Khoa = Khoa.ID
                        WHERE (Khoa.TenKhoa = @TenKhoa) AND (NganhHoc.TenNganh = @TenNganh) AND (HocKy.TenHocKy = @TenHocKy)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@TenNganh", SqlDbType.NVarChar);
            thuchien.Parameters["@TenNganh"].Value = comboBoxNganh.Text;
            thuchien.Parameters.Add("@TenKhoa", SqlDbType.NVarChar);
            thuchien.Parameters["@TenKhoa"].Value = comboBoxKhoa.Text;
            thuchien.Parameters.Add("@TenHocKy", SqlDbType.NVarChar);
            thuchien.Parameters["@TenHocKy"].Value = comboBoxHocKy.Text;
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            while (doc.Read())
            {
                comboBoxHinhThuc.Items.Add(doc[0]);
            }
            ketnoi.Close();
        }

        private void comboBoxHinhThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxMonHoc.Items.Clear();
            lenhsql = @"SELECT MonHoc.TenMonHoc
                        FROM   NganhHoc INNER JOIN
                                     Khoa ON NganhHoc.ID_Khoa = Khoa.ID INNER JOIN
                                     MonHoc INNER JOIN
                                     HinhThuc ON MonHoc.ID_HinhThuc = HinhThuc.ID INNER JOIN
                                     HocKy ON HinhThuc.ID_HocKy = HocKy.ID ON NganhHoc.ID = HocKy.ID_NganhHoc
                        WHERE (HinhThuc.HinhThuc = @HinhThuc) AND (HocKy.TenHocKy = @TenHocKy) AND (NganhHoc.TenNganh = @TenNganh) AND (Khoa.TenKhoa = @TenKhoa)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@TenNganh", SqlDbType.NVarChar);
            thuchien.Parameters["@TenNganh"].Value = comboBoxNganh.Text;
            thuchien.Parameters.Add("@TenKhoa", SqlDbType.NVarChar);
            thuchien.Parameters["@TenKhoa"].Value = comboBoxKhoa.Text;
            thuchien.Parameters.Add("@TenHocKy", SqlDbType.NVarChar);
            thuchien.Parameters["@TenHocKy"].Value = comboBoxHocKy.Text;
            thuchien.Parameters.Add("@HinhThuc", SqlDbType.NVarChar);
            thuchien.Parameters["@HinhThuc"].Value = comboBoxHinhThuc.Text;
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            while (doc.Read())
            {
                comboBoxMonHoc.Items.Add(doc[0]);
            }
            ketnoi.Close();
        }
        

        private void comboBoxMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxLanThi.Items.Clear();
            lenhsql = @"SELECT LanThi.LanThi
                        FROM   LanThi INNER JOIN
                                     MonHoc ON LanThi.ID_MonHoc = MonHoc.ID INNER JOIN
                                     HinhThuc ON MonHoc.ID_HinhThuc = HinhThuc.ID INNER JOIN
                                     HocKy ON HinhThuc.ID_HocKy = HocKy.ID INNER JOIN
                                     NganhHoc ON HocKy.ID_NganhHoc = NganhHoc.ID INNER JOIN
                                     Khoa ON NganhHoc.ID_Khoa = Khoa.ID
                        WHERE (MonHoc.TenMonHoc = @TenMonHoc) AND (HinhThuc.HinhThuc = @HinhThuc) AND (HocKy.TenHocKy = @TenHocKy) AND (NganhHoc.TenNganh = @TenNganh) AND (Khoa.TenKhoa = @TenKhoa)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@TenNganh", SqlDbType.NVarChar);
            thuchien.Parameters["@TenNganh"].Value = comboBoxNganh.Text;
            thuchien.Parameters.Add("@TenKhoa", SqlDbType.NVarChar);
            thuchien.Parameters["@TenKhoa"].Value = comboBoxKhoa.Text;
            thuchien.Parameters.Add("@TenHocKy", SqlDbType.NVarChar);
            thuchien.Parameters["@TenHocKy"].Value = comboBoxHocKy.Text;
            thuchien.Parameters.Add("@HinhThuc", SqlDbType.NVarChar);
            thuchien.Parameters["@HinhThuc"].Value = comboBoxHinhThuc.Text;
            thuchien.Parameters.Add("@TenMonHoc", SqlDbType.NVarChar);
            thuchien.Parameters["@TenMonHoc"].Value = comboBoxMonHoc.Text;
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            while (doc.Read())
            {
                comboBoxLanThi.Items.Add(doc[0]);
            }
            ketnoi.Close();
        }

        private void buttonTao_Click(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(nguon);
            ketnoi.Open();
            string sqlSV = @"SELECT   HinhThuc.HinhThuc, MonHoc.MaMonHoc, MonHoc.TenMonHoc, Diem.Diem, SinhVien.MaSinhVien, SinhVien.TenSinhVien, SinhVien.NgaySinh, LopHoc.TenLop, LopHoc.ID, LanThi.LanThi
                        FROM         SinhVien INNER JOIN
                                                 Khoa INNER JOIN
                                                 NganhHoc ON Khoa.ID = NganhHoc.ID_Khoa INNER JOIN
                                                 HocKy ON NganhHoc.ID = HocKy.ID_NganhHoc INNER JOIN
                                                 HinhThuc ON HocKy.ID = HinhThuc.ID_HocKy INNER JOIN
                                                 LopHoc ON NganhHoc.ID = LopHoc.ID_Nganh ON SinhVien.ID_Lop = LopHoc.ID INNER JOIN
                                                 Diem INNER JOIN
                                                 LanThi ON Diem.ID_LanThi = LanThi.ID ON SinhVien.ID = Diem.ID_SinhVien INNER JOIN
                                                 MonHoc ON HinhThuc.ID = MonHoc.ID_HinhThuc AND LanThi.ID_MonHoc = MonHoc.ID
                        WHERE     (Khoa.TenKhoa = @TenKhoa) AND (NganhHoc.TenNganh = @TenNganh) AND (HocKy.TenHocKy = @TenHocKy) AND (HinhThuc.HinhThuc = @HinhThuc) AND 
                         (MonHoc.TenMonHoc = @TenMonHoc) AND (LanThi.LanThi = @LanThi) AND (LopHoc.TenLop = @TenLop)";
            DataTable dtDiem = new DataTable();
            using (SqlCommand thuchien = new SqlCommand(sqlSV, ketnoi))
            {
                thuchien.Parameters.Add("@TenKhoa", SqlDbType.NVarChar).Value = comboBoxKhoa.Text;
                thuchien.Parameters.Add("@TenNganh", SqlDbType.NVarChar);
                thuchien.Parameters["@TenNganh"].Value = comboBoxNganh.Text;
                thuchien.Parameters.Add("@TenLop", SqlDbType.NVarChar);
                thuchien.Parameters["@TenLop"].Value = comboBoxLop.Text;
                thuchien.Parameters.Add("@TenHocKy", SqlDbType.NVarChar);
                thuchien.Parameters["@TenHocKy"].Value = comboBoxHocKy.Text;
                thuchien.Parameters.Add("@HinhThuc", SqlDbType.NVarChar);
                thuchien.Parameters["@HinhThuc"].Value = comboBoxHinhThuc.Text;
                thuchien.Parameters.Add("@TenMonHoc", SqlDbType.NVarChar);
                thuchien.Parameters["@TenMonHoc"].Value = comboBoxMonHoc.Text;
                thuchien.Parameters.Add("@LanThi", SqlDbType.NVarChar);
                thuchien.Parameters["@LanThi"].Value = comboBoxLanThi.Text;

                SqlDataAdapter sda = new SqlDataAdapter(thuchien);
                sda.Fill(dtDiem);
            }

            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "D:\\XDPHQLD\\QLD\\WindowsFormsApp1\\WindowsFormsApp1\\ReportDiem.rdlc";

            reportViewer1.LocalReport.DataSources.Clear();
            if (dtDiem.Rows.Count == 0)
            {
                MessageBox.Show("no data");
            }
            else
            {
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetDiem", dtDiem));
            }

            reportViewer1.RefreshReport();
            ketnoi.Close();
        }
    }
}
