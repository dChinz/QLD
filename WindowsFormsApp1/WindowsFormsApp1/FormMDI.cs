using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormMDI : Form
    {
        public FormMDI()
        {
            InitializeComponent();
        }

        private void khóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKhoa formKhoa = new FormKhoa();
            formKhoa.MdiParent = this;
            formKhoa.Show();
        }

        private void ngànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNganh formNganh = new FormNganh();  
            formNganh.MdiParent = this;
            formNganh.Show();
        }

        private void họcKỳToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHocKy formhocky = new FormHocKy();
            formhocky.MdiParent = this;
            formhocky.Show();
        }

        private void mônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHinhThuc formhinhthuc = new FormHinhThuc();
            formhinhthuc.MdiParent = this;
            formhinhthuc.Show();
        }

        private void lớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMonHoc formmonhoc = new FormMonHoc();
            formmonhoc.MdiParent = this;
            formmonhoc.Show();
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLopHoc formlophoc = new FormLopHoc();
            formlophoc.MdiParent = this;
            formlophoc.Show();
        }

        private void sinhViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormSinhVien formsinhvien = new FormSinhVien();
            formsinhvien.MdiParent = this;
            formsinhvien.Show();
        }

        private void điểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLanThi formlanthi = new FormLanThi();
            formlanthi.MdiParent = this;
            formlanthi.Show();
        }

        private void điểmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormDiem formdiem = new FormDiem();
            formdiem.MdiParent = this;
            formdiem.Show();
        }

        private void danhSáchĐiểmMônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDanhSachDiem formdanhsachdiem = new FormDanhSachDiem();
            formdanhsachdiem.MdiParent = this;
            formdanhsachdiem.Show();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDangNhap f = new FormDangNhap();
            f.MdiParent = this;
            f.Show();
        }

        private void FormMDI_Load(object sender, EventArgs e)
        {
            this.khóaToolStripMenuItem.Enabled = ClassDangNhap.DangNhap;
            this.ngànhToolStripMenuItem.Enabled = ClassDangNhap.DangNhap;
            this.họcKỳToolStripMenuItem.Enabled = ClassDangNhap.DangNhap;
            this.mônToolStripMenuItem.Enabled = ClassDangNhap.DangNhap;
            this.lớpToolStripMenuItem.Enabled = ClassDangNhap.DangNhap;
            this.sinhViênToolStripMenuItem.Enabled = ClassDangNhap.DangNhap;
            this.sinhViênToolStripMenuItem1.Enabled = ClassDangNhap.DangNhap;
            this.điểmToolStripMenuItem.Enabled = ClassDangNhap.DangNhap;
            this.điểmToolStripMenuItem1.Enabled = ClassDangNhap.DangNhap;
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.khóaToolStripMenuItem.Enabled = ClassDangNhap.DangNhap;
            this.ngànhToolStripMenuItem.Enabled = ClassDangNhap.DangNhap;
            this.họcKỳToolStripMenuItem.Enabled = ClassDangNhap.DangNhap;
            this.mônToolStripMenuItem.Enabled = ClassDangNhap.DangNhap;
            this.lớpToolStripMenuItem.Enabled = ClassDangNhap.DangNhap;
            this.sinhViênToolStripMenuItem.Enabled = ClassDangNhap.DangNhap;
            this.sinhViênToolStripMenuItem1.Enabled = ClassDangNhap.DangNhap;
            this.điểmToolStripMenuItem.Enabled = ClassDangNhap.DangNhap;
            this.điểmToolStripMenuItem1.Enabled = ClassDangNhap.DangNhap;
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void danhSáchChưaQuaMônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ForSvChuaQuaMon f = new ForSvChuaQuaMon();
            f.Show();
        }

        private void bảngĐiểmSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDiem1SV f = new FormDiem1SV();
            f.Show();
        }

        private void cácMônSinhViênChưaQuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMonSVChuaQua f = new FormMonSVChuaQua();
            f.Show();
        }
    }
}
