using PT_CANVIA.Aplicacion.Request;
using PT_CANVIA.Core.Entidades.Ventas;
using PT_CANVIA.Infraestructura.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_CANVIA.Aplicacion.Handlers
{
    public class TipoDocumentoHandler
    {
        public Task<TipoDocumento> GetPorIdAsync(TipoDocumentoGetPorId oRequest)
        {
            TipoDocumentoRepositorio oRepositorio = new TipoDocumentoRepositorio();
            return oRepositorio.GetPorIdAsync(oRequest.nTipoDocumento_Id);
        }

        public Task<IReadOnlyList<TipoDocumento>> GetDatosAsync(TipoDocumentoGetDatos oRequest)
        {
            TipoDocumentoRepositorio oRepositorio = new TipoDocumentoRepositorio();
            return oRepositorio.GetDatosAsync(oRequest.nTipoDocumento_Id, oRequest.cQuery);
        }

        public Task<TipoDocumento> GrabarAsync(TipoDocumentoGrabar oRequest)
        {
            TipoDocumentoRepositorio oRepositorio = new TipoDocumentoRepositorio();
            return oRepositorio.GrabarAsync(oRequest.oEntity);
        }

        public Task EliminarAsync(TipoDocumentoEliminar oRequest)
        {
            TipoDocumentoRepositorio oRepositorio = new TipoDocumentoRepositorio();
            return oRepositorio.EliminarAsync(oRequest.nTipoDocumento_Id);
        }
    }
}
