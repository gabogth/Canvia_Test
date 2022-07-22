using PT_CANVIA.Core.Entidades.Ventas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_CANVIA.Infraestructura.Repositorios
{
    public class ProductoRepositorio : Base.Repositorio, Core.Repositorios.IProductoRepositorio
    {
        public async Task EliminarAsync(int nProducto_Id)
        {
            using (Base.Repositorio oRepository = new Base.Repositorio())
            {
                object[] lsParametros = new object[] {
                    new SqlParameter("@nProducto_Id", nProducto_Id)
                };
                await oRepository.Database.ExecuteSqlCommandAsync("dbo.prc_Producto_Eliminar" + oRepository.GetListaParemetros(lsParametros), lsParametros);
            }
        }

        public async Task<IReadOnlyList<Producto>> GetDatosAsync(int? nProducto_Id, string cQuery)
        {
            IReadOnlyList<Producto> lsRespuesta = new List<Producto>();
            using (Base.Repositorio oRepository = new Base.Repositorio())
            {
                object[] lsParametros = new object[] {
                    new SqlParameter("@nProducto_Id", nProducto_Id ?? SqlInt32.Null),
                    new SqlParameter("@cQuery", cQuery ?? SqlString.Null)
                };
                lsRespuesta = await oRepository.Database.SqlQuery<Producto>("dbo.prc_Producto_Datos" + oRepository.GetListaParemetros(lsParametros), lsParametros).ToListAsync();
            }
            return lsRespuesta;
        }

        public async Task<Producto> GetPorIdAsync(int nProducto_Id)
        {
            Producto oRespuesta = new Producto();
            using (Base.Repositorio oRepository = new Base.Repositorio())
            {
                object[] lsParametros = new object[] {
                    new SqlParameter("@nProducto_Id", nProducto_Id),
                    new SqlParameter("@cQuery", SqlString.Null)
                };
                oRespuesta = await oRepository.Database.SqlQuery<Producto>("dbo.prc_Producto_Datos" + oRepository.GetListaParemetros(lsParametros), lsParametros).FirstOrDefaultAsync();
            }
            return oRespuesta;
        }

        public async Task<Producto> GrabarAsync(Producto oEntity)
        {
            using (Base.Repositorio oRepository = new Base.Repositorio())
            {
                object[] lsParametros = new object[] {
                    new SqlParameter("@nProducto_Id", oEntity.nProducto_Id){ Direction = System.Data.ParameterDirection.InputOutput },
                    new SqlParameter("@cNombre", oEntity.cNombre),
                    new SqlParameter("@cNombreCorto", oEntity.cNombreCorto),
                    new SqlParameter("@cUnidadCompra", oEntity.cUnidadCompra),
                    new SqlParameter("@cUnidadVenta", oEntity.cUnidadVenta),
                    new SqlParameter("@nConversion", oEntity.nConversion),
                };
                await oRepository.Database.ExecuteSqlCommandAsync("dbo.prc_Producto_Grabar" + oRepository.GetListaParemetros(lsParametros), lsParametros);
                return await GetPorIdAsync((int)((SqlParameter)lsParametros[0]).Value);
            }
        }
    }
}
