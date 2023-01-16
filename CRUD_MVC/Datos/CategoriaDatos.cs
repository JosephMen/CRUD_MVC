using CRUD_MVC.Models;
using System.Data.SqlClient;
using System.Data;
namespace CRUD_MVC.Datos
{
    public class CategoriaDatos
    {
        public List<CategoriaModelo> Listar()
        {
            var oLista = new List<CategoriaModelo>();

            var cn = new Conexion();

            using (var conexion  = new SqlConnection(cn.getCadenaSql() )){
                conexion.Open();
                SqlCommand cmd = new SqlCommand("listar_categorias", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader()){

                    while (dr.Read()){
                        oLista.Add(new CategoriaModelo()  
                        {
                            IdCategoria = Convert.ToInt32(dr["nldCategori"]),
                            NombreCategoria = dr["cNombreCategori"].ToString(),
                            esActiva = Convert.ToInt32(dr["cEsActiva"])
                        });
                    }
                }
            }
            return oLista;

        }
        public CategoriaModelo ObtenerCategoria(int idCategoria)
        {

            var categoriaModelo = new CategoriaModelo();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("obtener_categoria", conexion);
                cmd.Parameters.AddWithValue("idCategoria", idCategoria);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        categoriaModelo.IdCategoria = Convert.ToInt32(dr["nldCategori"]);
                        categoriaModelo.NombreCategoria = dr["cNombreCategori"].ToString();
                        categoriaModelo.esActiva = Convert.ToInt32(dr["cEsActiva"]);
                    }
                }
            }
            return categoriaModelo;

        }

        public bool Guardar(CategoriaModelo oCategoria)
        {
            bool exito;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Usp_Ins_Co_Categoria", conexion);
                    cmd.Parameters.AddWithValue("nombre", oCategoria.NombreCategoria);
                    cmd.Parameters.AddWithValue("esActiva", oCategoria.esActiva);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                exito = true;
            }
            catch (Exception ex)
            {
                String err = ex.Message;
                exito = false;
            }

            return exito;
        }

        public bool Editar(CategoriaModelo oCategoria)
        {
            bool exito;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("editar_categoria", conexion);
                    cmd.Parameters.AddWithValue("idCategoria", oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("nombreCategoria", oCategoria.NombreCategoria);
                    cmd.Parameters.AddWithValue("esActiva", oCategoria.esActiva);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                exito = true;
            }
            catch (Exception ex)
            {
                String err = ex.Message;
                exito = false;
            }

            return exito;
        }

        public bool Eliminar(int idCategoria)
        {
            bool exito;

            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("eliminar_categoria", conexion);
                    cmd.Parameters.AddWithValue("idCategoria", idCategoria);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                exito = true;
            }
            catch (Exception ex)
            {
                String err = ex.Message;
                exito = false;
            }

            return exito;
        }
    }
    

};
