using Microsoft.EntityFrameworkCore;

namespace Fotografia.Modelos
{
    public class FotografiaDBContext : DbContext
    {
        public FotografiaDBContext(DbContextOptions<FotografiaDBContext> options) : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Opcion> Opciones { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Carrito> Carritos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de relaciones
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Persona)
                .WithMany(c => c.Pedidos) // Uno a muchos
                .HasForeignKey(p => p.PersonaId);

            // Configuración de precisión y escala para propiedades decimal
            modelBuilder.Entity<Pedido>()
                .Property(p => p.Total)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Opcion>()
                .Property(o => o.Precio)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Carrito>()
                .Property(c => c.Subtotal)
                .HasColumnType("decimal(18,2)");

            // Configuración de la relación Carrito -> Servicio sin eliminación en cascada
            modelBuilder.Entity<Carrito>()
                .HasOne(c => c.Servicio)
                .WithMany() // Asumiendo que un Servicio puede tener muchos Carritos
                .HasForeignKey(c => c.ServicioId)
                .OnDelete(DeleteBehavior.Restrict); // O DeleteBehavior.NoAction

            // Configuración de la relación Carrito -> Opcion sin eliminación en cascada
            modelBuilder.Entity<Carrito>()
                .HasOne(c => c.Opcion)
                .WithMany()
                .HasForeignKey(c => c.OpcionId)
                .OnDelete(DeleteBehavior.Restrict); // O DeleteBehavior.NoAction

            // Configuración de la relación Carrito -> Pedido sin eliminación en cascada
            modelBuilder.Entity<Carrito>()
                .HasOne(c => c.Pedido)
                .WithMany()
                .HasForeignKey(c => c.PedidoId)
                .OnDelete(DeleteBehavior.Restrict); // O DeleteBehavior.NoAction
        }
    }
}
