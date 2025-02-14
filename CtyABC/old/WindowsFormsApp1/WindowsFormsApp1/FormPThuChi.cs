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
    public partial class FormPThuChi : Form
    {
        public FormPThuChi()
        {
            InitializeComponent();
        }

        string sql;
        string nguon = @"Data Source=DESKTOP-GK5VJ4R;Initial Catalog=CtyABC;Integrated Security=True";
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader doc;

        private void FormPThuChi_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(nguon);
            sql = @"SELECT MaKH, TenKH, DiaChi, SoDT
                    FROM   KhachHang";
            thuchien = new SqlCommand(sql, ketnoi);
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            while (doc.Read())
            {
                comboBoxMaKH.Items.Add(doc[0]);
            }
            ketnoi.Close();
            hien();
        }

        void hien()
        {
            sql = @"SELECT SoPhieu, KieuPhieu, Ngay, MaKH, SoTien
                    FROM   PhieuThuChi";
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
            }
            ketnoi.Close();

        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            sql = @"INSERT INTO PhieuThuChi
                                 (SoPhieu, KieuPhieu, Ngay, MaKH, SoTien)
                    VALUES (@SoPhieu,@KieuPhieu,@Ngay,@MaKH,@SoTien)";
            thuchien = new SqlCommand (sql, ketnoi);
            thuchien.Parameters.Add("@SoPhieu", SqlDbType.Int).Value = textBoxSoPhieu.Text;
            thuchien.Parameters.Add("@KieuPhieu", SqlDbType.NVarChar).Value = comboBoxKieuPhieu.Text;
            thuchien.Parameters.Add("@Ngay", SqlDbType.Date).Value = textBoxNgay.Text;
            thuchien.Parameters.Add("@MaKH", SqlDbType.NChar).Value = comboBoxMaKH.Text;
            thuchien.Parameters.Add("@SoTien", SqlDbType.Float).Value = textBoxSoTien.Text;
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hien();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            sql = @"UPDATE PhieuThuChi
                    SET       KieuPhieu = @KieuPhieu, Ngay = @Ngay, MaKH = @MaKH, SoTien = @SoTien
                    WHERE (SoPhieu = @Original_SoPhieu)";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.Parameters.Add("@Original_SoPhieu", SqlDbType.Int).Value = textBoxSoPhieu.Text;
            thuchien.Parameters.Add("@KieuPhieu", SqlDbType.NVarChar).Value = comboBoxKieuPhieu.Text;
            thuchien.Parameters.Add("@Ngay", SqlDbType.Date).Value = textBoxNgay.Text;
            thuchien.Parameters.Add("@MaKH", SqlDbType.NChar).Value = comboBoxMaKH.Text;
            thuchien.Parameters.Add("@SoTien", SqlDbType.Float).Value = textBoxSoTien.Text;
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hien();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            sql = @"DELETE FROM PhieuThuChi
                    WHERE (SoPhieu = @Original_SoPhieu)";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.Parameters.Add("@Original_SoPhieu", SqlDbType.Int).Value = textBoxSoPhieu.Text;
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hien() ;
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxSoPhieu.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
            comboBoxKieuPhieu.SelectedItem = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxNgay.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBoxMaKH.SelectedItem = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxSoTien.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
