using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysFactuApi.Domain.Models.ReportingModels
{
    public class ProductoCategoria
    {
        public Guid? IdProductoCategoria { get; set; }
        public Guid IdProducto { get; set; }
        public Guid IdCategoria { get; set; }
    }

}
