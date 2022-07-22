using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_CANVIA.Core.Entidades.Ventas
{
    public class Cliente
    {
      public int nCliente_Id { get; set; }
      public string cTipoDocIdentidad { get; set; }
      public string cDocIdentidad { get; set; }
      public string cDescripcion { get; set; }
    }
}
