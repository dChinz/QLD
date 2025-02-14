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
    public partial class FormNganh : Form
    {
        public FormNganh()
        {
            InitializeComponent();
        }
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader doc;
        string nguon = @"Data Source=DESKTOP-GK5VJ4R;Initial Catalog=LTMT4K14_HoangDucChinh_QLD;Integrated Security=True";
        string lenhsql;

        private void FormNganh_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(nguon);
            dataGridView.Rows.Clear();
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
            hien();
        }

        void hien()
        {
            lenhsql = @"SELECT NganhHoc.ID, NganhHoc.TenNganh, NganhHoc.ID_Khoa
                        FROM KHOA INNER JOIN NganhHoc 
                            ON Khoa.ID = NganhHoc.ID_Khoa
                        WHERE (Khoa.TenKhoa = @TenKhoa)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@TenKhoa", SqlDbType.NVarChar);
            thuchien.Parameters["@TenKhoa"].Value = comboBoxKhoa.Text;
            ketnoi.Open();
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
            ketnoi.Close();
            for (int k = 0; k < 8; k++)
            {
                for (int j = i; j < dataGridView.Rows.Count; j++)
                {
                    dataGridView.Rows.RemoveAt(j);
                }
            }
        }

        int id_khoa = 1;
        private void comboBoxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            lenhsql = @"SELECT ID
                        FROM   Khoa
                        WHERE (TenKhoa = @TenKhoa)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@TenKhoa", SqlDbType.NVarChar);
            thuchien.Parameters["@TenKhoa"].Value = comboBoxKhoa.Text;
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            while (doc.Read())
            {
                id_khoa = int.Parse(doc[0].ToString()); 
            }
            ketnoi.Close();
            //--------------------------------------------------------
            lenhsql = @"SELECT NganhHoc.ID, NganhHoc.TenNganh, NganhHoc.ID_Khoa
                        FROM KHOA INNER JOIN NganhHoc 
                            ON Khoa.ID = NganhHoc.ID_Khoa
                        WHERE (Khoa.TenKhoa = @TenKhoa)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@TenKhoa", SqlDbType.NVarChar);
            thuchien.Parameters["@TenKhoa"].Value = comboBoxKhoa.Text;
            ketnoi.Open();
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
            ketnoi.Close();
            for (int k = 0; k < 8; k++)
            {
                for (int j = i; j < dataGridView.Rows.Count; j++)
                {
                    dataGridView.Rows.RemoveAt(j);
                }
            }
        }
        
        private void buttonThem_Click(object sender, EventArgs e)
        {
            lenhsql = @"INSERT INTO NganhHoc (TenNganh, ID_Khoa)
                        VALUES (@TenNganh, @ID_Khoa)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@TenNganh", SqlDbType.NVarChar);
            thuchien.Parameters.Add("@ID_Khoa", SqlDbType.Int);
            thuchien.Parameters["@TenNganh"].Value = textBoxTenNganh.Text;
            thuchien.Parameters["@ID_Khoa"].Value = id_khoa;
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hien();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView.Rows[e.RowIndex].Selected = true;
            textBoxTenNganh.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            lenhsql = @"UPDATE NganhHoc
                        SET TenNganh = @TenNganh
                        WHERE (ID = @Original_ID)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@TenNganh", SqlDbType.NVarChar);
            thuchien.Parameters.Add("@Original_ID", SqlDbType.Int);
            thuchien.Parameters["@TenNganh"].Value = textBoxTenNganh.Text;
            thuchien.Parameters["@Original_ID"].Value = int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString());
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hien();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            DialogResult D = MessageBox.Show("Xóa " + dataGridView.CurrentRow.Cells[1].Value.ToString() + "?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (D == DialogResult.Yes)
            {
                lenhsql = @"DELETE FROM NganhHoc
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
    }
}
