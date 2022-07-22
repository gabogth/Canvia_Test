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
    public class ClienteHandler
    {
        public Task<Cliente> GetPorIdAsync(ClienteGetPorId oRequest)
        {
            ClienteRepositorio oRepositorio = new ClienteRepositorio();
            return oRepositorio.GetPorIdAsync(oRequest.nCliente_Id);
        }

        public Task<IReadOnlyList<Cliente>> GetDatosAsync(ClienteGetDatos oRequest)
        {
            ClienteRepositorio oRepositorio = new ClienteRepositorio();
            return oRepositorio.GetDatosAsync(oRequest.nCliente_Id, oRequest.cQuery);
        }

        public Task<Cliente> GrabarAsync(ClienteGrabar oRequest)
        {
            ClienteRepositorio oRepositorio = new ClienteRepositorio();
            return oRepositorio.GrabarAsync(oRequest.oEntity);
        }

        public Task EliminarAsync(ClienteEliminar oRequest)
        {
            ClienteRepositorio oRepositorio = new ClienteRepositorio();
            return oRepositorio.EliminarAsync(oRequest.nCliente_Id);
        }
    }
}
