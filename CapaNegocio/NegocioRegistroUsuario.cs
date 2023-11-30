using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegocioRegistroUsuario
    {
        CapaAccesoDatos.AccesoDatosIngresoUsuario objAccesoDatos = new CapaAccesoDatos.AccesoDatosIngresoUsuario();
        public DataTable ValidarRegistroUsuario(CapaEntidad.EntidadRegistroUsuario objEntidad)
        {
            return objAccesoDatos.validarUsuario(objEntidad);
        }
        public DataTable DatosUsuario(CapaEntidad.EntidadRegistroUsuario objEntidad)
        {
            return objAccesoDatos.registrarUsuario(objEntidad);
        }

        public object obtenerIdAsesor(CapaEntidad.EntidadRegistroUsuario objEntidad)
        {
            return objAccesoDatos.obtenerIdAsesor(objEntidad);
        }

        public DataTable IngresoUsuario(CapaEntidad.EntidadRegistroUsuario objEntidad)
        {
            return objAccesoDatos.ingresoUsuario(objEntidad);
        }

        public readonly StringBuilder stringBuilder = new StringBuilder();
        public bool ValidarDatosUsuario(CapaEntidad.EntidadRegistroUsuario objEntidad)
        {
            stringBuilder.Clear();
            if (string.IsNullOrEmpty(objEntidad.name)) stringBuilder.Append("El campo Nombre es requerido");
            if (string.IsNullOrEmpty(objEntidad.lastName)) stringBuilder.Append(" El campo Apellido es requerido");
            if (string.IsNullOrEmpty(objEntidad.user)) stringBuilder.Append("El campo Cedula es requerido");
            if (string.IsNullOrEmpty(objEntidad.password)) stringBuilder.Append(" El campo Contraseña es requerido");
            if (string.IsNullOrEmpty(objEntidad.VerifyPassword)) stringBuilder.Append(" El campo Verifica Contraseña es requerido");
            return stringBuilder.Length == 0;
        }

        public bool ValidarIngresoUsuario(CapaEntidad.EntidadRegistroUsuario objEntidad)
        {
            stringBuilder.Clear();
           
            if (string.IsNullOrEmpty(objEntidad.user)) stringBuilder.Append("El campo Cedula es requerido");
            if (string.IsNullOrEmpty(objEntidad.password)) stringBuilder.Append(" El campo Contraseña es requerido");
            return stringBuilder.Length == 0;
        }
    }
}
