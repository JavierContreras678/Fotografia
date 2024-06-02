using Fotografia.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Fotografia.Repositorio
{
    public class RepositorioServicios : IRepositorioServicios
    {
        private readonly FotografiaDBContext _context;

        public RepositorioServicios(FotografiaDBContext context)
        {
            _context = context;
        }

        public async Task<List<Servicio>> GetAll()
        {
            return await _context.Servicios.ToListAsync();
        }

        public async Task<Servicio?> Get(int id)
        {
            return await _context.Servicios.FindAsync(id);
        }

        public async Task<Servicio> Add(Servicio servicio)
        {
            _context.Servicios.Add(servicio);
            await _context.SaveChangesAsync();
            return servicio;
        }

        public async Task Update(int id, Servicio servicio)
        {
            if (id != servicio.Id)
            {
                throw new ArgumentException("ID de servicio no coincide con el ID especificado");
            }

            _context.Entry(servicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicioExists(id))
                {
                    throw new Exception("Servicio no encontrado");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task Delete(int id)
        {
            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio == null)
            {
                throw new Exception("Servicio no encontrado");
            }

            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();
        }

        private bool ServicioExists(int id)
        {
            return _context.Servicios.Any(e => e.Id == id);
        }
    }
}
