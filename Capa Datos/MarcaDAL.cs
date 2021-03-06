using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class MarcaDAL : CadenaDAL
    {

        public List<MarcaCLS> listarMarca()
        {
            List<MarcaCLS> lista = null;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspListarMarca", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<MarcaCLS>();
                            MarcaCLS oMarcaCLS;
                            int posId = drd.GetOrdinal("IIDMARCA");
                            int posNombre = drd.GetOrdinal("NOMBREMARCA");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                oMarcaCLS = new MarcaCLS();
                                oMarcaCLS.idMarca = drd.IsDBNull(posId) ? 0 :
                                    drd.GetInt32(posId);
                                oMarcaCLS.nombreMarca = drd.IsDBNull(posNombre) ? ""
                                    : drd.GetString(posNombre);
                                oMarcaCLS.descripcion = drd.IsDBNull(posDescripcion) ? ""
                                    : drd.GetString(posDescripcion);
                                lista.Add(oMarcaCLS);
                            }
                        }

                    }

                    //Cierro una vez de traer la data
                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                }

            }
            return lista;


        }

        public List<MarcaCLS> filtrarMarca(string nombremarca)
        {
            List<MarcaCLS> lista = null;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarMarca", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", nombremarca);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<MarcaCLS>();
                            MarcaCLS oMarcaCLS;
                            int posId = drd.GetOrdinal("IIDMARCA");
                            int posNombre = drd.GetOrdinal("NOMBREMARCA");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                oMarcaCLS = new MarcaCLS();
                                oMarcaCLS.idMarca = drd.IsDBNull(posId) ? 0 :
                                    drd.GetInt32(posId);
                                oMarcaCLS.nombreMarca = drd.IsDBNull(posNombre) ? ""
                                    : drd.GetString(posNombre);
                                oMarcaCLS.descripcion = drd.IsDBNull(posDescripcion) ? ""
                                    : drd.GetString(posDescripcion);
                                lista.Add(oMarcaCLS);
                            }
                        }

                    }

                    //Cierro una vez de traer la data
                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                }

            }
            return lista;


        }



        public int eliminarMarca(int iidMarca)
        {
            int respuesta = 0;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspEliminarMarca2", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id", iidMarca);

                        respuesta = cmd.ExecuteNonQuery();

                        cn.Close();
                        
                    }

                    //Cierro la conexion
                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                }

            }
            return respuesta;


        }

        public int guardarMarca(MarcaCLS oMarcaCLS)
        {
            int respuesta = 0;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspGuardarMarca2", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        //se agregan los valores
                        cmd.Parameters.AddWithValue("@id", oMarcaCLS.idMarca);
                        cmd.Parameters.AddWithValue("@nombre", oMarcaCLS.nombreMarca);
                        cmd.Parameters.AddWithValue("@descripcion", oMarcaCLS.descripcion);

                        respuesta = cmd.ExecuteNonQuery();

                    }

                    cn.Close();


                }
                catch (Exception ex)
                {
                   
                    cn.Close();
                }

            }
            return respuesta;


        }


        public MarcaCLS recuperarMarca(int id)
        {
            MarcaCLS oMarcaCLS=null;

            
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarMarca2", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id",id);

                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                           
                            int posId = drd.GetOrdinal("IIDMARCA");
                            int posNombre = drd.GetOrdinal("NOMBREMARCA");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");

                            while (drd.Read())
                            {
                                oMarcaCLS = new MarcaCLS();
                                oMarcaCLS.idMarca = drd.IsDBNull(posId) ? 0 :
                                    drd.GetInt32(posId);
                                oMarcaCLS.nombreMarca = drd.IsDBNull(posNombre) ? ""
                                    : drd.GetString(posNombre);
                                oMarcaCLS.descripcion = drd.IsDBNull(posDescripcion) ? ""
                                    : drd.GetString(posDescripcion);
                               
                            }
                        }

                    }

                    //Cierro una vez de traer la data
                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                }

            }
            return oMarcaCLS;


        }



    }
}