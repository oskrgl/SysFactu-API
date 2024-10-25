using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysFactuApi.Domain.Models.Requests
{
    public class ValidarUsuario
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
