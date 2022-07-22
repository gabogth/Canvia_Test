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
    public class TipoDocumentoRepositorio : Base.Repositorio, Core.Repositorios.ITipoDocumento
    {
        public async Task EliminarAsync(int nTipoDocumento_Id)
        {
            using (Base.Repositorio oRepository = new Base.Repositorio())
            {
                object[] lsParametros = new object[] {
                    new SqlParameter("@nTipoDocumento_Id", nTipoDocumento_Id)
                };
                await oRepository.Database.ExecuteSqlCommandAsync("dbo.prc_TipoDocumento_Eliminar" + oRepository.GetListaParemetros(lsParametros), lsParametros);
            }
        }

        public async Task<IReadOnlyList<TipoDocumento>> GetDatosAsync(int? nTipoDocumento_Id, string cQuery)
        {
            IReadOnlyList<TipoDocumento> lsRespuesta = new List<TipoDocumento>();
            using (Base.Repositorio oRepository = new Base.Repositorio())
            {
                object[] lsParametros = new object[] {
                    new SqlParameter("@nTipoDocumento_Id", nTipoDocumento_Id ?? SqlInt32.Null),
                    new SqlParameter("@cQuery", cQuery ?? SqlString.Null)
                };
                lsRespuesta = await oRepository.Database.SqlQuery<TipoDocumento>("dbo.prc_TipoDocumento_Datos" + oRepository.GetListaParemetros(lsParametros), lsParametros).ToListAsync();
            }
            return lsRespuesta;
        }

        public async Task<TipoDocumento> GetPorIdAsync(int nTipoDocumento_Id)
        {
            TipoDocumento oRespuesta = new TipoDocumento();
            using (Base.Repositorio oRepository = new Base.Repositorio())
            {
                object[] lsParametros = new object[] {
                    new SqlParameter("@nTipoDocumento_Id", nTipoDocumento_Id),
                    new SqlParameter("@cQuery", SqlString.Null)
                };
                oRespuesta = await oRepository.Database.SqlQuery<TipoDocumento>("dbo.prc_TipoDocumento_Datos" + oRepository.GetListaParemetros(lsParametros), lsParametros).FirstOrDefaultAsync();
            }
            return oRespuesta;
        }

        public async Task<TipoDocumento> GrabarAsync(TipoDocumento oEntity)
        {
            using (Base.Repositorio oRepository = new Base.Repositorio())
            {
                object[] lsParametros = new object[] {
                    new SqlParameter("@nTipoDocumento_Id", oEntity.nTipoDocumento_Id){ Direction = System.Data.ParameterDirection.InputOutput },
                    new SqlParameter("@cNombre", oEntity.cNombre),
                };
                await oRepository.Database.ExecuteSqlCommandAsync("dbo.prc_TipoDocumento_Grabar" + oRepository.GetListaParemetros(lsParametros), lsParametros);
                return await GetPorIdAsync((int)((SqlParameter)lsParametros[0]).Value);
            }
        }
    }
}
