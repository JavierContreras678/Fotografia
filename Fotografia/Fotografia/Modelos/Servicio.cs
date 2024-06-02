using System.ComponentModel.DataAnnotations;

namespace Fotografia.Modelos
{
    public class Servicio
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string? Nombre { get; set; }
        public virtual ICollection<Opcion>? Opciones { get; set; }


    }
}