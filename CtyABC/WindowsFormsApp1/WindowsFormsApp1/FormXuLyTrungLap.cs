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
    public partial class FormXuLyTrungLap : Form
    {
        private string _moduleName;

        public FormXuLyTrungLap( string moduleName)
        {
            InitializeComponent();

            _moduleName = moduleName;
        }

        string sql;
        string nguon = @"Data Source=DESKTOP-GK5VJ4R;Initial Catalog=CtyABC;Integrated Security=True";
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader doc;

        private void FormXuLyTrungLap_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(nguon);
            switch (_moduleName)
            {
                case("khachhang"):
                    //case nếu bấm váo btnKhachHang
                    sql = @"SELECT *
                    FROM KhachHang kh
                    WHERE EXISTS (
                        SELECT *
                        FROM KhachHang kh2
                        WHERE kh.TenKH = kh2.TenKH
                        AND kh.DiaChi = kh2.DiaChi
                        AND kh.SoDT = kh2.SoDT
                        GROUP BY kh2.TenKH, kh2.DiaChi, kh2.SoDT
                        HAVING COUNT(*) > 1);";
                    break;
                case ("hanghoa"):
                    sql = @"SELECT *
                    FROM Hang h
                    WHERE EXISTS (
                        SELECT *
                        FROM Hang h2
                        WHERE h.TenHang = h2.TenHang
                        AND h.DonViTinh = h2.DonViTinh
                        AND h.DonGia = h2.DonGia
                        GROUP BY h2.TenHang, h2.DonViTinh, h2.DonGia
                        HAVING COUNT(*) > 1);";
                    break;
                case ("hoadon"):
                    sql = @"SELECT *
                    FROM HoaDonNhapXuat h
                    WHERE EXISTS (
                        SELECT *
                        FROM HoaDonNhapXuat h2
                        WHERE h.KieuHD = h2.KieuHD
                        AND h.Ngay = h2.Ngay
                        AND h.MaKH = h2.MaKH
                        AND h.SoTienTT = h2.SoTienTT
                        GROUP BY h2.KieuHD, h2.Ngay, h2.MaKH, h2.SoTienTT
                        HAVING COUNT(*) > 1)";
                    break;
                    case ("pthuchi"):
                        sql = @"SELECT *
                        FROM PhieuThuChi h
                        WHERE EXISTS (
                            SELECT *
                            FROM PhieuThuChi h2
                            WHERE h.KieuPhieu = h2.KieuPhieu
                            AND h.Ngay = h2.Ngay
                            AND h.MaKH = h2.MaKH
                            AND h.SoTien = h2.SoTien
                            GROUP BY h2.KieuPhieu, h2.Ngay, h2.MaKH, h2.SoTien
                            HAVING COUNT(*) > 1)";
                        break;
                    case ("cthd"):
                        sql = @"SELECT *
                        FROM CTHoaDonNhapXuat h
                        WHERE EXISTS (
                            SELECT *
                            FROM CTHoaDonNhapXuat h2
                            WHERE h.SoHD = h2.SoHD
                            AND h.MaHang = h2.MaHang
                            AND h.SoLuong = h2.SoLuong
                            AND h.Gia = h2.Gia
                            GROUP BY h2.SoHD, h2.MaHang, h2.SoLuong, h2.Gia
                            HAVING COUNT(*) > 1)";
                        break;
            }
            thuchien = new SqlCommand(sql, ketnoi);
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            dataGridView1.Rows.Clear();
            for (int i = 0; i < doc.FieldCount; i++)
            {
                dataGridView1.Columns.Add(doc.GetName(i), doc.GetName(i));
            }
            while (doc.Read())
            {
                int row = dataGridView1.Rows.Add();
                for(int i = 0; i < doc.FieldCount; i++)
                {
                    dataGridView1.Rows[row].Cells[i].Value = doc[i];
                }
            }
            ketnoi.Close();

            DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();
            btnXoa.HeaderText = "Thao Tác";
            btnXoa.Name = "btnXoa";
            btnXoa.Text = "Xóa";
            btnXoa.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btnXoa);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataGridView1.Columns["btnXoa"].Index && e.RowIndex > 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa dòng này không?",
                                              "Xác nhận xóa",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string ID = row.Cells[0].Value.ToString();

                    dataGridView1.Rows.RemoveAt(e.RowIndex);

                    sql = @"delete from KhachHang where MaKH = @ID";
                    thuchien = new SqlCommand(sql, ketnoi);
                    thuchien.Parameters.AddWithValue("@ID", ID);
                    ketnoi.Open();
                    thuchien.ExecuteNonQuery();
                    ketnoi.Close();
                }
            }
        }
    }
}
