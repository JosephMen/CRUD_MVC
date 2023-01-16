namespace CRUD_MVC.Models
{
    public class ProductoModelo
    {
        public int ProductoId { get; set;}
        public string ProductoNombre { get; set;}
        public int ProductoPrecio { get; set; }
        public int CategoriaId { get; set; }
        public string NombreCategoria { get; set; } = string.Empty;

    }
}
