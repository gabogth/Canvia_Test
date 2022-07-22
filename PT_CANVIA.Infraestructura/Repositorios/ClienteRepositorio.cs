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
    public class ClienteRepositorio : Base.Repositorio, Core.Repositorios.IClienteRepositorio
    {
        public async Task EliminarAsync(int nCliente_Id)
        {
            using (Base.Repositorio oRepository = new Base.Repositorio())
            {
                object[] lsParametros = new object[] {
                    new SqlParameter("@nCliente_Id", nCliente_Id)
                };
                await oRepository.Database.ExecuteSqlCommandAsync("dbo.prc_Cliente_Eliminar" + oRepository.GetListaParemetros(lsParametros), lsParametros);
            }
        }

        public async Task<IReadOnlyList<Cliente>> GetDatosAsync(int? nCliente_Id, string cQuery)
        {
            IReadOnlyList<Cliente> lsRespuesta = new List<Cliente>();
            using (Base.Repositorio oRepository = new Base.Repositorio())
            {
                object[] lsParametros = new object[] {
                    new SqlParameter("@nCliente_Id", nCliente_Id ?? SqlInt32.Null),
                    new SqlParameter("@cQuery", cQuery ?? SqlString.Null)
                };
                lsRespuesta = await oRepository.Database.SqlQuery<Cliente>("dbo.prc_Cliente_Datos" + oRepository.GetListaParemetros(lsParametros), lsParametros).ToListAsync();
            }
            return lsRespuesta;
        }

        public async Task<Cliente> GetPorIdAsync(int nCliente_Id)
        {
            Cliente oRespuesta = new Cliente();
            using (Base.Repositorio oRepository = new Base.Repositorio())
            {
                object[] lsParametros = new object[] {
                    new SqlParameter("@nCliente_Id", nCliente_Id),
                    new SqlParameter("@cQuery", SqlString.Null)
                };
                oRespuesta = await oRepository.Database.SqlQuery<Cliente>("dbo.prc_Cliente_Datos" + oRepository.GetListaParemetros(lsParametros), lsParametros).FirstOrDefaultAsync();
            }
            return oRespuesta;
        }

        public async Task<Cliente> GrabarAsync(Cliente oEntity)
        {
            using (Base.Repositorio oRepository = new Base.Repositorio())
            {
                object[] lsParametros = new object[] {
                    new SqlParameter("@nCliente_Id", oEntity.nCliente_Id){ Direction = System.Data.ParameterDirection.InputOutput },
                    new SqlParameter("@cTipoDocIdentidad", oEntity.cTipoDocIdentidad),
                    new SqlParameter("@cDocIdentidad", oEntity.cDocIdentidad),
                    new SqlParameter("@cDescripcion", oEntity.cDescripcion),
                };
                await oRepository.Database.ExecuteSqlCommandAsync("dbo.prc_Cliente_Grabar" + oRepository.GetListaParemetros(lsParametros), lsParametros);
                return await GetPorIdAsync((int)((SqlParameter)lsParametros[0]).Value);
            }
        }
    }
}
