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
    public class AlmacenRepositorio : Base.Repositorio, Core.Repositorios.IAlmacenRepositorio
    {
        public async Task<Almacen> GetPorIdAsync(int nAlmacen_Id)
        {
            Almacen oRespuesta = new Almacen();
            using (Base.Repositorio oRepository = new Base.Repositorio())
            {
                object[] lsParametros = new object[] {
                    new SqlParameter("@nAlmacen_Id", nAlmacen_Id),
                    new SqlParameter("@cQuery", SqlString.Null)
                };
                oRespuesta = await oRepository.Database.SqlQuery<Almacen>("dbo.prc_Almacen_Datos" + oRepository.GetListaParemetros(lsParametros), lsParametros).FirstOrDefaultAsync();
            }
            return oRespuesta;
        }

        public async Task<IReadOnlyList<Almacen>> GetDatosAsync(int? nAlmacen_Id, string cQuery)
        {
            IReadOnlyList<Almacen> lsRespuesta = new List<Almacen>();
            using (Base.Repositorio oRepository = new Base.Repositorio())
            {
                object[] lsParametros = new object[] {
                    new SqlParameter("@nAlmacen_Id", nAlmacen_Id ?? SqlInt32.Null),
                    new SqlParameter("@cQuery", cQuery ?? SqlString.Null)
                };
                lsRespuesta = await oRepository.Database.SqlQuery<Almacen>("dbo.prc_Almacen_Datos" + oRepository.GetListaParemetros(lsParametros), lsParametros).ToListAsync();
            }
            return lsRespuesta;
        }

        public async Task<Almacen> GrabarAsync(Almacen oEntity)
        {
            using (Base.Repositorio oRepository = new Base.Repositorio())
            {
                object[] lsParametros = new object[] {
                    new SqlParameter("@nAlmacen_Id", oEntity.nAlmacen_Id){ Direction = System.Data.ParameterDirection.InputOutput },
                    new SqlParameter("@cNombre", oEntity.cNombre),
                    new SqlParameter("@cNombreCorto", oEntity.cNombreCorto),
                };
                await oRepository.Database.ExecuteSqlCommandAsync("dbo.prc_Almacen_Grabar" + oRepository.GetListaParemetros(lsParametros), lsParametros);
                return await GetPorIdAsync((int)((SqlParameter)lsParametros[0]).Value);
            }
        }

        public async Task EliminarAsync(int nAlmacen_Id)
        {
            using (Base.Repositorio oRepository = new Base.Repositorio())
            {
                object[] lsParametros = new object[] {
                    new SqlParameter("@nAlmacen_Id", nAlmacen_Id)
                };
                await oRepository.Database.ExecuteSqlCommandAsync("dbo.prc_Almacen_Eliminar" + oRepository.GetListaParemetros(lsParametros), lsParametros);
            }
        }
    }
}
