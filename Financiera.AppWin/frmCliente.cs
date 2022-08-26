using Financiera.Dominio;
using Financiera.Logic;
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
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void IniciarFormulario(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            var listado = ClienteBL.Listar();
            foreach (var cliente in listado)
            {
                dgvListado.Rows.Add(cliente.ID, cliente.NombreCompleto, cliente.Direccion);
            }
            
        }

        private void nuevoRegistro(object sender, EventArgs e)
        {
            var nuevoCliente = new Cliente();
            var frm = new frmClienteEdit(nuevoCliente);
            if(frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
