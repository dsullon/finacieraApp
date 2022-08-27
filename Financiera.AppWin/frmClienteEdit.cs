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
            if(cliente.ID > 0)
            {
                asignarControles();
            }
        }

        private void cargarDatos()
        {
            // Listar los tipo de documentos
            cboTipoDocumento.DataSource = TipoDocumentoBL.Listar();
            cboTipoDocumento.DisplayMember = "Nombre";
            cboTipoDocumento.ValueMember = "ID";

            //Listar los tipos de clientes
            cboTipoCliente.DataSource = TipoClienteBL.Listar();
            cboTipoCliente.DisplayMember = "Nombre";
            cboTipoCliente.ValueMember = "ID";

        }

        private void grabarDatos(object sender, EventArgs e)
        {
            asignarObjeto();
            this.DialogResult = DialogResult.OK;
        }

        private void asignarObjeto()
        {
            cliente.Nombres = txtNombre.Text;
            cliente.Apellidos = txtApellido.Text;
            cliente.Direccion = txtDireccion.Text;
            cliente.Referencia = txtReferencia.Text;
            cliente.IdTipoCliente = int.Parse(cboTipoCliente.SelectedValue.ToString());
            cliente.IdTipoDocumento = int.Parse(cboTipoDocumento.SelectedValue.ToString());
            cliente.NumeroDocumento = txtNumeroDocumento.Text;
            cliente.Estado = chkEstado.Checked;
        }

        private void asignarControles()
        {
            txtNombre.Text = cliente.Nombres;
            txtApellido.Text = cliente.Apellidos;
            txtDireccion.Text = cliente.Direccion;
            txtReferencia.Text = cliente.Referencia;
            cboTipoCliente.SelectedValue = cliente.IdTipoCliente;
            cboTipoDocumento.SelectedValue = cliente.IdTipoDocumento;
            txtNumeroDocumento.Text = cliente.NumeroDocumento;
            chkEstado.Checked = cliente.Estado;
        }
    }
}
