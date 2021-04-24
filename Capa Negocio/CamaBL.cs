using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class CamaBL
    {
        public List<CamaCLS> listarCama()
        {
            
            CamaDAL oCamaDAL = new CamaDAL();
            return oCamaDAL.listarCama();

        }
    }
}
