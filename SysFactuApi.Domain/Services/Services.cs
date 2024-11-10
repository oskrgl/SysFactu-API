using SysFactuApi.Domain.Interfaces;
using SysFactuApi.Domain.Models.ReportingModels;
using SysFactuApi.Domain.Models.Requests;

namespace SysFactuApi.Domain.Services
{
    public class Services
    {
        public readonly IReportingManager reportingService;
        private readonly GlobalVariables _globalVariables;
        public Services(IReportingManager reportingManager, GlobalVariables globalVariables) {
            reportingService = reportingManager;
            _globalVariables=globalVariables;
        }
        public async Task<Usuario> ValidarUsuario(ValidarUsuario user)
        {
            string DBConnection = _globalVariables.DBConnection;
            string SPname = _globalVariables.SPGetUsuario;
            return await reportingService.ValidarUsuario(DBConnection, SPname, user);
        }

        public async Task<Proveedor> AgregarProveedor(Proveedor data)
        {
            string DBConnection = _globalVariables.DBConnection;
            string SPname = _globalVariables.SPAgregarProveedor;
            return await reportingService.AgregarProveedor(DBConnection, SPname, data);
        }
        public async Task<IEnumerable<Proveedor>> getProveedores()
        {
            string DBConnection = _globalVariables.DBConnection;
            string SPname = _globalVariables.SPgetProveedores;
            return await reportingService.getProveedores(DBConnection, SPname);
        }
        public async Task<Proveedor> updateProveedor(Proveedor data)
        {
            string DBConnection = _globalVariables.DBConnection;
            string SPname = _globalVariables.SPupdateProveedor;
            return await reportingService.updateProveedor(DBConnection, SPname, data);
        }
        public async Task<Categoria> AgregarCategoria(Categoria data)
        {
            string DBConnection = _globalVariables.DBConnection;
            string SPname = _globalVariables.SPAgregarCategoria;
            return await reportingService.AgregarCategoria(DBConnection, SPname, data);
        }
        public async Task<IEnumerable<Categoria>> getCategorias()
        {
            string DBConnection = _globalVariables.DBConnection;
            string SPname = _globalVariables.SPgetCategoria;
            return await reportingService.getCategoria(DBConnection, SPname);
        }
        public async Task<Categoria> updateCategoria(Categoria data)
        {
            string DBConnection = _globalVariables.DBConnection;
            string SPname = _globalVariables.SPupdateCategoria;
            return await reportingService.updateCategoria(DBConnection, SPname, data);
        }
        public async Task<Sucursal> AgregarSucursal(Sucursal data)
        {
            string DBConnection = _globalVariables.DBConnection;
            string SPname = _globalVariables.SPAgregarSucursal;
            return await reportingService.AgregarSucursal(DBConnection, SPname, data);
        }
        public async Task<IEnumerable<Sucursal>> getSucursales()
        {
            string DBConnection = _globalVariables.DBConnection;
            string SPname = _globalVariables.SPgetSucursal;
            return await reportingService.getSucursal(DBConnection, SPname);
        }
        public async Task<Sucursal> updateSucursal(Sucursal data)
        {
            string DBConnection = _globalVariables.DBConnection;
            string SPname = _globalVariables.SPupdateSucursal;
            return await reportingService.updateSucursal(DBConnection, SPname, data);
        }
        public async Task<Producto> AgregarProducto(Producto data)
        {
            string DBConnection = _globalVariables.DBConnection;
            string SPname = _globalVariables.SPAgregarProducto;
            return await reportingService.AgregarProducto(DBConnection, SPname, data);
        }
        public async Task<IEnumerable<ProductoCategoria>> AgregarProductotoCategoria(IEnumerable<ProductoCategoria> data)
        {
            string DBConnection = _globalVariables.DBConnection;
            string SPname = _globalVariables.SPAgregarProductotoCategoria;
            return await reportingService.AgregarProductotoCategoria(DBConnection, SPname, data);
        }
    }
}
