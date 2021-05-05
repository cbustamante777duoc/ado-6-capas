using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;
namespace Capa_Negocio
{
    public class TipoHabitacionBL
    {
        public List<TipoHabitacionCLS> listarTipoHabitacion()
        {
            TipoHabitacionDAL oTipoHabitacionDAL = new TipoHabitacionDAL();
            return oTipoHabitacionDAL.listarTipoHabitacion();

        }

        public List<TipoHabitacionCLS> FiltrarTipoHabitacion(string nombreHabitacion) 
        {
            TipoHabitacionDAL oTipoHabitacionDAL = new TipoHabitacionDAL();
            return oTipoHabitacionDAL.FiltrarTipoHabitacion(nombreHabitacion);

        }

        public int guardarTipoHabitacion(TipoHabitacionCLS oTipoHabitacionCLS) 
        {
            TipoHabitacionDAL oTipoHabitacionDAL = new TipoHabitacionDAL();
            return oTipoHabitacionDAL.guardarTipoHabitacion(oTipoHabitacionCLS);

        }

        public TipoHabitacionCLS recuperarTipoHabitacion(int id)
        {
            TipoHabitacionDAL oTipoHabitacionDAL = new TipoHabitacionDAL();
            return oTipoHabitacionDAL.recuperarTipoHabitacion(id);

        }

        public int EliminarTipoHabitacion(int iidTipoHabitacion) 
        {
            TipoHabitacionDAL oTipoHabitacionDAL = new TipoHabitacionDAL();
            return oTipoHabitacionDAL.EliminarTipoHabitacion(iidTipoHabitacion);

        }

    }
}
