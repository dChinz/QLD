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
    public partial class FormHH : Form
    {
        public FormHH()
        {
            InitializeComponent();
        }

        string lenh;
        string nguon = @"Data Source=DESKTOP-GK5VJ4R;Initial Catalog=CtyABC;Integrated Security=True;";
        SqlConnection ketnoi;
        SqlDataReader doc;
        SqlCommand thuchien;

        private void FormHH_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(nguon);
            hien();
        }

        void hien()
        {
            dataGridView1.Rows.Clear();
            lenh = @"select * from dmhang";
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
                i++;
            }
            ketnoi.Close();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            try
            {
                lenh = @"INSERT INTO dmhang
                            (mahang, tenhang, dvtinh, dongia)
                        VALUES (@mahang,@tenhang,@dvtinh,@dongia)";
                thuchien = new SqlCommand(lenh, ketnoi);
                thuchien.Parameters.Add("@mahang", SqlDbType.NChar).Value = textBoxMaH.Text;
                thuchien.Parameters.Add("@tenhang", SqlDbType.NVarChar).Value = textBoxTenH.Text;
                thuchien.Parameters.Add("@dvtinh", SqlDbType.NVarChar).Value = textBoxDVT.Text;
                thuchien.Parameters.Add("@dongia", SqlDbType.NChar).Value = textBoxDG.Text;
                ketnoi.Open();
                thuchien.ExecuteNonQuery();
                MessageBox.Show("thêm thành công");
            }
            catch (SqlException)
            {
                MessageBox.Show("Mã khách hàng " + textBoxMaH.Text + "đã tồn tại");
                textBoxMaH.Focus();
            }
            finally
            {
                ketnoi.Close();
                hien();
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            lenh = @"UPDATE dmhang
                    SET       tenhang = @tenhang, dvtinh = @dvtinh, dongia = @dongia
                    WHERE (mahang = @mahang)";
            thuchien = new SqlCommand(lenh, ketnoi);
            thuchien.Parameters.Add("@mahang", SqlDbType.NChar).Value = textBoxMaH.Text;
            thuchien.Parameters.Add("@tenhang", SqlDbType.NVarChar).Value = textBoxTenH.Text;
            thuchien.Parameters.Add("@dvtinh", SqlDbType.NVarChar).Value = textBoxDVT.Text;
            thuchien.Parameters.Add("@dongia", SqlDbType.NChar).Value = textBoxDG.Text;
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hien();
            MessageBox.Show("sửa thành công");
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            lenh = @"DELETE FROM dmhang
                    WHERE (mahang = @mahang)";
            thuchien = new SqlCommand(lenh, ketnoi);
            thuchien.Parameters.Add("@mahang", SqlDbType.NChar).Value = textBoxMaH.Text;
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
            textBoxMaH.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
            textBoxTenH.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            textBoxDVT.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
            textBoxDG.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();
        }
    }
}
