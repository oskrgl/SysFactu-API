using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysFactuApi.Domain.Models.ReportingModels
{
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; }
        public required Guid IdRol { get; set; }
        public required string Nombre { get; set; }
        public string? TipoDocumento { get; set; }
        public string? NumDocumento { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Rol { get; set; }
        public bool Estado { get; set; }
    }
}
