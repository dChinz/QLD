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
    public partial class FormCTHD : Form
    {
        public FormCTHD()
        {
            InitializeComponent();
        }

        string sql;
        string nguon = @"Data Source=DESKTOP-GK5VJ4R;Initial Catalog=CtyABC;Integrated Security=True";
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader doc;

        private void FormCTHD_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(nguon);
            sql = @"SELECT MaHang
                    FROM   Hang";
            thuchien = new SqlCommand(sql, ketnoi);
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            while (doc.Read())
            {
                comboBoxMaHang.Items.Add(doc[0]);
            }
            ketnoi.Close();
            //---------------------------------------
            sql = @"SELECT SoHD
                    FROM   HoaDonNhapXuat";
            thuchien = new SqlCommand(sql, ketnoi);
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            while (doc.Read())
            {
                comboBoxSoHD.Items.Add(doc[0]);
            }
            ketnoi.Close();
            hien();
        }

        void hien()
        {
            dataGridView1.Rows.Clear();
            sql = @"SELECT ID, SoHD, MaHang, SoLuong, Gia
FROM   CTHoaDonNhapXuat";
            thuchien = new SqlCommand (sql, ketnoi);
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            int i = 0;
            while (doc.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = doc[0].ToString();
                dataGridView1.Rows[i].Cells[1].Value = doc[1].ToString();
                dataGridView1.Rows[i].Cells[2].Value = doc[2].ToString();
                dataGridView1.Rows[i].Cells[3].Value = doc[3].ToString();
                dataGridView1.Rows[i].Cells[4].Value = doc[4].ToString();
            }
            ketnoi.Close();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            sql = @"INSERT INTO CTHoaDonNhapXuat
                                 (ID, SoHD, MaHang, SoLuong, Gia)
                    VALUES (@ID,@SoHD,@MaHang,@SoLuong,@Gia)";
            thuchien = new SqlCommand (sql, ketnoi);
            thuchien.Parameters.Add("@ID", SqlDbType.NChar).Value = textBoxID.Text;
            thuchien.Parameters.Add("@SoHD", SqlDbType.Int).Value = comboBoxSoHD.Text;
            thuchien.Parameters.Add("@MaHang", SqlDbType.NChar).Value = comboBoxMaHang.Text;
            thuchien.Parameters.Add("@SoLuong", SqlDbType.Int).Value = textBoxSoLuong.Text;
            thuchien.Parameters.Add("Gia", SqlDbType.Float).Value = textBoxGia.Text;
            ketnoi.Open ();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hien();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            sql = @"UPDATE CTHoaDonNhapXuat
                    SET       SoHD = @SoHD, MaHang = @MaHang, SoLuong = @SoLuong, Gia = @Gia
                    WHERE (ID = @Original_ID)";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.Parameters.Add("@Original_ID", SqlDbType.NChar).Value = textBoxID.Text;
            thuchien.Parameters.Add("@SoHD", SqlDbType.Int).Value = comboBoxSoHD.Text;
            thuchien.Parameters.Add("@MaHang", SqlDbType.NChar).Value = comboBoxMaHang.Text;
            thuchien.Parameters.Add("@SoLuong", SqlDbType.Int).Value = textBoxSoLuong.Text;
            thuchien.Parameters.Add("Gia", SqlDbType.Float).Value = textBoxGia.Text;
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hien();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            sql = @"DELETE FROM CTHoaDonNhapXuat
                    WHERE (ID = @Original_ID)";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.Parameters.Add("@Original_ID", SqlDbType.NChar).Value = textBoxID.Text;
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hien();
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
            comboBoxSoHD.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            comboBoxMaHang.SelectedItem = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxSoLuong.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxGia.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
