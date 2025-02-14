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
    public partial class FormXuLy : Form
    {
        public FormXuLy()
        {
            InitializeComponent();

            buttonKhachHang.Tag = "khachhang";
            buttonHoaDon.Tag = "hoadon";
            buttonHangHoa.Tag = "hanghoa";
            buttonPThuChi.Tag = "pthuchi";
            buttonCTHD.Tag = "cthd";
        }

        string sql;
        string nguon = @"Data Source=DESKTOP-GK5VJ4R;Initial Catalog=CtyABC;Integrated Security=True";
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader doc;

        private void FormXuLy_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(nguon);
            sql = @"SELECT COUNT(*) 
                    FROM (
                        SELECT TenKH, DiaChi, SoDT
                        FROM KhachHang
                        GROUP BY TenKH, DiaChi, SoDT
                        HAVING COUNT(*) > 1
                    ) AS TrungTenKH ";
            thuchien = new SqlCommand(sql, ketnoi);
            ketnoi.Open();
            object a = thuchien.ExecuteScalar();
            int soKH = a != null ? Convert.ToInt32(a) : 0;
            labelKH.Text = soKH.ToString();
            ketnoi.Close();
            //-----------------------------------------------
            sql = @"SELECT COUNT(*) 
                    FROM (
                        SELECT TenHang, DonViTinh, DonGia
                        FROM Hang
                        GROUP BY TenHang, DonViTinh, DonGia
                        HAVING COUNT(*) > 1
                    ) AS TrungTenKH ";
            thuchien = new SqlCommand(sql, ketnoi);
            ketnoi.Open();
            object b = thuchien.ExecuteScalar();
            int soHang = b != null ? Convert.ToInt32(b) : 0;
            labelHang.Text = soHang.ToString();
            ketnoi.Close();
            //----------------------------------------------
            sql = @"SELECT COUNT(*) 
                    FROM (
                        SELECT KieuHD, Ngay, MaKH, SoTienTT
                        FROM HoaDonNhapXuat
                        GROUP BY KieuHD, Ngay, MaKH, SoTienTT
                        HAVING COUNT(*) > 1
                    ) AS TrungTenKH ";
            thuchien = new SqlCommand(sql, ketnoi);
            ketnoi.Open();
            object c = thuchien.ExecuteScalar();
            int soHD = c != null ? Convert.ToInt32(c) : 0;
            labelHD.Text = soHD.ToString();
            ketnoi.Close();
            //----------------------------------------------
            sql = @"SELECT COUNT(*) 
                    FROM (
                        SELECT KieuPhieu, Ngay, MaKH, SoTien
                        FROM PhieuThuChi
                        GROUP BY KieuPhieu, Ngay, MaKH, SoTien
                        HAVING COUNT(*) > 1
                    ) AS TrungTenKH ";
            thuchien = new SqlCommand(sql, ketnoi);
            ketnoi.Open();
            object d = thuchien.ExecuteScalar();
            int soPTC = d != null ? Convert.ToInt32(d) : 0;
            labelPThuCHi.Text = soPTC.ToString();
            ketnoi.Close();
            //----------------------------------------------
            sql = @"SELECT COUNT(*) 
                    FROM (
                        SELECT SoHD, MaHang, SoLuong, Gia
                        FROM CTHoaDonNhapXuat
                        GROUP BY SoHD, MaHang, SoLuong, Gia
                        HAVING COUNT(*) > 1
                    ) AS TrungTenKH ";
            thuchien = new SqlCommand(sql, ketnoi);
            ketnoi.Open();
            object f = thuchien.ExecuteScalar();
            int soCTHD = f != null ? Convert.ToInt32(f) : 0;
            labelCTHD.Text = soCTHD.ToString();
            ketnoi.Close();
            //----------------------------------------------
        }

        private void buttonKhachHang_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is string moduleName)
            {
                FormXuLyTrungLap f = new FormXuLyTrungLap(moduleName);
                f.Show();
            }
        }

        private void buttonHangHoa_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is string moduleName)
            {
                FormXuLyTrungLap f = new FormXuLyTrungLap(moduleName);
                f.Show();
            }
        }

        private void buttonHoaDon_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is string moduleName)
            {
                FormXuLyTrungLap f = new FormXuLyTrungLap(moduleName);
                f.Show();
            }
        }

        private void buttonPThuChi_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is string moduleName)
            {
                FormXuLyTrungLap f = new FormXuLyTrungLap(moduleName);
                f.Show();
            }
        }

        private void buttonCTHD_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is string moduleName)
            {
                FormXuLyTrungLap f = new FormXuLyTrungLap(moduleName);
                f.Show();
            }
        }
    }
}
