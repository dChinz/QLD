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

        string lenh;
        string nguon = @"Data Source=DESKTOP-GK5VJ4R;Initial Catalog=CtyABC;Integrated Security=True;";
        SqlConnection ketnoi;
        SqlDataReader doc;
        SqlCommand thuchien;
        double dongia;

        private void FormCTHD_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(nguon);
            lenh = @"select * from dmhang";
            thuchien = new SqlCommand(lenh, ketnoi);
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            while (doc.Read())
            {
                comboBoxMaHH.Items.Add(doc[0]);
            }
            ketnoi.Close();
            lenh = @"select * from hdnhap_xuat";
            thuchien = new SqlCommand(lenh, ketnoi);
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
            lenh = @"select * from cthdnhap_xuat";
            thuchien = new SqlCommand(lenh, ketnoi);
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
                i++;
            }
            ketnoi.Close();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            try
            {
                lenh = @"INSERT INTO cthdnhap_xuat
                             (id, sohd, mahang, soluong, gia)
                        VALUES (@id,@sohd,@mahang,@soluong,@gia)";
                thuchien = new SqlCommand(lenh, ketnoi);
                thuchien.Parameters.Add("@id", SqlDbType.NChar).Value = textBoxId.Text;
                thuchien.Parameters.Add("@sohd", SqlDbType.Int).Value = comboBoxSoHD.Text;
                thuchien.Parameters.Add("@mahang", SqlDbType.NVarChar).Value = comboBoxMaHH.Text;
                thuchien.Parameters.Add("@soluong", SqlDbType.Int).Value = textBoxSoLuong.Text;
                thuchien.Parameters.Add("@gia", SqlDbType.Float).Value = (dongia * Convert.ToInt32(textBoxSoLuong.Text)).ToString();
                ketnoi.Open();
                thuchien.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                MessageBox.Show("ID \"" + textBoxId.Text + "\" đã tồn tại");
                textBoxId.Focus();
            }
            finally
            {
                ketnoi.Close();
                hien();
                MessageBox.Show("thêm thành công");
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            lenh = @"UPDATE cthdnhap_xuat
                    SET       sohd = @sohd, mahang = @mahang, soluong = @soluong, gia = @gia
                    WHERE (id = @id)";
            thuchien = new SqlCommand(lenh, ketnoi);
            thuchien.Parameters.Add("@id", SqlDbType.NChar).Value = textBoxId.Text;
            thuchien.Parameters.Add("@sohd", SqlDbType.Int).Value = comboBoxSoHD.Text;
            thuchien.Parameters.Add("@mahang", SqlDbType.NVarChar).Value = comboBoxMaHH.Text;
            thuchien.Parameters.Add("@soluong", SqlDbType.Int).Value = textBoxSoLuong.Text;
            thuchien.Parameters.Add("@gia", SqlDbType.Float).Value = (dongia * Convert.ToInt32(textBoxSoLuong.Text)).ToString();
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            MessageBox.Show("sửa thành công");
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            lenh = @"DELETE FROM cthdnhap_xuat
                    WHERE (id = @id)";
            thuchien = new SqlCommand(lenh, ketnoi);
            thuchien.Parameters.Add("@id", SqlDbType.Int).Value = textBoxId.Text;
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hien();
            MessageBox.Show("xóa thành công");
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
            comboBoxSoHD.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            comboBoxMaHH.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
            textBoxSoLuong.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();
        }

        private void comboBoxMaHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            lenh = @"SELECT dongia
                    FROM   dmhang
                    WHERE (mahang = @mahang)";
            thuchien = new SqlCommand(lenh, ketnoi);
            thuchien.Parameters.Add("@mahang", SqlDbType.NChar).Value = comboBoxMaHH.Text;
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            while(doc.Read())
            {
                dongia = Convert.ToDouble(doc[0]);
            }
            ketnoi.Close();
        }
    }
}
