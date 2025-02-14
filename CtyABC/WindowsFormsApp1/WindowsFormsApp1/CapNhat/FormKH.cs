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

        string lenh;
        string nguon = @"Data Source=DESKTOP-GK5VJ4R;Initial Catalog=CtyABC;Integrated Security=True;";
        SqlConnection ketnoi;
        SqlDataReader doc;
        SqlCommand thuchien;

        private void FormKH_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(nguon);
            hien();
        }

        void hien()
        {
            dataGridView1.Rows.Clear();
            lenh = @"select * from dmkhach";
            thuchien = new SqlCommand(lenh, ketnoi);
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            int i = 0;
            while(doc.Read())
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
                lenh = @"INSERT INTO dmkhach
                        (makh, tenkh, diachi, sodt, masothue)
                VALUES (@makh,@tenkh,@diachi,@sodt,@masothue)";
                thuchien = new SqlCommand(lenh, ketnoi);
                thuchien.Parameters.Add("@makh", SqlDbType.NChar).Value = textBoxMaKH.Text;
                thuchien.Parameters.Add("@tenkh", SqlDbType.NVarChar).Value = textBoxTenKH.Text;
                thuchien.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = textBoxDiaChi.Text;
                thuchien.Parameters.Add("@sodt", SqlDbType.NChar).Value = textBoxSDT.Text;
                thuchien.Parameters.Add("@masothue", SqlDbType.NChar).Value = textBoxMST.Text;
                ketnoi.Open();
                thuchien.ExecuteNonQuery();
                MessageBox.Show("thêm thành công");
            }
            catch (SqlException)
            {
                MessageBox.Show("Mã khách hàng " + textBoxMaKH.Text + "đã tồn tại");
                textBoxMaKH.Focus();
            }
            finally
            {
                ketnoi.Close();
                hien();
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            lenh = @"UPDATE dmkhach
                    SET       tenkh = @tenkh, diachi = @diachi, sodt = @sodt, masothue = @masothue
                    WHERE (makh = @makh)";
            thuchien = new SqlCommand (lenh, ketnoi);
            thuchien.Parameters.Add("@makh", SqlDbType.NChar).Value = textBoxMaKH.Text;
            thuchien.Parameters.Add("@tenkh", SqlDbType.NVarChar).Value = textBoxTenKH.Text;
            thuchien.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = textBoxDiaChi.Text;
            thuchien.Parameters.Add("@sodt", SqlDbType.NChar).Value = textBoxSDT.Text;
            thuchien.Parameters.Add("@masothue", SqlDbType.NChar).Value = textBoxMST.Text;
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hien();
            MessageBox.Show("sửa thành công");
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            lenh = @"DELETE FROM dmkhach
                    WHERE (makh = @Original_makh)";
            thuchien = new SqlCommand(lenh, ketnoi);
            thuchien.Parameters.Add("@Original_makh", SqlDbType.NChar).Value = textBoxMaKH.Text;
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
            textBoxMaKH.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
            textBoxTenKH.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            textBoxDiaChi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
            textBoxSDT.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();
            textBoxMST.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim();
        }
    }
}
