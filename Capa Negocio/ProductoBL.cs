using Capa_Entidad;
using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
   public class ProductoBL
   {

        public List<ProductoCLS> listarProducto() 
        {

            ProductoDAL productoDAL = new ProductoDAL();
            return productoDAL.listarProductos();
        }

    }
}
