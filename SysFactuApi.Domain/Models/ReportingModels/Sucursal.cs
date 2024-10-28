using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysFactuApi.Domain.Models.ReportingModels
{
    public class Sucursal
    {
        public Guid IdSucursal { get; set; }
        public string Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public Sucursal()
        {
            // Si el IdProveedor no está definido, se genera un nuevo GUID
            IdSucursal = IdSucursal == Guid.Empty ? Guid.NewGuid() : IdSucursal;
        }
    }
}
