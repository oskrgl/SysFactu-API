using SysFactuApi.Domain.Models.ReportingModels;
using SysFactuApi.Domain.Models.Requests;

namespace SysFactuApi.Domain.Interfaces
{
    public interface IReportingManager
    {
        Task<IEnumerable<Usuario>> GetStatesUsuario(string DBConnection, string SPname);
        Task<Usuario> ValidarUsuario(string DBConnection, string SPname, ValidarUsuario data);
        Task<Proveedor> AgregarProveedor(string DBConnection, string SPname, Proveedor data);
        Task<IEnumerable<Proveedor>> getProveedores(string DBConnection, string SPname);
        Task<Proveedor> updateProveedor(string DBConnection, string SPname, Proveedor data);
        Task<Categoria> AgregarCategoria(string DBConnection, string SPname, Categoria data);
        Task<IEnumerable<Categoria>> getCategoria(string DBConnection, string SPname);
        Task<Categoria> updateCategoria(string DBConnection, string SPname, Categoria data);
        Task<Sucursal> AgregarSucursal(string DBConnection, string SPname, Sucursal data);
        Task<IEnumerable<Sucursal>> getSucursal(string DBConnection, string SPname);
        Task<Sucursal> updateSucursal(string DBConnection, string SPname, Sucursal data);
    }
}
