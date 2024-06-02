using Fotografia.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fotografia.Repositorio
{
    public class RepositorioOpciones : IRepositorioOpciones
    {
        private readonly FotografiaDBContext _context;

        public RepositorioOpciones(FotografiaDBContext context)
        {
            _context = context;
        }

        public async Task<List<Opcion>> GetAll()
        {
            return await _context.Opciones.ToListAsync();
        }

        public async Task<Opcion?> Get(int id)
        {
            return await _context.Opciones.FindAsync(id);
        }

        public async Task<Opcion> Add(Opcion opcion)
        {
            _context.Opciones.Add(opcion);
            await _context.SaveChangesAsync();
            return opcion;
        }

        public async Task Update(int id, Opcion opcion)
        {
            if (id != opcion.Id)
            {
                throw new ArgumentException("ID de opción no coincide con el ID especificado");
            }

            _context.Entry(opcion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpcionExists(id))
                {
                    throw new Exception("Opción no encontrada");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task Delete(int id)
        {
            var opcion = await _context.Opciones.FindAsync(id);
            if (opcion == null)
            {
                throw new Exception("Opción no encontrada");
            }

            _context.Opciones.Remove(opcion);
            await _context.SaveChangesAsync();
        }

        private bool OpcionExists(int id)
        {
            return _context.Opciones.Any(e => e.Id == id);
        }
    }
}
