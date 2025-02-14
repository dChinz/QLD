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
    public partial class FormDiem : Form
    {
        public FormDiem()
        {
            InitializeComponent();
        }

        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader doc;
        string nguon = @"Data Source=DESKTOP-GK5VJ4R;Initial Catalog=LTMT4K14_HoangDucChinh_QLD;Integrated Security=True";
        string lenhsql;

        private void FormDiem_Load(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
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
            comboBoxLop.Items.Clear();
            comboBoxHocKy.Items.Clear();
            comboBoxHinhThuc.Items.Clear();
            comboBoxMonHoc.Items.Clear();
            comboBoxLanThi.Items.Clear();
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
            comboBoxLanThi.Items.Clear();
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

        private void comboBoxLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            lenhsql = @"
        SELECT SinhVien.ID, SinhVien.MaSinhVien, SinhVien.TenSinhVien
        FROM   Khoa
        INNER JOIN NganhHoc ON Khoa.ID = NganhHoc.ID_Khoa
        INNER JOIN LopHoc ON NganhHoc.ID = LopHoc.ID_Nganh
        INNER JOIN SinhVien ON LopHoc.ID = SinhVien.ID_Lop
        WHERE Khoa.TenKhoa = @TenKhoa
          AND NganhHoc.TenNganh = @TenNganh
          AND LopHoc.TenLop = @TenLop
    ";

            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@TenKhoa", SqlDbType.NVarChar).Value = comboBoxKhoa.Text;
            thuchien.Parameters.Add("@TenNganh", SqlDbType.NVarChar).Value = comboBoxNganh.Text;
            thuchien.Parameters.Add("@TenLop", SqlDbType.NVarChar).Value = comboBoxLop.Text;

            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            while (doc.Read())
            {
                dataGridView.Rows.Add(doc[0].ToString(), doc[1].ToString(), doc[2].ToString());
            }
            ketnoi.Close();
        }


        private void comboBoxHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxHinhThuc.Items.Clear();
            comboBoxMonHoc.Items.Clear();
            comboBoxLanThi.Items.Clear();
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
            comboBoxLanThi.Items.Clear();
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

        int id_monhoc;
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
            //---------------------------------------------------------
            lenhsql = @"SELECT MonHoc.ID
                        FROM   MonHoc INNER JOIN
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
                id_monhoc = int.Parse(doc[0].ToString());
            }
            ketnoi.Close();
        }

        string lanthiValue;
        string monHoc;
        int id_lanthi;
        private void comboBoxLanThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            lenhsql = @"SELECT LanThi.ID, LanThi.LanThi, MonHoc.TenMonHoc
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
                id_lanthi = Convert.ToInt32(doc[0].ToString());
                monHoc = doc[2].ToString();
               lanthiValue = doc[1].ToString();
            }
            ketnoi.Close();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.Cells[5].Value = lanthiValue;
                row.Cells[4].Value = monHoc;
            }

            lenhsql = @"SELECT ID_SinhVien, Diem 
                FROM Diem 
                WHERE ID_MonHoc = @ID_MonHoc 
                  AND ID_LanThi = @ID_LanThi";

            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@ID_MonHoc", SqlDbType.Int).Value = id_monhoc;
            thuchien.Parameters.Add("@ID_LanThi", SqlDbType.Int).Value = id_lanthi;

            ketnoi.Open();
            doc = thuchien.ExecuteReader();

            // Lưu điểm của sinh viên vào Dictionary để dễ dàng tra cứu
            Dictionary<int, float> diemSinhVien = new Dictionary<int, float>();

            while (doc.Read())
            {
                int idSV = Convert.ToInt32(doc["ID_SinhVien"]);
                float diem = float.Parse(doc["Diem"].ToString());
                diemSinhVien[idSV] = diem;
            }
            ketnoi.Close();

            // Cập nhật điểm vào dataGridView
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    int idSV = Convert.ToInt32(row.Cells[0].Value);
                    if (diemSinhVien.ContainsKey(idSV))
                    {
                        row.Cells[3].Value = diemSinhVien[idSV]; // Gán điểm vào cột điểm
                    }
                }
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int idSV = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value);

            float diem = float.Parse(dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString());

            lenhsql = @"INSERT INTO Diem
                                     (ID_SinhVien, ID_MonHoc, Diem, ID_LanThi)
                        VALUES (@ID_SinhVien,@ID_MonHoc,@Diem,@ID_LanThi)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@ID_SinhVien", SqlDbType.Int).Value = idSV;
            thuchien.Parameters.Add("@ID_MonHoc", SqlDbType.Int).Value = id_monhoc;
            thuchien.Parameters.Add("@ID_LanThi", SqlDbType.Int).Value = id_lanthi;
            thuchien.Parameters.Add("@Diem", SqlDbType.Float).Value = diem;
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
        }
    }
}
