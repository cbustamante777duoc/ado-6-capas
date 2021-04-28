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
    public class CamaDAL:CadenaDAL
    {
        public List<CamaCLS> listarCama()
        {
            //instacia de la lista
            List<CamaCLS> lista = null;
            
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //abrimos la conexion
                    cn.Open();
                    
                    using (SqlCommand cmd = new SqlCommand("uspListarCama2", cn))
                    {
                        
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<CamaCLS>();
                            CamaCLS oCamaCLS;

                            int posId = drd.GetOrdinal("IIDCAMA");
                            int postNombre = drd.GetOrdinal("NOMBRE");
                            int postDescrip = drd.GetOrdinal("DESCRIPCION");

                            
                            while (drd.Read())
                            {
                                //drd.IsDBNull(postNombre) ? "" sirve para validar si es los valores viene como null
                                oCamaCLS = new CamaCLS();
                                oCamaCLS.idCama = drd.IsDBNull(posId) ? 0: drd.GetInt32(posId);
                                oCamaCLS.nombre = drd.IsDBNull(postNombre) ? "" :drd.GetString(postNombre);
                                oCamaCLS.descripcion = drd.IsDBNull(postDescrip) ? "": drd.GetString(postDescrip);
                                lista.Add(oCamaCLS);
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

        public List<CamaCLS> FiltrarCama(string nombreCama)
        {
            //instacia de la lista
            List<CamaCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //abrimos la conexion
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspFiltrarCama", cn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombreCama",nombreCama);

                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<CamaCLS>();
                            CamaCLS oCamaCLS;

                            int posId = drd.GetOrdinal("IIDCAMA");
                            int postNombre = drd.GetOrdinal("NOMBRE");
                            int postDescrip = drd.GetOrdinal("DESCRIPCION");


                            while (drd.Read())
                            {
                                //drd.IsDBNull(postNombre) ? "" sirve para validar si es los valores viene como null
                                oCamaCLS = new CamaCLS();
                                oCamaCLS.idCama = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oCamaCLS.nombre = drd.IsDBNull(postNombre) ? "" : drd.GetString(postNombre);
                                oCamaCLS.descripcion = drd.IsDBNull(postDescrip) ? "" : drd.GetString(postDescrip);
                                lista.Add(oCamaCLS);
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
