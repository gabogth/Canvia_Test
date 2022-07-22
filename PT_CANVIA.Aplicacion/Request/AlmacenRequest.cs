using PT_CANVIA.Core.Entidades.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_CANVIA.Aplicacion.Request
{
    public class AlmacenGetDatos
    {
        public int? nAlmacen_Id { get; set; }
        public string cQuery { get; set; }
    }

    public class AlmacenGetPorId
    {
        public int nAlmacen_Id { get; set; }
    }

    public class AlmacenGrabar
    {
        public Almacen oEntity { get; set; }
    }

    public class AlmacenEliminar
    {
        public int nAlmacen_Id { get; set; }
    }
}
