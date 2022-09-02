using Financiera.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financiera.AppWin
{
    public partial class frmPrestamo : Form
    {
        public frmPrestamo()
        {
            InitializeComponent();
        }

        private void nuevoRegistro(object sender, EventArgs e)
        {
            var prestamo = new Prestamo();
            var frm = new frmPrestamoEdit(prestamo);
            if(frm.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void verDetalle(object sender, EventArgs e)
        {
            var prestamo = new Prestamo();
            prestamo.ID = 1;
            var frm = new frmPrestamoEdit(prestamo);
            frm.ShowDialog();
        }
    }
}
