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
    public partial class FormHD : Form
    {
        public FormHD()
        {
            InitializeComponent();
        }

        string sql;
        string nguon = @"Data Source=DESKTOP-GK5VJ4R;Initial Catalog=CtyABC;Integrated Security=True";
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader doc;

        private void FormHD_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(nguon);
            sql = @"SELECT MaKH, TenKH, DiaChi, SoDT
                    FROM   KhachHang";
            thuchien = new SqlCommand(sql, ketnoi);
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            while (doc.Read())
            {
                comboBoxMaKhach.Items.Add(doc[0]);
            }
            ketnoi.Close();
            hien();
        }
        void hien()
        {
            dataGridView1.Rows.Clear();
            sql = @"SELECT SoHD, KieuHD, Ngay, MaKH, SoTienTT
                    FROM   HoaDonNhapXuat";
            thuchien = new SqlCommand(sql, ketnoi);
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            int i = 0;
            while (doc.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = doc[0].ToString();
                dataGridView1.Rows[i].Cells[1].Value = doc[1].ToString();
                dataGridView1.Rows[i].Cells[2].Value = DateTime.Parse(doc[2].ToString()).ToString("dd/MM/yyyy");
                dataGridView1.Rows[i].Cells[3].Value = doc[3].ToString();
                dataGridView1.Rows[i].Cells[4].Value = doc[4].ToString();
                i++;
            }
            ketnoi.Close() ;
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            sql = @"INSERT INTO HoaDonNhapXuat
                                 (SoHD, KieuHD, Ngay, MaKH, SoTienTT)
                    VALUES (@SoHD,@KieuHD,@Ngay,@MaKH,@SoTienTT)";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.Parameters.Add("@SoHD", SqlDbType.Int).Value = textBoxSoHD.Text;
            thuchien.Parameters.Add("@KieuHD", SqlDbType.NVarChar).Value = comboBoxKieuHD.Text;
            thuchien.Parameters.Add("@Ngay", SqlDbType.Date).Value = textBoxNgay.Text;
            thuchien.Parameters.Add("@MaKH", SqlDbType.NChar).Value = comboBoxMaKhach.Text;
            thuchien.Parameters.Add("SoTienTT", SqlDbType.Float).Value = textBoxTongTien.Text;
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hien() ;
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            sql = @"UPDATE HoaDonNhapXuat
                    SET       KieuHD = @KieuHD, Ngay = @Ngay, MaKH = @MaKH, SoTienTT = @SoTienTT
                    WHERE (SoHD = @Original_SoHD)";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.Parameters.Add("@SoHD", SqlDbType.Int).Value = textBoxSoHD.Text;
            thuchien.Parameters.Add("@KieuHD", SqlDbType.NVarChar).Value = comboBoxKieuHD.Text;
            thuchien.Parameters.Add("@Ngay", SqlDbType.Date).Value = textBoxNgay.Text;
            thuchien.Parameters.Add("@MaKH", SqlDbType.NChar).Value = comboBoxMaKhach.Text;
            thuchien.Parameters.Add("SoTienTT", SqlDbType.Float).Value = textBoxTongTien.Text;
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hien();
        }

        private void buttonXóa_Click(object sender, EventArgs e)
        {
            sql = @"DELETE FROM HoaDonNhapXuat
                WHERE (SoHD = @Original_SoHD)";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.Parameters.Add("@SoHD", SqlDbType.Int).Value = textBoxSoHD.Text;
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
            textBoxSoHD.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
            comboBoxKieuHD.SelectedItem = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxNgay.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBoxMaKhach.SelectedItem = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxTongTien.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
