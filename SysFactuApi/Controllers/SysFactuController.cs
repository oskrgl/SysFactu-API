using Microsoft.AspNetCore.Mvc;
using SysFactuApi.Domain.Interfaces;
using SysFactuApi.Domain.Models.ReportingModels;
using SysFactuApi.Domain.Models.Requests;
using SysFactuApi.Domain.Models.Responses;
using SysFactuApi.Domain.Services;
using System.Threading.Tasks;

namespace SysFactuApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SysFactuController : ControllerBase
    {
        private readonly Services serviceDomain;
        private readonly GlobalVariables _globalVariables;

        public SysFactuController(IReportingManager reportingManager, GlobalVariables globalVariables)
        {
            serviceDomain = new Services(reportingManager, globalVariables);
            _globalVariables = globalVariables;
        }

        [HttpPost("ValidarUsuario")]
        public async Task<IActionResult> ValidarUsuario([FromBody] ValidarUsuario model)
        {
            var usuario = await serviceDomain.ValidarUsuario(model);
            Result<Usuario> result = new Result<Usuario>();
            if (usuario != null)
            {
                result.IsSuccess = true;
                result.ReturnMessage = "Usuario encontrado";
                result.Data = usuario;
                return Ok(result);
            }
            else
            {
                result.IsSuccess = false;
                result.ReturnMessage = "Usuario no encontrado";
                return BadRequest(result);
            }
        }

        [HttpPost("AgregarProveedor")]
        public async Task<IActionResult> AgregarProveedor([FromBody] Proveedor model)
        {
            var dataResult = new Proveedor();
            try
            {
                dataResult = await serviceDomain.AgregarProveedor(model);
            }
            catch (Exception ex)
            {
                Result<Exception> resultex = new Result<Exception>();
                resultex.IsSuccess = true;
                resultex.ReturnMessage = ex.Message;
                resultex.Data = ex;
                return Ok(resultex);
            }
            Result<Proveedor> result = new Result<Proveedor>();
            if (dataResult != null)
            {
                result.IsSuccess = true;
                result.ReturnMessage = "Proveedor registrado";
                result.Data = dataResult;
                return Ok(result);
            }
            else
            {
                result.IsSuccess = false;
                result.ReturnMessage = "Proveedor no registrado";
                return BadRequest(result);
            }
        }
    }
}
