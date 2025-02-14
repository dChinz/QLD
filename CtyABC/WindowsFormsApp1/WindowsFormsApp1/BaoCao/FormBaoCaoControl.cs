using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.BaoCao
{
    public partial class FormBaoCaoControl : Form
    {
        public FormBaoCaoControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BCKhach bCKhach = new BCKhach();
            bCKhach.Show();
        }
    }
}
