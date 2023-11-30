using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class PresentacionImpuestos : Form
    {
        CapaNegocio.NegocioImpuestos objNegocio = new CapaNegocio.NegocioImpuestos();
        CapaEntidad.EntidadImpuesto objEntidad = new CapaEntidad.EntidadImpuesto();
        bool swTipoImpuesto;
        int codigoTipo;

        public PresentacionImpuestos()
        {
            InitializeComponent();
        }

        private void PresentacionImpuestos_Load(object sender, EventArgs e)
        {
            listarHabitaciones();
            ListarTypoImpuesto();
            listarTaxes();
        }

        public void listarHabitaciones()
        {
            DataTable tablaHabitaciones = new DataTable();
            tablaHabitaciones = objNegocio.listarHabitaciones();

            dgvHabitacion.DataSource = tablaHabitaciones;

            dgvHabitacion.Columns[1].Visible = false;
            dgvHabitacion.Columns[5].Visible = false;
            dgvHabitacion.Columns[7].Visible = false;
            dgvHabitacion.Columns[9].Visible = false;
        }
        public void listarTaxes()
        {
            DataTable tablaHabitaciones = new DataTable();
            tablaHabitaciones = objNegocio.listarTaxes();

            dgvImpuestos.DataSource = tablaHabitaciones;
            dgvImpuestos.Columns[2].Visible = false;
        }
        private void ListarTypoImpuesto()
        {
            DataTable tablaImpuesto = new DataTable();

            tablaImpuesto = objNegocio.listarTipoImpuesto();

            cmbImpuesto.DataSource = tablaImpuesto;
            cmbImpuesto.DisplayMember = "taxesTypeName";
            cmbImpuesto.ValueMember = "idtaxesType";
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                objEntidad.idroom = Convert.ToInt32(txtHabitacion.Text);
                objEntidad.idTypeImpuesto = Convert.ToInt32(cmbImpuesto.SelectedValue);
                DataTable validar = new DataTable();
                validar = objNegocio.ValidarImouesto(objEntidad);
                if (validar.Rows.Count > 0)
                {
                    MessageBox.Show("Ya existe ese impuesto en esa habitacion");
                }
                else
                {
                    DataTable roomTable = new DataTable();
                    roomTable = objNegocio.InsertarImouesto(objEntidad);


                    listarHabitaciones();
                    ListarTypoImpuesto();
                    listarTaxes();
                    MessageBox.Show("El producto fue insertado con exito");
                }
            }
            catch (Exception Err1)
            {
                MessageBox.Show("Se presentó el siguiente error de datos, por favor verificar" + Err1.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                objEntidad.idImpuesto = Convert.ToInt32(txtIdImpuesto.Text);

                objNegocio.ValidarDatos(objEntidad);
                if (objNegocio.stringBuilder.Length != 0)
                {
                    MessageBox.Show(objNegocio.stringBuilder.ToString(), "Validacion de Datos");
                }
                else
                {
                    DialogResult Salir = MessageBox.Show("Desea Eliminar este impuesto de la habitacion (Si/No)?", "Salir", MessageBoxButtons.YesNo);
                    if (Salir == DialogResult.Yes)
                    {

                        DataTable roomTable = new DataTable();
                        roomTable = objNegocio.EliminarImouesto(objEntidad);


                        MessageBox.Show("El producto fue Eliminado con exito");
                        txtIdImpuesto.Text = null;
                        listarHabitaciones();
                        ListarTypoImpuesto();
                        listarTaxes();
                    }
                    else
                    {
                        listarHabitaciones();
                        ListarTypoImpuesto();
                        listarTaxes();
                    }
                }
                   
            }
            catch (Exception Err1)
            {
                MessageBox.Show("Se presentó el siguiente error de datos, por favor verificar" + Err1.Message);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            DialogResult Salir = MessageBox.Show("Desea salir de la aplicacion (Si/No)?", "Salir", MessageBoxButtons.YesNo);
            if (Salir == DialogResult.Yes)
                this.Close();
                PresentacionNavegacion frmNavegacion = new PresentacionNavegacion();
                frmNavegacion.Show();
        }
        private void dgvHabitaciones_DoubleClick(object sender, EventArgs e)
        {
            int Fila = dgvHabitacion.CurrentRow.Index;
            txtHabitacion.Text = dgvHabitacion.Rows[Fila].Cells[0].Value.ToString();
        }
        private void dgvImpuestos_DoubleClick(object sender, EventArgs e)
        {
            int Fila = dgvImpuestos.CurrentRow.Index;
            txtIdImpuesto.Text = dgvImpuestos.Rows[Fila].Cells[0].Value.ToString();
            txtHabitacion.Text = dgvImpuestos.Rows[Fila].Cells[1].Value.ToString();
            cmbImpuesto.Text = dgvImpuestos.Rows[Fila].Cells[3].Value.ToString();
            codigoTipo = Convert.ToInt32(dgvImpuestos.Rows[Fila].Cells[2].Value);

        }
    }
}
