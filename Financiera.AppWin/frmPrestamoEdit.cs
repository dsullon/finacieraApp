using Financiera.Dominio;
using Financiera.Logic;
using System;
using System.Windows.Forms;

namespace Financiera.AppWin
{
    public partial class frmPrestamoEdit : Form
    {
        Prestamo prestamo;
        public frmPrestamoEdit(Prestamo prestamo)
        {
            this.prestamo = prestamo;
            InitializeComponent();
        }

        private void grabarRegistro(object sender, EventArgs e)
        {
            asignarObjeto();
            var exito = false;
            if(prestamo.ID == 0)
            {
                exito = PrestamoBL.Insertar(prestamo);
            } else
            {
                exito = PrestamoBL.Actualizar(prestamo);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void iniciarFormulario(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            var listado = ClienteBL.Listar();
            listado.Insert(0, new Cliente
            {
                Nombres = "--SELECCIONE--"
            });
            cboCliente.DataSource = listado;
            cboCliente.DisplayMember = "NombreCompleto";
            cboCliente.ValueMember = "ID";
        }

        private void asignarObjeto()
        {
            prestamo.IdCliente = int.Parse(cboCliente.SelectedValue.ToString());
            prestamo.FechaDeposito = dpFechaDeposito.Value;
            prestamo.Importe = decimal.Parse(txtImporte.Text);
            prestamo.Tasa = decimal.Parse(txtTasa.Text);
            prestamo.Plazo = int.Parse(txtPlazo.Text);
        }
    }
}
