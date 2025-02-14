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
    public partial class FormPTC : Form
    {
        public FormPTC()
        {
            InitializeComponent();
        }

        string lenh;
        string nguon = @"Data Source=DESKTOP-GK5VJ4R;Initial Catalog=CtyABC;Integrated Security=True;";
        SqlConnection ketnoi;
        SqlDataReader doc;
        SqlCommand thuchien;

        private void FormPTC_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(nguon);
            lenh = @"select * from dmkhach";
            thuchien = new SqlCommand(lenh, ketnoi);
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
            dataGridView1.Rows.Clear();
            lenh = @"select * from phthu_chi";
            thuchien = new SqlCommand(lenh, ketnoi);
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            int i = 0;
            while (doc.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = doc[0].ToString();
                dataGridView1.Rows[i].Cells[1].Value = Convert.ToDateTime(doc[1].ToString()).ToString("dd/MM/yyyy");
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
                lenh = @"INSERT INTO phthu_chi
                        (sophieu, ngay, makh, sotien, loaiph)
                    VALUES (@sophieu,@ngay,@makh,@sotien,@loaiph)";
                thuchien = new SqlCommand(lenh, ketnoi);
                thuchien.Parameters.Add("@sophieu", SqlDbType.NChar).Value = textBoxSoPh.Text;
                thuchien.Parameters.Add("@ngay", SqlDbType.NVarChar).Value = textBoxNgayLap.Text;
                thuchien.Parameters.Add("@makh", SqlDbType.NVarChar).Value = comboBoxMaKH.Text;
                thuchien.Parameters.Add("@sotien", SqlDbType.NChar).Value = textBoxSoTien.Text;
                thuchien.Parameters.Add("@loaiph", SqlDbType.NChar).Value = comboBoxLoaiPh.Text;
                ketnoi.Open();
                thuchien.ExecuteNonQuery();
                MessageBox.Show("thêm thành công");
            }
            catch (SqlException)
            {
                MessageBox.Show("Số phiếu " + textBoxSoPh.Text + " đã tồn tại");
                textBoxSoPh.Focus();
            }
            finally
            {
                ketnoi.Close();
                hien();
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            lenh = @"UPDATE phthu_chi
                    SET       ngay = @ngay, makh = @makh, sotien = @sotien, loaiph = @loaiph
                    WHERE (sophieu = @sophieu)";
            thuchien = new SqlCommand(lenh, ketnoi);
            thuchien.Parameters.Add("@sophieu", SqlDbType.NChar).Value = textBoxSoPh.Text;
            thuchien.Parameters.Add("@ngay", SqlDbType.NVarChar).Value = textBoxNgayLap.Text;
            thuchien.Parameters.Add("@makh", SqlDbType.NVarChar).Value = comboBoxMaKH.Text;
            thuchien.Parameters.Add("@sotien", SqlDbType.NChar).Value = textBoxSoTien.Text;
            thuchien.Parameters.Add("@loaiph", SqlDbType.NChar).Value = comboBoxLoaiPh.Text;
            ketnoi.Open();
            thuchien.ExecuteNonQuery();
            ketnoi.Close() ;
            MessageBox.Show("sửa thành công");
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            lenh = @"DELETE FROM phthu_chi
                    WHERE (sophieu = @sophieu)";
            thuchien = new SqlCommand(lenh, ketnoi);
            thuchien.Parameters.Add("@sophieu", SqlDbType.NChar).Value = textBoxSoPh.Text;
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
            textBoxSoPh.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
            textBoxNgayLap.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            comboBoxMaKH.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
            textBoxSoTien.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();
            comboBoxLoaiPh.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim();
        }
    }
}
