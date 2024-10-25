using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysFactuApi.Domain.Models.Responses
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public string ReturnMessage { get; set; }
        public T Data { get; set; }
    }
}
