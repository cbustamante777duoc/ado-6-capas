using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Dato
{
    public class TipoHabitacionDAL
    {

        public List<TipoHabitacionCLS> listarTipoHabitacion()
        {
            List<TipoHabitacionCLS> lista = new List<TipoHabitacionCLS>();
            lista.Add(new TipoHabitacionCLS
            {
                id = 1,
                nombre = "Simple",
                descripcion = "Solo para 1 persona"
            });
            lista.Add(new TipoHabitacionCLS
            {
                id = 2,
                nombre = "Doble",
                descripcion = "Solo para 2 persona"
            });
            return lista;
        }

    }
}
