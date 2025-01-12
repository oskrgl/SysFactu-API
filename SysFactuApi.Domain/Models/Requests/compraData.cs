using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysFactuApi.Domain.Models.Requests
{

    public class Compra
    {
        public Guid IdProveedor { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdSucursal { get; set; }
        public string TipoComprobante { get; set; }
        public string SerieComprobante { get; set; }
        public string NumComprobante { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
        public List<Detalle> Detalles { get; set; }
    }

    public class Detalle
    {
        public Guid IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }

}
