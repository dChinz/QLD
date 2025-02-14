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
    public partial class FormMdi : Form
    {
        public FormMdi()
        {
            InitializeComponent();
        }

        private void buttonCapnhat_Click(object sender, EventArgs e)
        {
            FormControl formControl = new FormControl();
            formControl.Show();
        }

        private void buttonXuly_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonBaocao_Click(object sender, EventArgs e)
        {
            BaoCao.FormBaoCaoControl f = new BaoCao.FormBaoCaoControl();
            f.Show();
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
