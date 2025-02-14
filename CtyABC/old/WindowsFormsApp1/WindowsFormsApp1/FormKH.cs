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
    public partial class FormKH : Form
    {
        public FormKH()
        {
            InitializeComponent();
        }

        string sql;
        string nguon = @"Data Source=DESKTOP-GK5VJ4R;Initial Catalog=CtyABC;Integrated Security=True";
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader doc;

        private void FormKH_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(nguon);
            hien();
        }

        void hien()
        {
            dataGridView.Rows.Clear();
            sql = @"SELECT MaKH, TenKH, DiaChi, SoDT
                    FROM   KhachHang";
            thuchien = new SqlCommand(sql, ketnoi);
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            int i = 0;
            while (doc.Read())
            {
                dataGridView.Rows.Add();
                dataGridView.Rows[i].Cells[0].Value = doc[0];
                dataGridView.Rows[i].Cells[1].Value = doc[1];
                dataGridView.Rows[i].Cells[2].Value = doc[2];
                dataGridView.Rows[i].Cells[3].Value = doc[3];
                i++;
            }
            ketnoi.Close();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            sql = @"INSERT INTO KhachHang
                     (MaKH, TenKH, DiaChi, SoDT)
                    VALUES (@MaKH,@TenKH,@DiaChi,@SoDT)";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.Parameters.Add("@MaKH", SqlDbType.NChar).Value = textBoxMaKhach.Text;
            thuchien.Parameters.Add("@TenKH", SqlDbType.NVarChar).Value = textBoxTenKhach.Text;
            thuchien.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = textBoxDiaChi.Text;
            thuchien.Parameters.Add("@SoDT", SqlDbType.NChar).Value = textBoxSDT.Text;
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hien();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            sql = @"UPDATE KhachHang
                    SET TenKH = @TenKH, DiaChi = @DiaChi, SoDT = @SoDT
                    WHERE (MaKH = @MaKH)";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.Parameters.Add("@MaKH", SqlDbType.NChar).Value = textBoxMaKhach.Text;
            thuchien.Parameters.Add("@TenKH", SqlDbType.NVarChar).Value = textBoxTenKhach.Text;
            thuchien.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = textBoxDiaChi.Text;
            thuchien.Parameters.Add("@SoDT", SqlDbType.NChar).Value = textBoxSDT.Text;
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hien();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            sql = @"DELETE FROM KhachHang
                    WHERE (MaKH = @Original_MaKH)";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.Parameters.Add("@Original_MaKH", SqlDbType.NChar).Value = textBoxMaKhach.Text;
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hien();
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxMaKhach.Text = dataGridView.CurrentRow.Cells[0].Value.ToString().Trim();
            textBoxTenKhach.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            textBoxDiaChi.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            textBoxSDT.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
