using PT_CANVIA.Core.Entidades.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_CANVIA.Aplicacion.Request
{
    public class ClienteGetDatos
    {
        public int? nCliente_Id { get; set; }
        public string cQuery { get; set; }
    }

    public class ClienteGetPorId
    {
        public int nCliente_Id { get; set; }
    }

    public class ClienteGrabar
    {
        public Cliente oEntity { get; set; }
    }

    public class ClienteEliminar
    {
        public int nCliente_Id { get; set; }
    }
}
