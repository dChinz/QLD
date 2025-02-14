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
    public partial class FormSinhVien : Form
    {
        public FormSinhVien()
        {
            InitializeComponent();
        }

        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader doc;
        string nguon = @"Data Source=DESKTOP-GK5VJ4R;Initial Catalog=LTMT4K14_HoangDucChinh_QLD;Integrated Security=True";
        string lenhsql;

        private void FormSinhVien_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(nguon);
            comboBoxNganh.Items.Clear();
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

        private void comboBoxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void comboBoxNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxLop.Items.Clear();
            lenhsql = @"SELECT LopHoc.TenLop
                        FROM   LopHoc INNER JOIN
                                     NganhHoc ON LopHoc.ID_Nganh = NganhHoc.ID INNER JOIN
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
                comboBoxLop.Items.Add(doc[0]);
            }
            ketnoi.Close();
            hien();
        }

        void hien()
        {
            dataGridView.Rows.Clear();
            lenhsql = @"SELECT SinhVien.ID, SinhVien.MaSinhVien, SinhVien.TenSinhVien, SinhVien.NgaySinh, SinhVien.ID_Lop
                        FROM   SinhVien INNER JOIN
                                     LopHoc ON SinhVien.ID_Lop = LopHoc.ID INNER JOIN
                                     NganhHoc ON LopHoc.ID_Nganh = NganhHoc.ID INNER JOIN
                                     Khoa ON NganhHoc.ID_Khoa = Khoa.ID
                        WHERE (LopHoc.TenLop = @TenLop) AND (NganhHoc.TenNganh = @TenNganh) AND (Khoa.TenKhoa = @TenKhoa)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@TenNganh", SqlDbType.NVarChar);
            thuchien.Parameters["@TenNganh"].Value = comboBoxNganh.Text;
            thuchien.Parameters.Add("@TenKhoa", SqlDbType.NVarChar);
            thuchien.Parameters["@TenKhoa"].Value = comboBoxKhoa.Text;
            thuchien.Parameters.Add("@TenLop", SqlDbType.NVarChar);
            thuchien.Parameters["@TenLop"].Value = comboBoxLop.Text;
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
                dataGridView.Rows[i].Cells[4].Value = doc[4];
                i++;
            }
            ketnoi.Close();
        }

        int id_lop;
        private void comboBoxLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            lenhsql = @"SELECT LopHoc.ID
                        FROM   LopHoc INNER JOIN
                                     NganhHoc ON LopHoc.ID_Nganh = NganhHoc.ID INNER JOIN
                                     Khoa ON NganhHoc.ID_Khoa = Khoa.ID
                        WHERE (LopHoc.TenLop = @TenLop) AND (NganhHoc.TenNganh = @TenNganh) AND (Khoa.TenKhoa = @TenKhoa)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@TenNganh", SqlDbType.NVarChar);
            thuchien.Parameters["@TenNganh"].Value = comboBoxNganh.Text;
            thuchien.Parameters.Add("@TenKhoa", SqlDbType.NVarChar);
            thuchien.Parameters["@TenKhoa"].Value = comboBoxKhoa.Text;
            thuchien.Parameters.Add("@TenLop", SqlDbType.NVarChar);
            thuchien.Parameters["@TenLop"].Value = comboBoxLop.Text;
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            while (doc.Read())
            {
                id_lop = int.Parse(doc[0].ToString());
                label8.Text = id_lop.ToString();
            }
            ketnoi.Close();
            hien();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            lenhsql = @"INSERT INTO SinhVien
                                     (MaSinhVien, TenSinhVien, NgaySinh, ID_Lop)
                        VALUES (@MaSinhVien,@TenSinhVien,@NgaySinh,@ID_Lop)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@MaSinhVien", SqlDbType.NVarChar);
            thuchien.Parameters["@MaSinhVien"].Value = textBoxMaSinhVien.Text;
            thuchien.Parameters.Add("@TenSinhVien", SqlDbType.NVarChar);
            thuchien.Parameters["@TenSinhVien"].Value = textBoxTenSinhVien.Text;
            thuchien.Parameters.Add("@NgaySinh", SqlDbType.Date);
            thuchien.Parameters["@NgaySinh"].Value = textBoxNgaySinh.Text;
            thuchien.Parameters.Add("@ID_Lop", SqlDbType.Int);
            thuchien.Parameters["@ID_Lop"].Value = id_lop;
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hien();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            lenhsql = @"UPDATE SinhVien
                        SET       MaSinhVien = @MaSinhVien, TenSinhVien = @TenSinhVien, NgaySinh = @NgaySinh
                        WHERE (ID = @Original_ID)";
            thuchien = new SqlCommand(lenhsql, ketnoi);
            thuchien.Parameters.Add("@MaSinhVien", SqlDbType.NVarChar);
            thuchien.Parameters["@MaSinhVien"].Value = textBoxMaSinhVien.Text;
            thuchien.Parameters.Add("@TenSinhVien", SqlDbType.NVarChar);
            thuchien.Parameters["@TenSinhVien"].Value = textBoxTenSinhVien.Text;
            thuchien.Parameters.Add("@NgaySinh", SqlDbType.Date);
            thuchien.Parameters["@NgaySinh"].Value = textBoxNgaySinh.Text;
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
                lenhsql = @"DELETE FROM SinhVien
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
            textBoxMaSinhVien.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            textBoxTenSinhVien.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            textBoxNgaySinh.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
