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
    public partial class PresentacionNavegacion : Form
    {
        public PresentacionNavegacion()
        {
            InitializeComponent();
        }

        private void btnHotel_Click(object sender, EventArgs e)
        {
            this.Hide();
            PresentacionHoteles frmHotel = new PresentacionHoteles();
            frmHotel.Show();

        }

        private void btnHabitaciones_Click(object sender, EventArgs e)
        {

            this.Hide();
            PresentacionHabitaciones frmHabitacion = new PresentacionHabitaciones();
            frmHabitacion.Show();
        }

        private void PresentacionNavegacion_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult Salir = MessageBox.Show("Desea salir de la aplicacion (Si/No)?", "Salir", MessageBoxButtons.YesNo);
            if (Salir == DialogResult.Yes)
                this.Close();
                PresentacionIngresoUsuario frmIngresoSesion = new PresentacionIngresoUsuario();
                frmIngresoSesion.Show();
        }

        private void btnNavegacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            PresentacionImpuestos frmHabitacion = new PresentacionImpuestos();
            frmHabitacion.Show();
        }
    }
}
