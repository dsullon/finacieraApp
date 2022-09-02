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
            if (exito)
            {
                MessageBox.Show("El préstamo ha sido registrado", "Financiera", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("No se ha podido completar la operación", "Financiera",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void iniciarFormulario(object sender, EventArgs e)
        {
            cargarDatos();
            llDetalle.Visible = prestamo.ID > 0;
            btnGrabar.Enabled = prestamo.ID == 0;
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

        private void verCuotas(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new frmCuotas();
            frm.ShowDialog();
        }
    }
}
