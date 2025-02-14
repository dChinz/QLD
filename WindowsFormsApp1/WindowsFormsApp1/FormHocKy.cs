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
    public partial class FormHocKy : Form
    {
        public FormHocKy()
        {
            InitializeComponent();
        }

        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader doc;
        string nguon = @"Data Source=DESKTOP-GK5VJ4R;Initial Catalog=LTMT4K14_HoangDucChinh_QLD;Integrated Security=True";
        string lenhsql;

        private void FormHocKy_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(nguon);
            dataGridView.Rows.Clear();
            comboBoxNganhHoc.Items.Clear();
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
            hien();
        }

        void hien()
        {
            lenhsql = @"SELECT HocKy.ID, HocKy.TenHocKy, HocKy.ID_NganhHoc
                        FROM   HocKy INNER JOIN
                                     NganhHoc ON HocKy.ID_NganhHoc = NganhHoc.ID INNER JOIN
                                     Khoa ON NganhHoc.ID_Khoa = Khoa.ID
                        WHERE (NganhHoc.TenNganh = @TenNganh) AND (Khoa.TenKhoa = @TenKhoa)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@TenNganh", SqlDbType.NVarChar);
            thuchien.Parameters["@TenNganh"].Value = comboBoxNganhHoc.Text;
            thuchien.Parameters.Add("@TenKhoa", SqlDbType.NVarChar);
            thuchien.Parameters["@TenKhoa"].Value = comboBoxKhoa.Text;
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            int i = 0;
            while(doc.Read())
            {
                dataGridView.Rows.Add();
                dataGridView.Rows[i].Cells[0].Value = doc[0];
                dataGridView.Rows[i].Cells[1].Value = doc[1];
                dataGridView.Rows[i].Cells[2].Value = doc[2];
                i++;
            }
            ketnoi.Close();
            for (int k = 0; k < 8; k++)
            {
                for (int j = i; j < dataGridView.Rows.Count; j++)
                {
                    dataGridView.Rows.RemoveAt(j);
                }
            }
        }

        int id_nganh = 1;
        private void comboBoxNganhHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            lenhsql = @"SELECT NganhHoc.ID
                        FROM   NganhHoc INNER JOIN
                            Khoa ON NganhHoc.ID_Khoa = Khoa.ID
                        WHERE (NganhHoc.TenNganh = @TenNganh) AND (Khoa.TenKhoa = @TenKhoa)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@TenNganh", SqlDbType.NVarChar);
            thuchien.Parameters["@TenNganh"].Value = comboBoxNganhHoc.Text;
            thuchien.Parameters.Add("@TenKhoa", SqlDbType.NVarChar);
            thuchien.Parameters["@TenKhoa"].Value = comboBoxKhoa.Text;
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            while (doc.Read())
            {
                id_nganh = int.Parse(doc[0].ToString());
            }
            ketnoi.Close() ;
            hien();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            lenhsql = @"INSERT INTO HocKy (TenHocKy, ID_NganhHoc)
                        VALUES (@TenHocKy,@ID_NganhHoc)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@TenHocKy", SqlDbType.NVarChar);
            thuchien.Parameters["@TenHocKy"].Value = textBoxHocKy.Text;
            thuchien.Parameters.Add("@ID_NganhHoc", SqlDbType.Int);
            thuchien.Parameters["@ID_NganhHoc"].Value = id_nganh;
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hien();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            lenhsql = @"UPDATE HocKy
                        SET TenHocKy = @TenHocKy
                        WHERE (ID = @Original_ID)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@TenHocKy", SqlDbType.NVarChar);
            thuchien.Parameters["@TenHocKy"].Value = textBoxHocKy.Text;
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
                lenhsql = @"DELETE FROM HocKy
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

        private void comboBoxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(nguon);
            dataGridView.Rows.Clear();
            comboBoxNganhHoc.Items.Clear();
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
                comboBoxNganhHoc.Items.Add(doc[0]);
            }
            ketnoi.Close();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView.Rows[e.RowIndex].Selected = true;
            textBoxHocKy.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
