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
    public class ProductoHandler
    {
        public Task<Producto> GetPorIdAsync(ProductoGetPorId oRequest)
        {
            ProductoRepositorio oRepositorio = new ProductoRepositorio();
            return oRepositorio.GetPorIdAsync(oRequest.nProducto_Id);
        }

        public Task<IReadOnlyList<Producto>> GetDatosAsync(ProductoGetDatos oRequest)
        {
            ProductoRepositorio oRepositorio = new ProductoRepositorio();
            return oRepositorio.GetDatosAsync(oRequest.nProducto_Id, oRequest.cQuery);
        }

        public Task<Producto> GrabarAsync(ProductoGrabar oRequest)
        {
            ProductoRepositorio oRepositorio = new ProductoRepositorio();
            return oRepositorio.GrabarAsync(oRequest.oEntity);
        }

        public Task EliminarAsync(ProductoEliminar oRequest)
        {
            ProductoRepositorio oRepositorio = new ProductoRepositorio();
            return oRepositorio.EliminarAsync(oRequest.nProducto_Id);
        }
    }
}
