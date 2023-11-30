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
    public partial class PresentacionRegistroUsuario : Form
    {
        CapaEntidad.EntidadRegistroUsuario objEntidad = new CapaEntidad.EntidadRegistroUsuario();
        CapaNegocio.NegocioRegistroUsuario objNegocio = new CapaNegocio.NegocioRegistroUsuario();
        public PresentacionRegistroUsuario()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                objEntidad.name = txtNombre.Text;
                objEntidad.lastName = txtApellido.Text;
                objEntidad.user = txtCedula.Text;
                objEntidad.password = txtPassword.Text;
                objEntidad.VerifyPassword = txtVerifyPass.Text;

                objNegocio.ValidarDatosUsuario(objEntidad);

                if(objNegocio.stringBuilder.Length != 0)
                {
                    MessageBox.Show(objNegocio.stringBuilder.ToString(), "Validacion de Datos");
                }
                else
                {
                    DataTable tablaDataUsuario = new DataTable();
                    tablaDataUsuario = objNegocio.ValidarRegistroUsuario(objEntidad);
                    if(tablaDataUsuario.Rows.Count > 0)
                    {
                        MessageBox.Show("Esa cedula ya fue registrada");
                    }
                    else
                    {
                       if(objEntidad.VerifyPassword == objEntidad.password)
                        {
                            tablaDataUsuario = objNegocio.DatosUsuario(objEntidad);
                            MessageBox.Show("Se registró correctamente");
                            this.Hide();
                            PresentacionIngresoUsuario frmUsuario = new PresentacionIngresoUsuario();
                            frmUsuario.Show();
                        }
                        else
                        {
                            MessageBox.Show("Verifica, las contraseñas no coinciden");
                        }
                    }
                }
            }catch(MySqlException Err)
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
            PresentacionIngresoUsuario frmUsuario = new PresentacionIngresoUsuario();
            frmUsuario.Show();
        }
    }
}
