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
using System.Reflection.Emit;

namespace WindowsFormsApp1
{
    public partial class FormKhoa : Form
    {
        public FormKhoa()
        {
            InitializeComponent();
        }
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader doc;
        string nguon = @"Data Source=DESKTOP-GK5VJ4R;Initial Catalog=LTMT4K14_HoangDucChinh_QLD;Integrated Security=True";
        string lenhsql;

        private void FormKhoa_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(nguon);
            nap();
            dataGridView.ClearSelection();
        }

        void nap()
        {
            dataGridView.Rows.Clear();
            lenhsql = @"SELECT ID, TenKhoa
                        FROM   Khoa";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            int dem = 0;
            while (doc.Read())
            {
                dataGridView.Rows.Add();
                dataGridView.Rows[dem].Cells[0].Value = doc[0].ToString();
                dataGridView.Rows[dem].Cells[1].Value = doc[1].ToString();
                dem++;
            }
            ketnoi.Close();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            lenhsql = @"INSERT INTO Khoa (TenKhoa)
                        VALUES (@TenKhoa)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@TenKhoa", SqlDbType.NVarChar);
            thuchien.Parameters["@TenKhoa"].Value = textBoxTenKhoa.Text;
            ketnoi.Open();  
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            nap();
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            DialogResult D = MessageBox.Show("Thoát", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (D == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            DialogResult D = MessageBox.Show("Xóa " + dataGridView.CurrentRow.Cells[1].Value.ToString() + "?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (D == DialogResult.Yes)
            {
                lenhsql = @"DELETE FROM Khoa
                            WHERE (ID = @Original_ID)";
                thuchien = new SqlCommand(lenhsql, ketnoi);
                thuchien.Parameters.Add("@Original_ID", SqlDbType.NVarChar);
                thuchien.Parameters["@Original_ID"].Value = dataGridView.CurrentRow.Cells[0].Value.ToString();
                ketnoi.Open();
                thuchien.ExecuteNonQuery();
                ketnoi.Close();
                nap();
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            lenhsql = @"UPDATE Khoa
                        SET TenKhoa = @TenKhoa
                        WHERE (ID = @Original_ID)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@Original_ID", SqlDbType.Int);
            thuchien.Parameters.Add("@TenKhoa", SqlDbType.NVarChar);
            thuchien.Parameters["@Original_ID"].Value = int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString());
            thuchien.Parameters["@TenKhoa"].Value = textBoxTenKhoa.Text;
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            nap();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView.Rows[e.RowIndex].Selected = true;
            textBoxTenKhoa.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
