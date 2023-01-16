
using System.Data.SqlClient;
using System.Data;
using CRUD_MVC.Models;
namespace CRUD_MVC.Datos
{
    public class ProductoDatos
    {
        public List<ProductoModelo> ListarProductos()
        {
            var oLista = new List<ProductoModelo>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("listar_productos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new ProductoModelo()
                        {
                            ProductoId = Convert.ToInt32(dr["nldProduct"]),
                            ProductoNombre = dr["cNombProduc"].ToString(),
                            ProductoPrecio = Convert.ToInt32(dr["nPrecioProd"]),
                            CategoriaId= Convert.ToInt32(dr["nldCategori"]),
                            NombreCategoria = dr["cNombreCategori"].ToString()                          
                        });
                    }
                }
            }
            return oLista;

        }

        public List<ProductoModelo> BuscarProductos(int idCategoria)
        {
            var oLista = new List<ProductoModelo>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Usp_Sel_Co_Productos", conexion);
                cmd.Parameters.AddWithValue("IdCategoria", idCategoria);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new ProductoModelo()
                        {
                            ProductoId = Convert.ToInt32(dr["nldProduct"]),
                            ProductoNombre = dr["cNombProduc"].ToString(),
                            ProductoPrecio = Convert.ToInt32(dr["nPrecioProd"]),
                            CategoriaId = Convert.ToInt32(dr["nldCategori"]),
                            NombreCategoria = dr["cNombreCategori"].ToString()
                        });
                    }
                }
            }
            return oLista;

        }
    }
}
