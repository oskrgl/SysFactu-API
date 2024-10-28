using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysFactuApi.Domain.Models.ReportingModels
{
    public class Categoria
    {
        public Guid idCategoria { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public Categoria()
        {
            // Si el IdProveedor no está definido, se genera un nuevo GUID
            idCategoria = idCategoria == Guid.Empty ? Guid.NewGuid() : idCategoria;
        }
    }
}
