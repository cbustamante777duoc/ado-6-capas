using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
   public class ProductoCLS
   {
        public int iidproducto { get; set; }
        public string nombreProducto { get; set; }

        public string nombreMarca { get; set; }

        public decimal precioVenta { get; set; }

        public int stock { get; set; }

        public string denominacion { get; set; }
    }
}
