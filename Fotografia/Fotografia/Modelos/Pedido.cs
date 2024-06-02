using System.ComponentModel.DataAnnotations;

namespace Fotografia.Modelos
{
    public class Pedido
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        virtual public Persona? Persona { get; set; }
        public string? Cita { get; set; }
        public decimal Total { get; set; }
        public string? FechaPedido { get; set; }
    }
}
