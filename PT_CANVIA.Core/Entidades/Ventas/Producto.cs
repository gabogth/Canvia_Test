using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_CANVIA.Core.Entidades.Ventas
{
    public class Producto
    {
      public int nProducto_Id { get; set; }
      public string cNombre { get; set; }
      public string cNombreCorto { get; set; }
      public string cUnidadCompra { get; set; }
      public string cUnidadVenta { get; set; }
      public decimal nConversion { get; set; }
    }
}
