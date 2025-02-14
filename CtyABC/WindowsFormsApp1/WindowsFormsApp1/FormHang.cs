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
    public partial class FormHang : Form
    {
        public FormHang()
        {
            InitializeComponent();
        }

        string sql;
        string nguon = @"Data Source=DESKTOP-GK5VJ4R;Initial Catalog=CtyABC;Integrated Security=True";
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader doc;

        private void FormHang_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(nguon);
            hien();
        }

        void hien()
        {
            dataGridView.Rows.Clear();
            sql = @"SELECT MaHang, TenHang, DonViTinh, DonGia
                    FROM   Hang";
            thuchien = new SqlCommand(sql, ketnoi);
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            int i = 0;
            while(doc.Read())
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
            sql = @"INSERT INTO Hang
                             (MaHang, TenHang, DonViTinh, DonGia)
                VALUES (@MaHang,@TenHang,@DonViTinh,@DonGia)";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.Parameters.Add("@MaHang", SqlDbType.NChar).Value = textBoxMaHang.Text;
            thuchien.Parameters.Add("@TenHang", SqlDbType.NVarChar).Value = textBoxTenHang.Text;
            thuchien.Parameters.Add("@DonViTinh", SqlDbType.NVarChar).Value = textBoxDVT.Text;
            thuchien.Parameters.Add("@DonGia", SqlDbType.NChar).Value = textBoxDonGia.Text;
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hien();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            sql = @"UPDATE Hang
                    SET       TenHang = @TenHang, DonViTinh = @DonViTinh, DonGia = @DonGia
                    WHERE (MaHang = @MaHang)";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.Parameters.Add("@MaHang", SqlDbType.NChar).Value = textBoxMaHang.Text;
            thuchien.Parameters.Add("@TenHang", SqlDbType.NVarChar).Value = textBoxTenHang.Text;
            thuchien.Parameters.Add("@DonViTinh", SqlDbType.NVarChar).Value = textBoxDVT.Text;
            thuchien.Parameters.Add("@DonGia", SqlDbType.NChar).Value = textBoxDonGia.Text;
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hien();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            sql = @"DELETE FROM Hang
                    WHERE (MaHang = @Original_Mahang)";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.Parameters.Add("@Original_Mahang", SqlDbType.NChar).Value = textBoxMaHang.Text;
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hien();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxMaHang.Text = dataGridView.CurrentRow.Cells[0].Value.ToString().Trim();
            textBoxTenHang.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            textBoxDVT.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            textBoxDonGia.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
