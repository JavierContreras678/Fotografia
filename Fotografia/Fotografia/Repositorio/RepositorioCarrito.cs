using Fotografia.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fotografia.Repositorio
{
    public class RepositorioCarrito : IRepositorioCarritos
    {
        private readonly FotografiaDBContext _context;

        public RepositorioCarrito(FotografiaDBContext context)
        {
            _context = context;
        }

        public async Task<List<Carrito>> GetAll()
        {
            return await _context.Carritos.ToListAsync();
        }

        public async Task<Carrito?> Get(int id)
        {
            return await _context.Carritos.FindAsync(id);
        }

        public async Task<Carrito> Add(Carrito carrito)
        {
            _context.Carritos.Add(carrito);
            await _context.SaveChangesAsync();
            return carrito;
        }

        public async Task Update(int id, Carrito carrito)
        {
            if (id != carrito.Id)
            {
                throw new ArgumentException("ID de carrito no coincide con el ID especificado");
            }

            _context.Entry(carrito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarritoExists(id))
                {
                    throw new Exception("Carrito no encontrado");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task Delete(int id)
        {
            var carrito = await _context.Carritos.FindAsync(id);
            if (carrito == null)
            {
                throw new Exception("Carrito no encontrado");
            }

            _context.Carritos.Remove(carrito);
            await _context.SaveChangesAsync();
        }

        private bool CarritoExists(int id)
        {
            return _context.Carritos.Any(e => e.Id == id);
        }
    }
}
