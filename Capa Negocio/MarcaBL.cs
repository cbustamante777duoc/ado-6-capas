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

        public List<MarcaCLS> filtrarMarca(string nombremarca) 
        {
            MarcaDAL oMarcaDAL = new MarcaDAL();

            return oMarcaDAL.filtrarMarca(nombremarca);
        }

        public int guardarMarca(MarcaCLS oMarcaCLS) 
        {
            MarcaDAL oMarcaDAL = new MarcaDAL();

            return oMarcaDAL.guardarMarca(oMarcaCLS);

        }

        public MarcaCLS recuperarMarca(int id) 
        {

            MarcaDAL oMarcaDAL = new MarcaDAL();

            return oMarcaDAL.recuperarMarca(id);
        }

        public int eliminarMarca(int iidMarca) 
        {
            MarcaDAL oMarcaDAL = new MarcaDAL();

            return oMarcaDAL.eliminarMarca(iidMarca);

        }
    }
}
