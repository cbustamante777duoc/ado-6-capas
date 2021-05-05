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
    public class TipoHabitacionDAL:CadenaDAL
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
           // string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

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

                            //esto guarda la posicion en caso se haga un alter el orden se va a mantener igual
                            int posId = drd.GetOrdinal("IIDTIPOHABILITACION");
                            int postNombre = drd.GetOrdinal("NOMBRE");
                            int postDescrip = drd.GetOrdinal("DESCRIPCION");

                            //recorrido del procedure
                            while (drd.Read())
                            {
                                //instacian de la clase tipoHabitacion
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                //recorrido de los campos del procedure igualdos con la clase
                                oTipoHabitacionCLS.id = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oTipoHabitacionCLS.nombre = drd.IsDBNull(postNombre) ? "" : drd.GetString(postNombre);
                                oTipoHabitacionCLS.descripcion = drd.IsDBNull(postDescrip) ? "" : drd.GetString(postDescrip);
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

        public List<TipoHabitacionCLS> FiltrarTipoHabitacion(string nombreHabitacion)
        {
            //instacia de la lista
            List<TipoHabitacionCLS> lista = null;
         
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //abrimos la conexion
                    cn.Open();
                    //llamada a store procedure
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarTipoHabitacion", cn))
                    {
                        //se agregan el parametro para realizar un procedimiento almacenado
                          cmd.CommandType = CommandType.StoredProcedure;
                          cmd.Parameters.AddWithValue("@nombreHabitacion", nombreHabitacion);  
                      
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            
                            lista = new List<TipoHabitacionCLS>();
                            
                            TipoHabitacionCLS oTipoHabitacionCLS;

                            int posId = drd.GetOrdinal("IIDTIPOHABILITACION");
                            int postNombre = drd.GetOrdinal("NOMBRE");
                            int postDescrip = drd.GetOrdinal("DESCRIPCION");

                           while (drd.Read())
                            {
                               
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                
                                oTipoHabitacionCLS.id = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oTipoHabitacionCLS.nombre = drd.IsDBNull(postNombre) ? "" : drd.GetString(postNombre);
                                oTipoHabitacionCLS.descripcion = drd.IsDBNull(postDescrip) ? "" : drd.GetString(postDescrip);
                                
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


        public int guardarTipoHabitacion(TipoHabitacionCLS oTipoHabitacionCLS) 
        {
            //si la respuesta es cero es porque hay algun error
            int respuesta = 0;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //abrir la conexion
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspGuardarTipoHabitacion2", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //se agregan los valores
                        cmd.Parameters.AddWithValue("@id",oTipoHabitacionCLS.id);
                        cmd.Parameters.AddWithValue("@nombre", oTipoHabitacionCLS.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", oTipoHabitacionCLS.descripcion);

                        respuesta = cmd.ExecuteNonQuery();

                        //cierre de la conexion
                        cn.Close();

                    }

                }
                catch (Exception ex)
                {

                    respuesta = 0;
                    //cierre de la conexion
                    cn.Close();
                }

            }

            return respuesta;

        }

        public TipoHabitacionCLS recuperarTipoHabitacion(int id)
        {
            //instacia del objeto como null
            TipoHabitacionCLS oTipoHabitacionCLS = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //abrimos la conexion
                    cn.Open();
                    //llamada a store procedure
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarTipoHabitacion2", cn))
                    {
                        //indicacion que es un store procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id",id);
                          
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            //esto guarda la posicion en caso se haga un alter el orden se va a mantener igual
                            int posId = drd.GetOrdinal("IIDTIPOHABILITACION");
                            int postNombre = drd.GetOrdinal("NOMBRE");
                            int postDescrip = drd.GetOrdinal("DESCRIPCION");

                            //recorrido del procedure
                            while (drd.Read())
                            {
                                //instacian de la clase tipoHabitacion
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                //recorrido de los campos del procedure igualdos con la clase
                                oTipoHabitacionCLS.id = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oTipoHabitacionCLS.nombre = drd.IsDBNull(postNombre) ? "" : drd.GetString(postNombre);
                                oTipoHabitacionCLS.descripcion = drd.IsDBNull(postDescrip) ? "" : drd.GetString(postDescrip);
                                
                                
                            }
                        }

                    }


                    cn.Close();
                }
                catch (Exception ex)
                {

                    cn.Close();
                }

            }
            return oTipoHabitacionCLS;


        }


        public int EliminarTipoHabitacion(int iidTipoHabitacion)
        {
            //si la respuesta es cero es porque hay algun error
            int respuesta = 0;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //abrir la conexion
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarTipoHabitacion2", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //se agregan los valores
                        cmd.Parameters.AddWithValue("@id", iidTipoHabitacion);
                       

                        respuesta = cmd.ExecuteNonQuery();

                        //cierre de la conexion
                        cn.Close();

                    }

                }
                catch (Exception ex)
                {

                    respuesta = 0;
                    //cierre de la conexion
                    cn.Close();
                }

            }

            return respuesta;

        }


    }
}
