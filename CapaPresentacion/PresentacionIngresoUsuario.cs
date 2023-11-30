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
    public partial class PresentacionIngresoUsuario : Form
    {
        CapaEntidad.EntidadRegistroUsuario objEntidad = new CapaEntidad.EntidadRegistroUsuario();
        CapaEntidad.EntidadHotel objEntidadHotel = new CapaEntidad.EntidadHotel();
        CapaNegocio.NegocioRegistroUsuario objNegocio = new CapaNegocio.NegocioRegistroUsuario();

        public PresentacionIngresoUsuario()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {

            try
            {

                objEntidad.password = txtPassword.Text;
                objEntidad.user = txtCedula.Text;

                objNegocio.ValidarIngresoUsuario(objEntidad);
                if (objNegocio.stringBuilder.Length != 0)
                {
                    MessageBox.Show(objNegocio.stringBuilder.ToString(), "Validacion de Datos");
                }
                else
                {
                    DataTable TablaDatosUsuarios = new DataTable();
                    TablaDatosUsuarios = objNegocio.IngresoUsuario(objEntidad);
                    if (TablaDatosUsuarios.Rows.Count > 0)
                    {

                        object data = objNegocio.obtenerIdAsesor(objEntidad);

                        // Usando Convert.ToInt32
                        objEntidad.idAgent = Convert.ToInt32(data);


                        MessageBox.Show("Bienvenido a la aplicacion");
                        this.Hide();
                        PresentacionNavegacion frmEquipos = new PresentacionNavegacion();
                        frmEquipos.Show();
                    }
                    else
                    {
                        MessageBox.Show("Datos Incorrectos");
                        txtCedula.Clear();
                        txtPassword.Clear();

                    }
                }

            }
            catch(MySqlException Err)
            {
                if (Err.Number == 1042)
                    MessageBox.Show("Error en la base de datos, revisar la conexión");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult Salir = MessageBox.Show("Desea salir de la aplicacion (Si/No)?", "Salir", MessageBoxButtons.YesNo);
            if (Salir == DialogResult.Yes)
                Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            PresentacionRegistroUsuario frmUsuario = new PresentacionRegistroUsuario();
            frmUsuario.Show();
        }
    }
}
