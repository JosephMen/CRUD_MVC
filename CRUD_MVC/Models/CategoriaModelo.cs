using System.ComponentModel.DataAnnotations;

namespace CRUD_MVC.Models
{
    public class CategoriaModelo
    {
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [StringLength(50)]
        public string? NombreCategoria { get; set; }

        public int esActiva 
        {
            get { return activa; }
            set
            {
                if (value >= 1)
                {
                    activa = 1;
                    Estado = true;
                }
                else
                {
                    activa = 0;
                    Estado= false;
                }
            }
        }
        public bool Estado
        {
            get { return activa > 0; }
            set
            {
                if (value)
                {
                    activa = 1;
                }
                else { activa = 0; }
            }
        }

        private int activa;

    }
}
