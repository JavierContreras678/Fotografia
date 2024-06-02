using System.ComponentModel.DataAnnotations;

namespace Fotografia.Modelos
{
    public class Opcion
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string? Nombre { get; set; }
        [Range(0.00, double.MaxValue, ErrorMessage = "El precio debe ser un valor positivo")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "Debes seleccionar un servicio")]
        public int ServicioId { get; set; }
        virtual public Servicio? Servicio { get; set; }
    }
}
