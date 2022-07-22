using PT_CANVIA.Core.Entidades.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_CANVIA.Aplicacion.Request
{
    public class TipoDocumentoGetDatos
    {
        public int? nTipoDocumento_Id { get; set; }
        public string cQuery { get; set; }
    }

    public class TipoDocumentoGetPorId
    {
        public int nTipoDocumento_Id { get; set; }
    }

    public class TipoDocumentoGrabar
    {
        public TipoDocumento oEntity { get; set; }
    }

    public class TipoDocumentoEliminar
    {
        public int nTipoDocumento_Id { get; set; }
    }
}
