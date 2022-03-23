using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelRezervasyonSistemi.Formlar
{
    public partial class frmAnaGiris : Form
    {
        public frmAnaGiris()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            frmOtelIslemleri frm = new frmOtelIslemleri();
            frm.Show();
            this.Hide();

        }

      
    }
}
