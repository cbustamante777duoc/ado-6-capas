using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
namespace Capa_Datos
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
                descripcion = "Solo para uno"
            });
            lista.Add(new TipoHabitacionCLS
            {
                id = 2,
                nombre = "Doble",
                descripcion = "Hecho para casados"
            });

            return lista;
        }


    }
}
