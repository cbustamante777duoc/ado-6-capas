using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
/*Conexion a la BD*/
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace Capa_Datos
{
    public class TipoHabitacionDAL
    {

        //public List<TipoHabitacionCLS> listarTipoHabitacion()
        //{
        //    List<TipoHabitacionCLS> lista = new List<TipoHabitacionCLS>();
        //    lista.Add(new TipoHabitacionCLS
        //    {
        //        id = 1,
        //        nombre = "Simple",
        //        descripcion = "Solo para uno"
        //    });
        //    lista.Add(new TipoHabitacionCLS
        //    {
        //        id = 2,
        //        nombre = "Doble",
        //        descripcion = "Hecho para casados"
        //    });

        //    return lista;
        //}

        public List<TipoHabitacionCLS> listarTipoHabitacion() 
        {
            //instacia de la lista
            List<TipoHabitacionCLS> lista = null;
            string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

            //cadena de conexion
            //@"server=DESKTOP-AMTKMKE\SQLEXPRESS;database=BDHotel;Integrated Security=true"
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //abrimos la conexion
                    cn.Open();
                    //llamada a store procedure
                    using (SqlCommand cmd = new SqlCommand("uspListarTipoHabitacion2", cn)) 
                    {
                        //indicacion que es un store procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        //lee el procedure 
                        SqlDataReader drd =  cmd.ExecuteReader();
                        if (drd!=null)
                        {
                            //igualar la lista 
                            lista = new List<TipoHabitacionCLS>();
                            //llamada de la clase
                            TipoHabitacionCLS oTipoHabitacionCLS;
                            //recorrido del procedure
                            while (drd.Read())
                            {
                                //instacian de la clase tipoHabitacion
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                //recorrido de los campos del procedure igualdos con la clase
                                oTipoHabitacionCLS.id = drd.GetInt32(0);
                                oTipoHabitacionCLS.nombre = drd.GetString(1);
                                oTipoHabitacionCLS.descripcion = drd.GetString(2);
                                //se agrega a la lista el objeto de tipoHabitacion
                                lista.Add(oTipoHabitacionCLS);
                            }
                        }

                    }
                       

                        //cuando se llama la conexion se debe cerrar la conexion
                        cn.Close();
                }
                catch (Exception ex)
                {

                    cn.Close();
                }
                
            }
            return lista;


        }

    }
}
