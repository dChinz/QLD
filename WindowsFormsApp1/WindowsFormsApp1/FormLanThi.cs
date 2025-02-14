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
    public partial class FormLanThi : Form
    {
        public FormLanThi()
        {
            InitializeComponent();
        }

        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader doc;
        string nguon = @"Data Source=DESKTOP-GK5VJ4R;Initial Catalog=LTMT4K14_HoangDucChinh_QLD;Integrated Security=True";
        string lenhsql;

        private void FormLanThi_Load(object sender, EventArgs e)
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
            lenhsql = @"SELECT NganhHoc.TenNganh
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
            hien();
        }

        private void comboBoxNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            hien();
        }

        private void comboBoxHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxHinhThuc.Items.Clear();
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
            hien();
        }

        private void comboBoxHinhThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            hien();
        }

        int id_monhoc;
        private void comboBoxMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            lenhsql = @"SELECT MonHoc.ID
                        FROM   NganhHoc INNER JOIN
                                     Khoa ON NganhHoc.ID_Khoa = Khoa.ID INNER JOIN
                                     MonHoc INNER JOIN
                                     HinhThuc ON MonHoc.ID_HinhThuc = HinhThuc.ID INNER JOIN
                                     HocKy ON HinhThuc.ID_HocKy = HocKy.ID ON NganhHoc.ID = HocKy.ID_NganhHoc
                        WHERE (MonHoc.TenMonHoc = @TenMonHoc) AND (HinhThuc.HinhThuc = @HinhThuc) AND (HocKy.TenHocKy = @TenHocKy) AND (NganhHoc.TenNganh = @TenNganh) AND (Khoa.TenKhoa = @TenKhoa)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@TenMonHoc", SqlDbType.NVarChar);
            thuchien.Parameters["@TenMonHoc"].Value = comboBoxMonHoc.Text;
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
                id_monhoc = int.Parse(doc[0].ToString());
            }
            ketnoi.Close();
            hien();
        }

        void hien()
        {
            dataGridView.Rows.Clear();
            lenhsql = @"SELECT LanThi.ID, LanThi.LanThi, LanThi.NgayThi, LanThi.ID_MonHoc
                        FROM   LanThi INNER JOIN
                                     MonHoc ON LanThi.ID_MonHoc = MonHoc.ID INNER JOIN
                                     HinhThuc ON MonHoc.ID_HinhThuc = HinhThuc.ID INNER JOIN
                                     HocKy ON HinhThuc.ID_HocKy = HocKy.ID INNER JOIN
                                     NganhHoc ON HocKy.ID_NganhHoc = NganhHoc.ID INNER JOIN
                                     Khoa ON NganhHoc.ID_Khoa = Khoa.ID
                        WHERE (MonHoc.TenMonHoc = @TenMonHoc) AND (HinhThuc.HinhThuc = @HinhThuc) AND (HocKy.TenHocKy = @TenHocKy) AND (NganhHoc.TenNganh = @TenNganh) AND (Khoa.TenKhoa = @TenKhoa)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@TenMonHoc", SqlDbType.NVarChar);
            thuchien.Parameters["@TenMonHoc"].Value = comboBoxMonHoc.Text;
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
            int i = 0;
            while (doc.Read())
            {
                dataGridView.Rows.Add();
                dataGridView.Rows[i].Cells[0].Value = doc[0].ToString();
                dataGridView.Rows[i].Cells[1].Value = doc[1].ToString();
                dataGridView.Rows[i].Cells[2].Value = Convert.ToDateTime(doc[2]).ToString("dd/MM/yyyy");
                dataGridView.Rows[i].Cells[3].Value = doc[3].ToString();
                i++;
            }
            ketnoi.Close();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            lenhsql = @"INSERT INTO LanThi
                                     (LanThi, NgayThi, ID_MonHoc)
                        VALUES (@LanThi,@NgayThi,@ID_MonHoc)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@LanThi", SqlDbType.Int);
            thuchien.Parameters["@LanThi"].Value = int.Parse(textBoxLanThi.Text);
            thuchien.Parameters.Add("@NgayThi", SqlDbType.Date);
            thuchien.Parameters["@NgayThi"].Value = DateTime.Parse(textBoxNgayThi.Text);
            thuchien.Parameters.Add("@ID_MonHoc", SqlDbType.Int);
            thuchien.Parameters["@ID_MonHoc"].Value = id_monhoc;
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hien();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            lenhsql = @"UPDATE LanThi
                        SET       LanThi = @LanThi, NgayThi = @NgayThi
                        WHERE (ID = @ID)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@LanThi", SqlDbType.Int);
            thuchien.Parameters["@LanThi"].Value = int.Parse(textBoxLanThi.Text);
            thuchien.Parameters.Add("@NgayThi", SqlDbType.Date);
            thuchien.Parameters["@NgayThi"].Value = DateTime.Parse(textBoxNgayThi.Text);
            thuchien.Parameters.Add("@ID", SqlDbType.Date);
            thuchien.Parameters["@ID"].Value = int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString());
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hien();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            DialogResult D = MessageBox.Show("Xóa ID " + dataGridView.CurrentRow.Cells[1].Value.ToString() + "?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (D == DialogResult.Yes)
            {
                lenhsql = @"DELETE FROM LanThi
                            WHERE (ID = @Original_ID)";
                thuchien = new SqlCommand(lenhsql, ketnoi);
                thuchien.Parameters.Add("@Original_ID", SqlDbType.Int);
                thuchien.Parameters["@Original_ID"].Value = int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString());
                ketnoi.Open();
                thuchien.ExecuteNonQuery();
                ketnoi.Close();
                hien();
            }
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            DialogResult D = MessageBox.Show("Thoát", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (D == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxLanThi.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            textBoxNgayThi.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
