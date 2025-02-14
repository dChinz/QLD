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
using Microsoft.Reporting.WinForms;

namespace WindowsFormsApp1.BaoCao
{
    public partial class BCKhach : Form
    {
        public BCKhach()
        {
            InitializeComponent();
        }

        string lenh;
        string nguon = @"Data Source=DESKTOP-GK5VJ4R;Initial Catalog=CtyABC;Integrated Security=True;";
        SqlConnection ketnoi;
        SqlDataReader doc;
        SqlCommand thuchien;

        private void BCKhach_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(nguon);
            lenh = @"select tenkh from dmkhach";
            thuchien = new SqlCommand(lenh, ketnoi);
            ketnoi.Open();
            doc = thuchien.ExecuteReader();
            while (doc.Read())
            {
                comboBoxMaKH.Items.Add(doc[0]);
            }
            ketnoi.Close();
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
                // Kiểm tra nếu chưa chọn khách hàng
                if (comboBoxMaKH.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng!");
                    return;
                }

                string tenKhach = comboBoxMaKH.SelectedItem.ToString();
                DateTime ngayBD = DateTime.Parse(textBoxNgayBD.Text);
                DateTime ngayKT = DateTime.Parse(textBoxNgayKT.Text);

                using (SqlConnection ketnoi = new SqlConnection(nguon))
                {
                    ketnoi.Open();
                    string sqlSV = @"SELECT hdnhap_xuat.sohd, hdnhap_xuat.ngay, dmhang.tenhang, dmhang.dongia, 
                                    cthdnhap_xuat.soluong, cthdnhap_xuat.gia, dmkhach.tenkh
                            FROM   hdnhap_xuat 
                            INNER JOIN cthdnhap_xuat ON hdnhap_xuat.sohd = cthdnhap_xuat.sohd 
                            INNER JOIN dmkhach ON hdnhap_xuat.makh = dmkhach.makh 
                            INNER JOIN dmhang ON cthdnhap_xuat.mahang = dmhang.mahang
                            WHERE (dmkhach.tenkh = @tenkh) 
                                  AND (hdnhap_xuat.ngay BETWEEN @ngayBD AND @ngayKT)
                            ORDER BY hdnhap_xuat.ngay ASC;";

                    DataTable dtDiem = new DataTable();
                    using (SqlCommand thuchien = new SqlCommand(sqlSV, ketnoi))
                    {
                        thuchien.Parameters.Add("@tenkh", SqlDbType.NVarChar).Value = tenKhach;
                        thuchien.Parameters.Add("@ngayBD", SqlDbType.Date).Value = ngayBD;
                        thuchien.Parameters.Add("@ngayKT", SqlDbType.Date).Value = ngayKT;

                        SqlDataAdapter sda = new SqlDataAdapter(thuchien);
                        sda.Fill(dtDiem);
                    }

                    if (dtDiem.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu để hiển thị!");
                        return;
                    }

                    // Cấu hình ReportViewer
                    reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.LocalReport.ReportPath = @"D:\XDPHQLD\CtyABC\WindowsFormsApp1\WindowsFormsApp1\BaoCao\ReportKhach.rdlc";

                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetBCKhach", dtDiem));

                    // Thiết lập tham số cho báo cáo
                    ReportParameter[] param = new ReportParameter[]
                    {
                            new ReportParameter("ngayBD", Convert.ToDateTime(ngayBD.ToString()).ToString("dd/MM/yyyy")),
                            new ReportParameter("ngayKT", Convert.ToDateTime(ngayKT.ToString()).ToString("dd/MM/yyyy"))
                    };
                    reportViewer1.LocalReport.SetParameters(param);

                    reportViewer1.RefreshReport();
                }
            //}
            //catch (Exception ex)
            //{
                //MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message);
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
