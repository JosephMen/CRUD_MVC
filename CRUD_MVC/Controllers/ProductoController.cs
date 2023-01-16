using Microsoft.AspNetCore.Mvc;
using CRUD_MVC.Datos;
using CRUD_MVC.Models;
namespace CRUD_MVC.Controllers
{
    public class ProductoController : Controller
    {

        ProductoDatos productoDatos = new ProductoDatos();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listar()
        {
            var productoModelo = productoDatos.ListarProductos();
            return View(productoModelo);
        }
        public IActionResult Buscar()
        {
            ProductoModelo productoModelo = new ProductoModelo();
            return View(productoModelo);
        }
        public IActionResult MostrarBusqueda(ProductoModelo productoModelo) {
            var listaProductos = productoDatos.BuscarProductos(productoModelo.CategoriaId);
            return View(listaProductos);
        }

        

    }
}
