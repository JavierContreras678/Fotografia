using System.ComponentModel.DataAnnotations;

namespace Fotografia.Modelos
{
    public class Carrito
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        virtual public Pedido? Pedido { get; set; }
        public int ServicioId { get; set; }
        virtual public Servicio? Servicio { get; set; }
        public string? NombreServicio => Servicio?.Nombre;
        public int OpcionId { get; set; }
        virtual public Opcion? Opcion { get; set; }
        public decimal Subtotal { get; set; }

    }
}
