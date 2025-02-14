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
    public partial class FormHinhThuc : Form
    {
        public FormHinhThuc()
        {
            InitializeComponent();
        }

        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader doc;
        string nguon = @"Data Source=DESKTOP-GK5VJ4R;Initial Catalog=LTMT4K14_HoangDucChinh_QLD;Integrated Security=True";
        string lenhsql;

        private void FormHinhThuc_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(nguon);
            dataGridView.Rows.Clear();
            comboBoxNganh.Items.Clear();
            comboBoxHocKy.Items.Clear();
            lenhsql = @"SELECT TenKhoa
                        FROM   Khoa";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            while(doc.Read())
            {
                comboBoxKhoa.Items.Add(doc[0]);
            }
            ketnoi.Close();
        }

        private void comboBoxNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            comboBoxHocKy.Items.Clear();
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

        private void comboBoxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
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
            hien();
        }

        void hien()
        {
            dataGridView.Rows.Clear();
            lenhsql = @"SELECT HinhThuc.ID, HinhThuc.HinhThuc, HinhThuc.ID_HocKy
                        FROM   HinhThuc INNER JOIN
                                     HocKy ON HinhThuc.ID_HocKy = HocKy.ID INNER JOIN
                                     NganhHoc ON HocKy.ID_NganhHoc = NganhHoc.ID INNER JOIN
                                     Khoa ON NganhHoc.ID_Khoa = Khoa.ID
                        WHERE (HocKy.TenHocKy = @TenHocKy) AND (NganhHoc.TenNganh = @TenNganh) AND (Khoa.TenKhoa = @TenKhoa)";
            thuchien = new SqlCommand(lenhsql,  ketnoi);
            thuchien.Parameters.Add("@TenNganh", SqlDbType.NVarChar);
            thuchien.Parameters["@TenNganh"].Value = comboBoxNganh.Text;
            thuchien.Parameters.Add("@TenKhoa", SqlDbType.NVarChar);
            thuchien.Parameters["@TenKhoa"].Value = comboBoxKhoa.Text;
            thuchien.Parameters.Add("@TenHocKy", SqlDbType.NVarChar);
            thuchien.Parameters["@TenHocKy"].Value = comboBoxHocKy.Text;
            ketnoi.Open() ;
            doc = thuchien.ExecuteReader();
            int i = 0;
            while (doc.Read())
            {
                dataGridView.Rows.Add();
                dataGridView.Rows[i].Cells[0].Value = doc[0];
                dataGridView.Rows[i].Cells[1].Value = doc[1];
                dataGridView.Rows[i].Cells[2].Value = doc[2];
                i++;
            }
            ketnoi.Close() ;
        }

        int id_hocky;
        private void comboBoxHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            lenhsql = @"SELECT HocKy.ID, HocKy.TenHocKy, NganhHoc.TenNganh, Khoa.TenKhoa
                        FROM   HocKy INNER JOIN
                                     NganhHoc ON HocKy.ID_NganhHoc = NganhHoc.ID INNER JOIN
                                     Khoa ON NganhHoc.ID_Khoa = Khoa.ID
                        WHERE (HocKy.TenHocKy = @TenHocKy) AND (NganhHoc.TenNganh = @TenNganh) AND (Khoa.TenKhoa = @TenKhoa)";
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
                id_hocky = int.Parse(doc[0].ToString());
                labelHocKy.Text = "ID Học Ky: " + id_hocky.ToString();
            }
            ketnoi.Close();
            hien();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            lenhsql = @"INSERT INTO HinhThuc (HinhThuc, ID_HocKy)
                        VALUES (@HinhThuc,@ID_HocKy)";
            thuchien = new SqlCommand(lenhsql, ketnoi) ;
            thuchien.Parameters.Add("@HinhTHuc", SqlDbType.NVarChar) ;
            thuchien.Parameters["@HinhTHuc"].Value = comboBoxHinhThuc.Text;
            thuchien.Parameters.Add("@ID_HocKy", SqlDbType.Int);
            thuchien.Parameters["@ID_HocKy"].Value = id_hocky;
            ketnoi.Open() ;
            thuchien.ExecuteNonQuery();
            ketnoi.Close() ;
            hien();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            lenhsql = @"UPDATE HinhThuc
                        SET       HinhThuc = @HinhThuc, ID_HocKy = @ID_HocKy
                        WHERE (ID = @Original_ID)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@HinhTHuc", SqlDbType.NVarChar);
            thuchien.Parameters["@HinhTHuc"].Value = comboBoxHinhThuc.Text;
            thuchien.Parameters.Add("@ID_HocKy", SqlDbType.Int);
            thuchien.Parameters["@ID_HocKy"].Value = id_hocky;
            thuchien.Parameters.Add("@Original_ID", SqlDbType.Int);
            thuchien.Parameters["@Original_ID"].Value = int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString());
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
                lenhsql = @"DELETE FROM HinhThuc
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
            comboBoxHinhThuc.SelectedItem = dataGridView.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
