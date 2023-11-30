using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegocioHoteles
    {

        CapaAccesoDatos.AccesoDatosHoteles objHoteles = new CapaAccesoDatos.AccesoDatosHoteles();

        public DataTable listarHoteles()
        {
            return objHoteles.visualizarEquipos();
        }

        public DataTable ActualizarHotel(CapaEntidad.EntidadHotel objEntidad)
        {
            return objHoteles.actualizarHotel(objEntidad);
        }

        public DataTable InsertarHotel(CapaEntidad.EntidadHotel entidadHotel)
        {
            return objHoteles.InsertarHotel(entidadHotel);
        }
        public DataTable listarEstado()
        {
            return objHoteles.ListarEstado();
        }

        public readonly StringBuilder stringBuilder = new StringBuilder();
        public bool ValidarDatos(CapaEntidad.EntidadHotel objEntidad)
        {
            stringBuilder.Clear();
            if (string.IsNullOrEmpty(objEntidad.description)) stringBuilder.Append("El campo Descripcion es requerido");
            if (string.IsNullOrEmpty(objEntidad.nameHotel)) stringBuilder.Append("El campo Nombre es requerido");
            if (string.IsNullOrEmpty(objEntidad.price)) stringBuilder.Append(" El campo precio es requerido");
            return stringBuilder.Length == 0;
        }
    }
}
