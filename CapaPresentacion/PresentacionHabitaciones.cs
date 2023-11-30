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
    public partial class PresentacionHabitaciones : Form
    {
        CapaEntidad.EntidadHabitacion objEntidad = new CapaEntidad.EntidadHabitacion();
        CapaNegocio.NegocioHabitaciones objNegocio = new CapaNegocio.NegocioHabitaciones();
        bool swState, swType, swHotel;
        string codigoState, codigoType, codigoHotel;
        public PresentacionHabitaciones()
        {
            InitializeComponent();
        }

        private void PresentacionHabitaciones_Load(object sender, EventArgs e)
        {
            ListarHabitaciones();
            ListarEstado();
            ListarTipoHabitacion();
            ListarHoteles();
        }

        private void ListarHabitaciones()
        {
            DataTable tablaHabitaciones = new DataTable();
            tablaHabitaciones = objNegocio.listarHabitaciones();

            dgvHabitaciones.DataSource = tablaHabitaciones;

            dgvHabitaciones.Columns[1].Visible = false;
            dgvHabitaciones.Columns[5].Visible = false;
            dgvHabitaciones.Columns[7].Visible = false;
            dgvHabitaciones.Columns[9].Visible = false;
        }
        private void ListarEstado()
        {
            DataTable tablaEstado = new DataTable();

            tablaEstado = objNegocio.listarEstados();

            cmbEstado.DataSource = tablaEstado;
            cmbEstado.DisplayMember = "stateName";
            cmbEstado.ValueMember = "idState";
        }
        private void ListarHoteles()
        {
            DataTable tablaHotel = new DataTable();

            tablaHotel = objNegocio.listarHotel();

            cmbHotel.DataSource = tablaHotel;
            cmbHotel.DisplayMember = "name";
            cmbHotel.ValueMember = "idHotel";
        }
        private void ListarTipoHabitacion()
        {
            DataTable tablaTipoH = new DataTable();

            tablaTipoH = objNegocio.listarTiposHabitacion();

            cmbType.DataSource = tablaTipoH;
            cmbType.DisplayMember = "nameRoomType";
            cmbType.ValueMember = "idRoomType";
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                objEntidad.idRoom = Convert.ToInt32(txtIdRoom.Text);
                objEntidad.description = txtDescription.Text;
                objEntidad.price = txtPrice.Text;
                objEntidad.roomType = Convert.ToInt32(cmbType.SelectedValue);
                objEntidad.state = Convert.ToInt32(cmbEstado.SelectedValue);
                objEntidad.idHotel = Convert.ToInt32(cmbHotel.SelectedValue);

                objNegocio.ValidarDatos(objEntidad);
                if(objNegocio.stringBuilder.Length != 0)
                {
                    MessageBox.Show(objNegocio.stringBuilder.ToString(), "Validacion de Datos");
                }
                else
                {
                    DataTable roomTable = new DataTable();
                    roomTable = objNegocio.InsertarHabitacion(objEntidad);

                    ListarEstado();
                    ListarTipoHabitacion();
                    ListarHabitaciones();
                    roomTable = objNegocio.CrearUnion(objEntidad);
                    MessageBox.Show("El producto fue insertado con exito");
                }
            }
            catch (MySqlException Err)
            {
                if (Err.Number == 1062)
                    MessageBox.Show("El código ya está asociado a un producto, verificar");
                    txtIdRoom.Focus();
            }
            catch (Exception Err1)
            {
                MessageBox.Show("Se presentó el siguiente error de datos, por favor verificar" + Err1.Message);
            }

        }
        private void dgvHabitaciones_DoubleClick(object sender, EventArgs e)
        {
            int Fila = dgvHabitaciones.CurrentRow.Index;
            txtIdRoom.Enabled = false;
            txtIdRoom.Text = dgvHabitaciones.Rows[Fila].Cells[0].Value.ToString();
            txtDescription.Text = dgvHabitaciones.Rows[Fila].Cells[3].Value.ToString();
            txtPrice.Text = dgvHabitaciones.Rows[Fila].Cells[4].Value.ToString();

            codigoHotel = dgvHabitaciones.Rows[Fila].Cells[1].Value.ToString();
            codigoState = dgvHabitaciones.Rows[Fila].Cells[7].Value.ToString();
            codigoType = dgvHabitaciones.Rows[Fila].Cells[5].Value.ToString();

            cmbEstado.Text = dgvHabitaciones.Rows[Fila].Cells[8].Value.ToString();
            cmbType.Text = dgvHabitaciones.Rows[Fila].Cells[6].Value.ToString();
            cmbHotel.Text = dgvHabitaciones.Rows[Fila].Cells[2].Value.ToString();
            objEntidad.Belong = Convert.ToInt32(dgvHabitaciones.Rows[Fila].Cells[9].Value);
        }


        private void cmbState_SelectionChangeCommitted(object sender, EventArgs a)
        {
            swState = true;
        }

        private void cmbType_SelectionChangeCommitted(object sender, EventArgs a)
        {
            swType = true;
        }

        private void cmbIdHotel_SelectionChangeCommitted(object sender, EventArgs a)
        {
            swHotel = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                objEntidad.idRoom = Convert.ToInt32(txtIdRoom.Text);
                objEntidad.description = txtDescription.Text;
                objEntidad.price = txtPrice.Text;

                if (swState == true)
                {
                    objEntidad.state = Convert.ToInt32(cmbEstado.SelectedValue);
                    swState = false;
                }
                else
                {
                    objEntidad.state = Convert.ToInt32(codigoState);
                }

                if (swType == true)
                {
                    objEntidad.roomType = Convert.ToInt32(cmbType.SelectedValue);
                    swType = false;
                }
                else
                {
                    objEntidad.roomType = Convert.ToInt32(codigoType);
                }

                if (swHotel == true)
                {
                    objEntidad.idHotel = Convert.ToInt32(cmbHotel.SelectedValue);
                    swHotel = false;
                }
                else
                {
                    objEntidad.idHotel = Convert.ToInt32(codigoHotel);
                }

                objNegocio.ValidarDatos(objEntidad);
                if (objNegocio.stringBuilder.Length != 0)
                {
                    MessageBox.Show(objNegocio.stringBuilder.ToString(), "Validacion de Datos");
                }
                else
                {
                    DataTable tablaHotel = new DataTable();
                    tablaHotel = objNegocio.EditarHabitacion(objEntidad);

                    DataTable tablaBelong = new DataTable();
                    tablaBelong = objNegocio.EditarBelong(objEntidad);


                    MessageBox.Show("El producto fue Actualizado con exito");
                    ListarEstado();
                    ListarHabitaciones();
                    ListarHoteles();
                    ListarTipoHabitacion();
                }
                txtIdRoom.Enabled = true;
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
    }
}
