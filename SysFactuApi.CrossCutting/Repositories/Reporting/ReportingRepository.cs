using Newtonsoft.Json;
using SysFactuApi.Domain.Interfaces;
using SysFactuApi.Domain.Models.ReportingModels;
using SysFactuApi.Domain.Models.Requests;
using System.Numerics;

namespace SysFactuApi.CrossCutting.Repositories.Reporting
{
    public class ReportingRepository : GenericRepository, IReportingManager
    {
        public async Task<IEnumerable<Usuario>> GetStatesUsuario(string DBConnection, string SPname)
        {
            var routeType = await GetAsyncFirstDynamic<Usuario>(DBConnection, SPname, null, System.Data.CommandType.StoredProcedure);
            return routeType;
        }
        public async Task<Usuario> ValidarUsuario(string DBConnection, string SPname, ValidarUsuario ticketSearchData)
        {
            var userDb = await GetAsync<ValidarUsuario, Usuario>(DBConnection, SPname, ticketSearchData, System.Data.CommandType.StoredProcedure);
            return userDb?.FirstOrDefault();
        }

        public async Task<Proveedor> AgregarProveedor(string DBConnection, string SPname, Proveedor objetData)
        {
            var userDb = await GetAsyncFirstDynamic<Proveedor>(DBConnection, SPname, objetData, System.Data.CommandType.StoredProcedure);
            return userDb?.FirstOrDefault();
        }
        public async Task<IEnumerable<Proveedor>> getProveedores(string DBConnection, string SPname)
        {
            var userDb = await GetAsyncFirstDynamic<Proveedor>(DBConnection, SPname, null, System.Data.CommandType.StoredProcedure);
            return userDb;
        }
        public async Task<Proveedor> updateProveedor(string DBConnection, string SPname, Proveedor objetData)
        {
            var userDb = await GetAsyncFirstDynamic<Proveedor>(DBConnection, SPname, objetData, System.Data.CommandType.StoredProcedure);
            return userDb?.FirstOrDefault();
        }
        public async Task<Categoria> AgregarCategoria(string DBConnection, string SPname, Categoria objetData)
        {
            var userDb = await GetAsyncFirstDynamic<Categoria>(DBConnection, SPname, objetData, System.Data.CommandType.StoredProcedure);
            return userDb?.FirstOrDefault();
        }
        public async Task<IEnumerable<Categoria>> getCategoria(string DBConnection, string SPname)
        {
            var userDb = await GetAsyncFirstDynamic<Categoria>(DBConnection, SPname, null, System.Data.CommandType.StoredProcedure);
            return userDb;
        }
        public async Task<Categoria> updateCategoria(string DBConnection, string SPname, Categoria objetData)
        {
            var userDb = await GetAsyncFirstDynamic<Categoria>(DBConnection, SPname, objetData, System.Data.CommandType.StoredProcedure);
            return userDb?.FirstOrDefault();
        }
        public async Task<Sucursal> AgregarSucursal(string DBConnection, string SPname, Sucursal objetData)
        {
            var userDb = await GetAsyncFirstDynamic<Sucursal>(DBConnection, SPname, objetData, System.Data.CommandType.StoredProcedure);
            return userDb?.FirstOrDefault();
        } 
        public async Task<IEnumerable<Sucursal>> getSucursal(string DBConnection, string SPname)
        {
            var userDb = await GetAsyncFirstDynamic<Sucursal>(DBConnection, SPname, null, System.Data.CommandType.StoredProcedure);
            return userDb;
        }
        public async Task<Sucursal> updateSucursal(string DBConnection, string SPname, Sucursal objetData)
        {
            var userDb = await GetAsyncFirstDynamic<Sucursal>(DBConnection, SPname, objetData, System.Data.CommandType.StoredProcedure);
            return userDb?.FirstOrDefault();
        }
        public async Task<Producto> AgregarProducto(string DBConnection, string SPname, Producto objetData)
        {
            var userDb = await GetAsyncFirstDynamic<Producto>(DBConnection, SPname, objetData, System.Data.CommandType.StoredProcedure);
            return userDb?.FirstOrDefault();
        }
        public async Task<IEnumerable<ProductoCategoria>> AgregarProductotoCategoria(string DBConnection, string SPname, IEnumerable<ProductoCategoria> categorias)
        {
            var productoCategoriaData = new
            {
                idproducto = categorias.FirstOrDefault().IdProducto,
                json = JsonConvert.SerializeObject(categorias.Select(categoria => new { idcategoria = categoria.IdCategoria }))
            };

            var userDb = await GetAsyncFirstDynamic<ProductoCategoria>(DBConnection, SPname, productoCategoriaData, System.Data.CommandType.StoredProcedure);
            return userDb;
        }

    }
}
