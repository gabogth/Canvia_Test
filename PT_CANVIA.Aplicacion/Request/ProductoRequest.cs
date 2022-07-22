using PT_CANVIA.Core.Entidades.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_CANVIA.Aplicacion.Request
{
    public class ProductoGetDatos
    {
        public int? nProducto_Id { get; set; }
        public string cQuery { get; set; }
    }

    public class ProductoGetPorId
    {
        public int nProducto_Id { get; set; }
    }

    public class ProductoGrabar
    {
        public Producto oEntity { get; set; }
    }

    public class ProductoEliminar
    {
        public int nProducto_Id { get; set; }
    }
}
