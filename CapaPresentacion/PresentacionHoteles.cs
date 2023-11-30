using MySql.Data.MySqlClient;
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
    public partial class PresentacionHoteles : Form
    {
        CapaEntidad.EntidadHotel objEntidad = new CapaEntidad.EntidadHotel();
        CapaEntidad.EntidadRegistroUsuario objEntidadUser = new CapaEntidad.EntidadRegistroUsuario();
        CapaNegocio.NegocioHoteles objNegocio = new CapaNegocio.NegocioHoteles();
        bool swState;
        string codigoState;
        public PresentacionHoteles()
        {
            InitializeComponent();
        }

        private void PresentacionHoteles_Load(object sender, EventArgs e)
        {
            ListarEstado();
            visualizarHotel();
        }

        private void ListarEstado()
        {
            DataTable tablaEstado = new DataTable();

            tablaEstado = objNegocio.listarEstado();

            cmbEstado.DataSource = tablaEstado;
            cmbEstado.DisplayMember = "stateName";
            cmbEstado.ValueMember = "idState";
        }

        private void visualizarHotel()
        {
            DataTable tablaHoteles = new DataTable();
            tablaHoteles = objNegocio.listarHoteles();
            dgvHotels.DataSource = tablaHoteles;
            //txtAgent.Text = Convert.ToInt32(objEntidad.agent);

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                objEntidad.description = txtDescription.Text;
                objEntidad.nameHotel = txtName.Text;
                objEntidad.price = txtPrice.Text;
                objEntidad.state = Convert.ToInt32(cmbEstado.SelectedValue);
                objEntidad.idHotel = Convert.ToInt32(txtIdHotel.Text);

                objNegocio.ValidarDatos(objEntidad);
                if(objNegocio.stringBuilder.Length != 0)
                {
                    MessageBox.Show(objNegocio.stringBuilder.ToString(), "Validacion de Datos");
                }
                else
                {
                    DataTable tablaHotel = new DataTable();
                    tablaHotel = objNegocio.InsertarHotel(objEntidad);


                    MessageBox.Show("El producto fue insertado con exito");
                    ListarEstado();
                    visualizarHotel();
                }

            }
            catch (MySqlException Err)
            {
                if (Err.Number == 1062)
                    MessageBox.Show("El código ya está asociado a un producto, verificar");
                txtIdHotel.Focus();
            }
            catch (Exception Err1)
            {
                MessageBox.Show("Se presentó el siguiente error de datos, por favor verificar" + Err1.Message);
            }
        }

        private void dgvHotels_DoubleClick(object sender, EventArgs e)
        {
            txtIdHotel.Enabled = false;
            int Fila = dgvHotels.CurrentRow.Index;
            txtIdHotel.Text = dgvHotels.Rows[Fila].Cells[0].Value.ToString();
            txtName.Text = dgvHotels.Rows[Fila].Cells[1].Value.ToString();
            txtDescription.Text = dgvHotels.Rows[Fila].Cells[2].Value.ToString();
            txtPrice.Text = dgvHotels.Rows[Fila].Cells[3].Value.ToString();
            txtAgent.Text = dgvHotels.Rows[Fila].Cells[4].Value.ToString();
            cmbEstado.Text = dgvHotels.Rows[Fila].Cells[5].Value.ToString();
            codigoState = dgvHotels.Rows[Fila].Cells[6].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                objEntidad.description = txtDescription.Text;
                objEntidad.nameHotel = txtName.Text;
                objEntidad.price = txtPrice.Text;
                objEntidad.agent = Convert.ToInt32(txtAgent.Text);
                objEntidad.idHotel = Convert.ToInt32(txtIdHotel.Text);

                if (swState == true)
                {
                    objEntidad.state = Convert.ToInt32(cmbEstado.SelectedValue);
                    swState = false;
                }
                else
                {
                    objEntidad.state = Convert.ToInt32(codigoState);
                }

                objNegocio.ValidarDatos(objEntidad);
                if (objNegocio.stringBuilder.Length != 0)
                {
                    MessageBox.Show(objNegocio.stringBuilder.ToString(), "Validacion de Datos");
                }
                else
                {
                    DataTable tablaHotel = new DataTable();
                    tablaHotel = objNegocio.ActualizarHotel(objEntidad);


                    MessageBox.Show("El producto fue Actualizado con exito");
                    ListarEstado();
                    visualizarHotel();
                }
                txtIdHotel.Enabled = true;
            }
            catch (MySqlException Err)
            {
                MessageBox.Show("Se presentó el siguiente error de datos, por favor verificar" + Err.Message);
            }
        }

        private void cmbState_SelectionChangeCommitted(object sender, EventArgs a)
        {
            swState = true;
        }
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            this.Close();
            PresentacionHabitaciones frmHabit = new PresentacionHabitaciones();
            frmHabit.Show();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            DialogResult Salir = MessageBox.Show("Desea salir de la aplicacion (Si/No)?", "Salir", MessageBoxButtons.YesNo);
            if (Salir == DialogResult.Yes)
                this.Close();
                PresentacionNavegacion frmNavegacion = new PresentacionNavegacion();
                frmNavegacion.Show();

        }
    }
}
