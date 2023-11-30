using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegocioImpuestos
    {
        CapaAccesoDatos.AccesoDatosImpuesto objAcceso = new CapaAccesoDatos.AccesoDatosImpuesto();

        public DataTable listarHabitaciones()
        {
            return objAcceso.ListarRooms();
        }

        public DataTable listarTipoImpuesto()
        {
            return objAcceso.ListarTipoImpuesto();
        }
        public DataTable listarTaxes()
        {
            return objAcceso.ListarTaxes();
        }
        public DataTable InsertarImouesto(CapaEntidad.EntidadImpuesto objEntidad)
        {
            return objAcceso.insertarImpuesto(objEntidad);
        }
        public DataTable EliminarImouesto(CapaEntidad.EntidadImpuesto objEntidad)
        {
            return objAcceso.EliminarTaxes(objEntidad);
        }
        public DataTable ValidarImouesto(CapaEntidad.EntidadImpuesto objEntidad)
        {
            return objAcceso.ValidarTaxesType(objEntidad);
        }
        public readonly StringBuilder stringBuilder = new StringBuilder();
        public bool ValidarDatos(CapaEntidad.EntidadImpuesto objEntidad)
        {
            stringBuilder.Clear();
            if (string.IsNullOrEmpty(objEntidad.idImpuesto.ToString())) stringBuilder.Append("El campo ID IMPUESTO es requerido");
            return stringBuilder.Length == 0;
        }
    }
}
