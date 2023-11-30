using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class AccesoDatosHabitaciones
    {
        MySqlConnection ConexionBD = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConexionMYSQL"].ConnectionString);

        void AbrirConexion()
        {
            if (ConexionBD.State == ConnectionState.Closed)
                ConexionBD.Open();
        }
        void CerrarConexion()
        {
            if (ConexionBD.State == ConnectionState.Open)
                ConexionBD.Close();
        }
        public DataTable ListarRooms()
        {
            AbrirConexion();
            MySqlCommand comando = new MySqlCommand("SP_listarHabitaciones", ConexionBD);
            comando.CommandType = CommandType.StoredProcedure;
            DataTable tablaEstado = new DataTable();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            adaptador.Fill(tablaEstado);
            CerrarConexion();
            return tablaEstado;
        }
        public DataTable ListarEstado()
        {
            AbrirConexion();
            MySqlCommand comando = new MySqlCommand("SP_listarEstado", ConexionBD);
            comando.CommandType = CommandType.StoredProcedure;
            DataTable tablaEstado = new DataTable();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            adaptador.Fill(tablaEstado);
            CerrarConexion();
            return tablaEstado;
        }
        public DataTable ListarHoteles()
        {
            AbrirConexion();
            MySqlCommand comando = new MySqlCommand("SP_listarHoteles", ConexionBD);
            comando.CommandType = CommandType.StoredProcedure;
            DataTable tablaEstado = new DataTable();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            adaptador.Fill(tablaEstado);
            CerrarConexion();
            return tablaEstado;
        }

        public DataTable ListarTiposHabitacion()
        {
            AbrirConexion();
            MySqlCommand comando = new MySqlCommand("SP_listarTipoHabit", ConexionBD);
            comando.CommandType = CommandType.StoredProcedure;
            DataTable tablaTipo = new DataTable();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            adaptador.Fill(tablaTipo);
            CerrarConexion();
            return tablaTipo;
        }
        public DataTable InsertarHabitaciones(CapaEntidad.EntidadHabitacion objEntidad)
        {
            AbrirConexion();
            MySqlCommand comando = new MySqlCommand("SP_insertarHabitacion", ConexionBD);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_idRoom", objEntidad.idRoom);
            comando.Parameters.AddWithValue("_description", objEntidad.description);
            comando.Parameters.AddWithValue("_price", objEntidad.price);
            comando.Parameters.AddWithValue("_roomType", objEntidad.roomType);
            comando.Parameters.AddWithValue("_state", objEntidad.state);
            DataTable tablaInsertarEquipo = new DataTable();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            adaptador.Fill(tablaInsertarEquipo);
            CerrarConexion();
            return tablaInsertarEquipo;
        }
        public DataTable ActualizarHabitacion(CapaEntidad.EntidadHabitacion objEntidad)
        {
            AbrirConexion();
            MySqlCommand comando = new MySqlCommand("SP_editarHabitacion", ConexionBD);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_idRoom", objEntidad.idRoom);
            comando.Parameters.AddWithValue("_description", objEntidad.description);
            comando.Parameters.AddWithValue("_price", objEntidad.price);
            comando.Parameters.AddWithValue("_roomType", objEntidad.roomType);
            comando.Parameters.AddWithValue("_state", objEntidad.state);
            DataTable tablaInsertarEquipo = new DataTable();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            adaptador.Fill(tablaInsertarEquipo);
            CerrarConexion();
            return tablaInsertarEquipo;
        }
        public DataTable ActualizarBelong(CapaEntidad.EntidadHabitacion objEntidad)
        {
            AbrirConexion();
            MySqlCommand comando = new MySqlCommand("SP_actualizarBelong", ConexionBD);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_idBelong", objEntidad.Belong);
            comando.Parameters.AddWithValue("_hotel", objEntidad.idHotel);
            DataTable tablaInsertarEquipo = new DataTable();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            adaptador.Fill(tablaInsertarEquipo);
            CerrarConexion();
            return tablaInsertarEquipo;
        }
        public DataTable InsertarBelongs(CapaEntidad.EntidadHabitacion objEntidad)
        {
            AbrirConexion();
            MySqlCommand comando = new MySqlCommand("SP_insertarBelong", ConexionBD);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_idRoom", objEntidad.idRoom);
            comando.Parameters.AddWithValue("_idHotel", objEntidad.idHotel);
            DataTable tablaInsertarEquipo = new DataTable();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            adaptador.Fill(tablaInsertarEquipo);
            CerrarConexion();
            return tablaInsertarEquipo;
        }
    }
}
