using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
   public class MarcaBL
    {
        public List<MarcaCLS> listarMarca2()
        {
            MarcaDAL oMarcaDAL = new MarcaDAL();

            return oMarcaDAL.listarMarca();

        }
    }
}
