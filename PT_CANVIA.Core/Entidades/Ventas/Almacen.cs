using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_CANVIA.Core.Entidades.Ventas
{
    public class Almacen
    {
        [Required]
        public int nAlmacen_Id { get; set; }
        [Required]
        [StringLength(200)]
        public string cNombre { get; set; }
        [Required]
        [StringLength(9)]
        public string cNombreCorto { get; set; }
    }
}
