using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysFactuApi.Domain.Models.ReportingModels
{
    public class Rol
    {
        [Key]
        public Guid IdRol { get; set; }
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
