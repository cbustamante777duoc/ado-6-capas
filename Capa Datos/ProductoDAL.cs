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
   public class ProductoDAL:CadenaDAL
   {



        public List<ProductoCLS> listarProductos()
        {
            List<ProductoCLS> lista = null;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspListarProducto", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<ProductoCLS>();
                            ProductoCLS oProductoCLS;
                            int posId = drd.GetOrdinal("IIDPRODUCTO");
                            int posNombreProducto = drd.GetOrdinal("NOMBRE");
                            int posNombreMarca = drd.GetOrdinal("NOMBREMARCA");
                            int posPrecio = drd.GetOrdinal("PRECIOVENTA");
                            int posStock = drd.GetOrdinal("STOCK");
                            while (drd.Read())
                            {
                                oProductoCLS = new ProductoCLS();
                                oProductoCLS.iidproducto = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oProductoCLS.nombreProducto = drd.IsDBNull(posNombreProducto) ? ""
                                    : drd.GetString(posNombreProducto).ToLower();
                                oProductoCLS.nombreMarca = drd.IsDBNull(posNombreMarca) ? ""
                                   : drd.GetString(posNombreMarca).ToLower();
                                oProductoCLS.precioVenta = drd.IsDBNull(posPrecio) ? 0
                                 : drd.GetDecimal(posPrecio);
                                oProductoCLS.stock = drd.IsDBNull(posStock) ? 0
                                : drd.GetInt32(posStock);
                                oProductoCLS.denominacion =
                                    drd.IsDBNull(posStock) ? "" :
                                   (drd.GetInt32(posStock) > 50 ? "Alto" : "Bajo");
                                lista.Add(oProductoCLS);
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

        public List<ProductoCLS> filtrarProductos(string nombre)
        {
            List<ProductoCLS> lista = null;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarProducto", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        //agregando los paramentros
                        cmd.Parameters.AddWithValue("@nombre", nombre);

                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<ProductoCLS>();
                            ProductoCLS oProductoCLS;
                            int posId = drd.GetOrdinal("IIDPRODUCTO");
                            int posNombreProducto = drd.GetOrdinal("NOMBRE");
                            int posNombreMarca = drd.GetOrdinal("NOMBREMARCA");
                            int posPrecio = drd.GetOrdinal("PRECIOVENTA");
                            int posStock = drd.GetOrdinal("STOCK");
                            while (drd.Read())
                            {
                                oProductoCLS = new ProductoCLS();
                                oProductoCLS.iidproducto = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oProductoCLS.nombreProducto = drd.IsDBNull(posNombreProducto) ? ""
                                    : drd.GetString(posNombreProducto).ToLower();
                                oProductoCLS.nombreMarca = drd.IsDBNull(posNombreMarca) ? ""
                                   : drd.GetString(posNombreMarca).ToLower();
                                oProductoCLS.precioVenta = drd.IsDBNull(posPrecio) ? 0
                                 : drd.GetDecimal(posPrecio);
                                oProductoCLS.stock = drd.IsDBNull(posStock) ? 0
                                : drd.GetInt32(posStock);
                                oProductoCLS.denominacion =
                                    drd.IsDBNull(posStock) ? "" :
                                   (drd.GetInt32(posStock) > 50 ? "Alto" : "Bajo");
                                lista.Add(oProductoCLS);
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
    }
}
