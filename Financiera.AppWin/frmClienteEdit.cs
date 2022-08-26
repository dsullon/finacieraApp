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
    public partial class frmClienteEdit : Form
    {
        Cliente cliente;

        public frmClienteEdit(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
        }

        private void iniciarFormulario(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            cboTipoDocumento.DataSource = TipoDocumentoBL.Listar();
            cboTipoDocumento.DisplayMember = "Nombre";
            cboTipoDocumento.ValueMember = "ID";
        }
    }
}
