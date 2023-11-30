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
    public class AccesoDatosHoteles
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
        public DataTable visualizarEquipos()
        {
            AbrirConexion();
            MySqlCommand comando = new MySqlCommand("SP_visualizarHoteles", ConexionBD);
            comando.CommandType = CommandType.StoredProcedure;
            DataTable tablaDatosHotel = new DataTable();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            adaptador.Fill(tablaDatosHotel);
            CerrarConexion();
            return tablaDatosHotel;
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
        public DataTable InsertarHotel(CapaEntidad.EntidadHotel objEntidad)
        {
            AbrirConexion();
            MySqlCommand comando = new MySqlCommand("SP_insertarHotel", ConexionBD);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_idHotel", objEntidad.idHotel);
            comando.Parameters.AddWithValue("_name", objEntidad.nameHotel);
            comando.Parameters.AddWithValue("_description", objEntidad.description);
            comando.Parameters.AddWithValue("_price", objEntidad.price);
            comando.Parameters.AddWithValue("_agent", objEntidad.agent);
            comando.Parameters.AddWithValue("_state", objEntidad.state);
            DataTable tablaInsertarEquipo = new DataTable();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            adaptador.Fill(tablaInsertarEquipo);
            CerrarConexion();
            return tablaInsertarEquipo;
        }
        public DataTable actualizarHotel(CapaEntidad.EntidadHotel objEntidad)
        {
            AbrirConexion();
            MySqlCommand comando = new MySqlCommand("SP_editarHotel", ConexionBD);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_idHotel", objEntidad.idHotel);
            comando.Parameters.AddWithValue("_name", objEntidad.nameHotel);
            comando.Parameters.AddWithValue("_description", objEntidad.description);
            comando.Parameters.AddWithValue("_price", objEntidad.price);
            comando.Parameters.AddWithValue("_state", objEntidad.state);
            DataTable tablaEditarEquipo = new DataTable();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            adaptador.Fill(tablaEditarEquipo);
            CerrarConexion();
            return tablaEditarEquipo;
        }
    }
}
