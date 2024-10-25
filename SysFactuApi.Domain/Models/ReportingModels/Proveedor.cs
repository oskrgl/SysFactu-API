using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysFactuApi.Domain.Models.ReportingModels
{
    public class Proveedor
    {
        public Guid IdProveedor { get; set; }
        public string  Nombre { get; set; }
        public string? NombreContacto { get; set; }
        public string? TelefonoFijo { get; set; }
        public string? TelefonoCelular { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public string Estado { get; set; } 
        public DateTime FechaRegistro { get; set; }
        public Proveedor()
        {
            // Si el IdProveedor no está definido, se genera un nuevo GUID
            IdProveedor = IdProveedor == Guid.Empty ? Guid.NewGuid() : IdProveedor;
        }
    }

}
