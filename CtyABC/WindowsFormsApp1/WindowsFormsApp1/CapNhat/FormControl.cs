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
    public partial class FormControl : Form
    {
        public FormControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormKH formKH = new FormKH();
            formKH.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormHH formHH = new FormHH();
            formHH.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormHD formHD = new FormHD();
            formHD.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormCTHD formCTHD = new FormCTHD();
            formCTHD.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormPTC formPTC = new FormPTC();
            formPTC.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
