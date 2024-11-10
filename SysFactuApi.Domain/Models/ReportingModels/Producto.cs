using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysFactuApi.Domain.Models.ReportingModels

{
    public class Producto
    {
        public Guid IdProducto { get; set; }
        public string? Codigo { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal PrecioVenta { get; set; }
        public decimal Costo { get; set; }
        public decimal Ganancia { get; set; }
        public int Stock { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string? Imagen { get; set; }
        public bool Estado { get; set; } = true;
        public Producto()
        {
            IdProducto = IdProducto == Guid.Empty ? Guid.NewGuid() : IdProducto;
        }
    }
}
