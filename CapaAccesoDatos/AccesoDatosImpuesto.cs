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
    public class AccesoDatosImpuesto
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
        public DataTable ListarTipoImpuesto()
        {
            AbrirConexion();
            MySqlCommand comando = new MySqlCommand("SELECT * FROM taxestype", ConexionBD);
            comando.CommandType = CommandType.Text;
            DataTable tablaEstado = new DataTable();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            adaptador.Fill(tablaEstado);
            CerrarConexion();
            return tablaEstado;
        }
        public DataTable ListarTaxes()
        {
            AbrirConexion();
            MySqlCommand comando = new MySqlCommand("SP_listarTaxes", ConexionBD);
            comando.CommandType = CommandType.StoredProcedure;
            DataTable tablaEstado = new DataTable();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            adaptador.Fill(tablaEstado);
            CerrarConexion();
            return tablaEstado;
        }
        public DataTable ValidarTaxesType(CapaEntidad.EntidadImpuesto objEntidad)
        {
            AbrirConexion();
            MySqlCommand comando = new MySqlCommand("SP_validarTaxes", ConexionBD);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_idRoom", objEntidad.idroom);
            comando.Parameters.AddWithValue("_idType", objEntidad.idTypeImpuesto);
            DataTable tablaEstado = new DataTable();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            adaptador.Fill(tablaEstado);
            CerrarConexion();
            return tablaEstado;
        }
        public DataTable EliminarTaxes(CapaEntidad.EntidadImpuesto objEntidad)
        {
            AbrirConexion();
            MySqlCommand comando = new MySqlCommand("SP_eliminarTaxe", ConexionBD);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_idTaxe", objEntidad.idImpuesto);
            DataTable tablaEstado = new DataTable();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            adaptador.Fill(tablaEstado);
            CerrarConexion();
            return tablaEstado;
        }
        public DataTable insertarImpuesto(CapaEntidad.EntidadImpuesto objEntidad)
        {
            AbrirConexion();
            MySqlCommand comando = new MySqlCommand("SP_insertarImpuesto", ConexionBD);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_idRoom", objEntidad.idroom);
            comando.Parameters.AddWithValue("_idType", objEntidad.idTypeImpuesto);
            DataTable tablaEstado = new DataTable();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            adaptador.Fill(tablaEstado);
            CerrarConexion();
            return tablaEstado;
        }
    }
}
