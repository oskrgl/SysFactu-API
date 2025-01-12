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
            try
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
            catch (Exception ex)
            {
                Result<dynamic> resultex = new Result<dynamic>();
                resultex.IsSuccess = false;
                resultex.ReturnMessage = ex.Message;
                return Ok(resultex);
            }
        }

        [HttpPost("AgregarProveedor")]
        public async Task<IActionResult> AgregarProveedor([FromBody] Proveedor model)
        {
            try
            {
                var dataResult = await serviceDomain.AgregarProveedor(model);
            
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
            catch (Exception ex)
            {
                Result<dynamic> resultex = new Result<dynamic>();
                resultex.IsSuccess = false;
                resultex.ReturnMessage = ex.Message;
                return Ok(resultex);
            }
        }

        [HttpPost("getProveedores")]
        public async Task<IActionResult> getProveedores()
        {
            try
            {
                IEnumerable<Proveedor> dataResult = await serviceDomain.getProveedores();
                Result<IEnumerable<Proveedor>> result = new Result<IEnumerable<Proveedor>>();
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
            catch (Exception ex)
            {
                Result<dynamic> resultex = new Result<dynamic>();
                resultex.IsSuccess = false;
                resultex.ReturnMessage = ex.Message;
                return Ok(resultex);
            }
        }

        [HttpPost("updateProveedor")]
        public async Task<IActionResult> updateProveedor([FromBody] Proveedor model)
        {
            try
            {
                var dataResult = await serviceDomain.updateProveedor(model);
                Result<Proveedor> result = new Result<Proveedor>();
                if (dataResult != null)
                {
                    result.IsSuccess = true;
                    result.ReturnMessage = "Proveedor modificado";
                    result.Data = dataResult;
                    return Ok(result);
                }
                else
                {
                    result.IsSuccess = false;
                    result.ReturnMessage = "Proveedor no modificado";
                    return BadRequest(result);
                }
            }

            catch (Exception ex)
            {
                Result<dynamic> resultex = new Result<dynamic>();
                resultex.IsSuccess = false;
                resultex.ReturnMessage = ex.Message;
                return Ok(resultex);
            }
        }
        [HttpPost("AgregarCategoria")]
        public async Task<IActionResult> AgregarCategoria([FromBody] Categoria model)
        {
            try
            {
                var dataResult = await serviceDomain.AgregarCategoria(model);
                Result<Categoria> result = new Result<Categoria>();
                if (dataResult != null)
                {
                    result.IsSuccess = true;
                    result.ReturnMessage = "Categoría registrada";
                    result.Data = dataResult;
                    return Ok(result);
                }
                else
                {
                    result.IsSuccess = false;
                    result.ReturnMessage = "Categoría no registrada";
                    return BadRequest(result);
                }
            }

            catch (Exception ex)
            {
                Result<dynamic> resultex = new Result<dynamic>();
                resultex.IsSuccess = false;
                resultex.ReturnMessage = ex.Message;
                return Ok(resultex);
            }
        }
        [HttpPost("getCategorias")]
        public async Task<IActionResult> getCategorias()
        {
            try
            {
                IEnumerable<Categoria> dataResult = await serviceDomain.getCategorias();
                Result<IEnumerable<Categoria>> result = new Result<IEnumerable<Categoria>>();
                if (dataResult != null)
                {
                    result.IsSuccess = true;
                    result.ReturnMessage = "Categoría encontrada";
                    result.Data = dataResult;
                    return Ok(result);
                }
                else
                {
                    result.IsSuccess = false;
                    result.ReturnMessage = "Categoría no encontrada";
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                Result<dynamic> resultex = new Result<dynamic>();
                resultex.IsSuccess = false;
                resultex.ReturnMessage = ex.Message;
                return Ok(resultex);
            }
        }

        [HttpPost("updateCategoria")]
        public async Task<IActionResult> updateCategoria([FromBody] Categoria model)
        {
            try
            {
                var dataResult = await serviceDomain.updateCategoria(model);
                Result<Categoria> result = new Result<Categoria>();
                if (dataResult != null)
                {
                    result.IsSuccess = true;
                    result.ReturnMessage = "Categoría modificada";
                    result.Data = dataResult;
                    return Ok(result);
                }
                else
                {
                    result.IsSuccess = false;
                    result.ReturnMessage = "Categoría no modificada";
                    return BadRequest(result);
                }
            }

            catch (Exception ex)
            {
                Result<dynamic> resultex = new Result<dynamic>();
                resultex.IsSuccess = false;
                resultex.ReturnMessage = ex.Message;
                return Ok(resultex);
            }
        }
        [HttpPost("AgregarSucursal")]
        public async Task<IActionResult> AgregarSucursal([FromBody] Sucursal model)
        {
            try
            {
                var dataResult = await serviceDomain.AgregarSucursal(model);
                Result<Sucursal> result = new Result<Sucursal>();
                if (dataResult != null)
                {
                    result.IsSuccess = true;
                    result.ReturnMessage = "Sucursal registrada";
                    result.Data = dataResult;
                    return Ok(result);
                }
                else
                {
                    result.IsSuccess = false;
                    result.ReturnMessage = "Sucursal no registrada";
                    return BadRequest(result);
                }
            }

            catch (Exception ex)
            {
                Result<dynamic> resultex = new Result<dynamic>();
                resultex.IsSuccess = false;
                resultex.ReturnMessage = ex.Message;
                return Ok(resultex);
            }
        }
        [HttpPost("getSucursales")]
        public async Task<IActionResult> getSucursales()
        {
            try
            {
                IEnumerable<Sucursal> dataResult = await serviceDomain.getSucursales();
                Result<IEnumerable<Sucursal>> result = new Result<IEnumerable<Sucursal>>();
                if (dataResult != null)
                {
                    result.IsSuccess = true;
                    result.ReturnMessage = "Sucursal encontrada";
                    result.Data = dataResult;
                    return Ok(result);
                }
                else
                {
                    result.IsSuccess = false;
                    result.ReturnMessage = "Sucursal no encontrada";
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                Result<dynamic> resultex = new Result<dynamic>();
                resultex.IsSuccess = false;
                resultex.ReturnMessage = ex.Message;
                return Ok(resultex);
            }
        }

        [HttpPost("updateSucursal")]
        public async Task<IActionResult> updateSucursal([FromBody] Sucursal model)
        {
            try
            {
                var dataResult = await serviceDomain.updateSucursal(model);
                Result<Sucursal> result = new Result<Sucursal>();
                if (dataResult != null)
                {
                    result.IsSuccess = true;
                    result.ReturnMessage = "Sucursal modificada";
                    result.Data = dataResult;
                    return Ok(result);
                }
                else
                {
                    result.IsSuccess = false;
                    result.ReturnMessage = "Sucursal no modificada";
                    return BadRequest(result);
                }
            }

            catch (Exception ex)
            {
                Result<dynamic> resultex = new Result<dynamic>();
                resultex.IsSuccess = false;
                resultex.ReturnMessage = ex.Message;
                return Ok(resultex);
            }
        }
        [HttpPost("AgregarProducto")]
        public async Task<IActionResult> AgregarProducto([FromBody] Producto model)
        {
            try
            {
                var dataResult = await serviceDomain.AgregarProducto(model);
                Result<Producto> result = new Result<Producto>();
                if (dataResult != null)
                {
                    result.IsSuccess = true;
                    result.ReturnMessage = "Producto registrado";
                    result.Data = dataResult;
                    return Ok(result);
                }
                else
                {
                    result.IsSuccess = false;
                    result.ReturnMessage = "Producto no registrado";
                    return BadRequest(result);
                }
            }

            catch (Exception ex)
            {
                Result<dynamic> resultex = new Result<dynamic>();
                resultex.IsSuccess = false;
                resultex.ReturnMessage = ex.Message;
                return Ok(resultex);
            }
        }
        [HttpPost("AgregarProductotoCategoria")]
        public async Task<IActionResult> AgregarProductotoCategoria([FromBody] IEnumerable<ProductoCategoria> model)
        {
            try
            {
                var dataResult = await serviceDomain.AgregarProductotoCategoria(model);
                Result<IEnumerable<ProductoCategoria>> result = new Result<IEnumerable<ProductoCategoria>>();
                if (dataResult != null)
                {
                    result.IsSuccess = true;
                    result.ReturnMessage = "Producto registrado";
                    result.Data = dataResult;
                    return Ok(result);
                }
                else
                {
                    result.IsSuccess = false;
                    result.ReturnMessage = "Producto no registrado";
                    return BadRequest(result);
                }
            }

            catch (Exception ex)
            {
                Result<dynamic> resultex = new Result<dynamic>();
                resultex.IsSuccess = false;
                resultex.ReturnMessage = ex.Message;
                return Ok(resultex);
            }
        }
        [HttpPost("getProductos")]
        public async Task<IActionResult> getProductos()
        {
            try
            {
                IEnumerable<Producto> dataResult = await serviceDomain.getProductos();
                Result<IEnumerable<Producto>> result = new Result<IEnumerable<Producto>>();
                if (dataResult != null)
                {
                    result.IsSuccess = true;
                    result.ReturnMessage = "Sucursal encontrada";
                    result.Data = dataResult;
                    return Ok(result);
                }
                else
                {
                    result.IsSuccess = false;
                    result.ReturnMessage = "Sucursal no encontrada";
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                Result<dynamic> resultex = new Result<dynamic>();
                resultex.IsSuccess = false;
                resultex.ReturnMessage = ex.Message;
                return Ok(resultex);
            }
        }
        [HttpPost("AgregarCompra")]
        public async Task<IActionResult> AgregarCompra([FromBody] Compra model)
        {
            try
            {
                var usuario = await serviceDomain.AgregarCompra(model);
                Result<dynamic> result = new Result<dynamic>();
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
            catch (Exception ex)
            {
                Result<dynamic> resultex = new Result<dynamic>();
                resultex.IsSuccess = false;
                resultex.ReturnMessage = ex.Message;
                return Ok(resultex);
            }
        }
    }
}
