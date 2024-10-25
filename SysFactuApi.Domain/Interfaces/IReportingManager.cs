using SysFactuApi.Domain.Models.ReportingModels;
using SysFactuApi.Domain.Models.Requests;

namespace SysFactuApi.Domain.Interfaces
{
    public interface IReportingManager
    {
        Task<IEnumerable<Usuario>> GetStatesUsuario(string DBConnection, string SPname);
        Task<Usuario> ValidarUsuario(string DBConnection, string SPname, ValidarUsuario user);
        Task<Proveedor> AgregarProveedor(string DBConnection, string SPname, Proveedor user);
    }
}
