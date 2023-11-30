using MySql.Data.MySqlClient;
using Npgsql;
using System.Configuration;
using System.Data;

namespace CapaAccesoDatos
{
    public class AccesoDatosIngresoUsuario
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

        public DataTable registrarUsuario(CapaEntidad.EntidadRegistroUsuario objEntidad)
        {
            AbrirConexion();
            MySqlCommand comando = new MySqlCommand("SP_registrarAgente", ConexionBD);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_name", objEntidad.name);
            comando.Parameters.AddWithValue("_lastName", objEntidad.lastName);
            comando.Parameters.AddWithValue("_document", objEntidad.user);
            comando.Parameters.AddWithValue("_password", objEntidad.password);
            DataTable userDataTable = new DataTable();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            adaptador.Fill(userDataTable);
            CerrarConexion();
            return userDataTable;
        }
        public DataTable validarUsuario(CapaEntidad.EntidadRegistroUsuario objEntidad)
        {
            AbrirConexion();
            MySqlCommand comando = new MySqlCommand("SP_validarRegistroAgent", ConexionBD);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_document", objEntidad.user);
            DataTable tablaDatosUsuarios = new DataTable();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            adaptador.Fill(tablaDatosUsuarios);
            CerrarConexion();
            return tablaDatosUsuarios;
        }
        public object obtenerIdAsesor(CapaEntidad.EntidadRegistroUsuario objEntidad)
        {
            AbrirConexion();
            MySqlCommand comando = new MySqlCommand("SP_validarRegistroAgent", ConexionBD);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_document", objEntidad.user);
            object res = comando.ExecuteScalar();
            CerrarConexion();
            return res;
        }


        public DataTable ingresoUsuario(CapaEntidad.EntidadRegistroUsuario objEntidad)
        {
            AbrirConexion();
            MySqlCommand comando = new MySqlCommand("SP_ingresoUsuario", ConexionBD);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_document", objEntidad.user);
            comando.Parameters.AddWithValue("_password", objEntidad.password);
            DataTable tablaDatosUsuarios = new DataTable();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            adaptador.Fill(tablaDatosUsuarios);
            CerrarConexion();
            return tablaDatosUsuarios;
        }

    }
}

