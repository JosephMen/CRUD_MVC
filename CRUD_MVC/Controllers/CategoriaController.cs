using Microsoft.AspNetCore.Mvc;
using CRUD_MVC.Datos;
using CRUD_MVC.Models;

namespace CRUD_MVC.Controllers
{

    public class CategoriaController : Controller
    {
        CategoriaDatos categoriaDatos = new CategoriaDatos();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listar()
        {
            var listaCategorias = categoriaDatos.Listar();
            return View(listaCategorias);
        }

        public IActionResult Guardar()
        {
            return View();
        } 

        [HttpPost]
        public IActionResult Guardar(CategoriaModelo categoria)
        {

            if (ModelState.IsValid == false)
            {
                return View();
            }
            var exito = categoriaDatos.Guardar(categoria);
            if (exito)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int idCategoria)
        {
            var categoriaModelo = categoriaDatos.ObtenerCategoria(idCategoria);
            return View(categoriaModelo);
        }

        [HttpPost]
        public IActionResult Editar(CategoriaModelo categoriaModelo)
        {

            if (ModelState.IsValid == false)
            {
                return View();
            }
            var exito = categoriaDatos.Editar(categoriaModelo);
            if (exito)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();

            }
        }

        public IActionResult Eliminar(int idCategoria)
        {
            var categoriaModelo = categoriaDatos.ObtenerCategoria(idCategoria);
            return View(categoriaModelo);
        }

        [HttpPost]
        public IActionResult Eliminar(CategoriaModelo categoriaModelo)
        {

            var exito = categoriaDatos.Eliminar(categoriaModelo.IdCategoria);
            if (exito)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();

            }
        }

    }
}
