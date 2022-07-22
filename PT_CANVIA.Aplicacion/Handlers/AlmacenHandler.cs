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
    public class AlmacenHandler
    {
        public Task<Almacen> GetPorIdAsync(AlmacenGetPorId oRequest)
        {
            AlmacenRepositorio oRepositorio = new AlmacenRepositorio();
            return oRepositorio.GetPorIdAsync(oRequest.nAlmacen_Id);
        }

        public Task<IReadOnlyList<Almacen>> GetDatosAsync(AlmacenGetDatos oRequest)
        {
            AlmacenRepositorio oRepositorio = new AlmacenRepositorio();
            return oRepositorio.GetDatosAsync(oRequest.nAlmacen_Id, oRequest.cQuery);
        }

        public Task<Almacen> GrabarAsync(AlmacenGrabar oRequest)
        {
            AlmacenRepositorio oRepositorio = new AlmacenRepositorio();
            return oRepositorio.GrabarAsync(oRequest.oEntity);
        }

        public Task EliminarAsync(AlmacenEliminar oRequest)
        {
            AlmacenRepositorio oRepositorio = new AlmacenRepositorio();
            return oRepositorio.EliminarAsync(oRequest.nAlmacen_Id);
        }
    }
}
