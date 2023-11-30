using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegocioHabitaciones
    {

        CapaAccesoDatos.AccesoDatosHabitaciones objNegocio = new CapaAccesoDatos.AccesoDatosHabitaciones();
        public DataTable listarHabitaciones()
        {
            return objNegocio.ListarRooms();
        }

        public DataTable listarTiposHabitacion()
        {
            return objNegocio.ListarTiposHabitacion();
        }

        public DataTable listarEstados()
        {
            return objNegocio.ListarEstado();
        }

        public DataTable listarHotel()
        {
            return objNegocio.ListarHoteles();
        }

        public DataTable InsertarHabitacion(CapaEntidad.EntidadHabitacion objEntidad)
        {
            return objNegocio.InsertarHabitaciones(objEntidad);
        }
        public DataTable EditarHabitacion(CapaEntidad.EntidadHabitacion objEntidad)
        {
            return objNegocio.ActualizarHabitacion(objEntidad);
        }
        public DataTable EditarBelong(CapaEntidad.EntidadHabitacion objEntidad)
        {
            return objNegocio.ActualizarBelong(objEntidad);
        }

        public DataTable CrearUnion(CapaEntidad.EntidadHabitacion objEntidad)
        {
            return objNegocio.InsertarBelongs(objEntidad);
        }

        public readonly StringBuilder stringBuilder = new StringBuilder();
        public bool ValidarDatos(CapaEntidad.EntidadHabitacion objEntidad)
        {
            stringBuilder.Clear();
            if (string.IsNullOrEmpty(objEntidad.idRoom.ToString())) stringBuilder.Append("El campo id habitacion es requerido");
            if (string.IsNullOrEmpty(objEntidad.description)) stringBuilder.Append(" El campo descripcion es requerido");
            if (string.IsNullOrEmpty(objEntidad.price)) stringBuilder.Append("El campo precio es requerido");
            if (string.IsNullOrEmpty(objEntidad.idHotel.ToString())) stringBuilder.Append(" El campo precio es requerido");
            return stringBuilder.Length == 0;
        }
    }
}
