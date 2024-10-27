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

        public async Task<Proveedor> AgregarProveedor(Proveedor dara)
        {
            string DBConnection = _globalVariables.DBConnection;
            string SPname = _globalVariables.SPAgregarProveedor;
            return await reportingService.AgregarProveedor(DBConnection, SPname, dara);
        }
        public async Task<IEnumerable<Proveedor>> getProveedores()
        {
            string DBConnection = _globalVariables.DBConnection;
            string SPname = _globalVariables.SPgetProveedores;
            return await reportingService.getProveedores(DBConnection, SPname);
        }
        public async Task<Proveedor> updateProveedor(Proveedor dara)
        {
            string DBConnection = _globalVariables.DBConnection;
            string SPname = _globalVariables.SPupdateProveedor;
            return await reportingService.updateProveedor(DBConnection, SPname, dara);
        }
    }
}
