using Fotografia.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fotografia.Repositorio
{
    public class RepositorioPedidos : IRepositorioPedidos
    {
        private readonly FotografiaDBContext _context;

        public RepositorioPedidos(FotografiaDBContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> GetAll()
        {
            return await _context.Pedidos.ToListAsync();
        }

        public async Task<Pedido?> Get(int id)
        {
            return await _context.Pedidos.FindAsync(id);
        }

        public async Task<Pedido> Add(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task Update(int id, Pedido pedido)
        {
            if (id != pedido.Id)
            {
                throw new ArgumentException("ID de pedido no coincide con el ID especificado");
            }

            _context.Entry(pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
                {
                    throw new Exception("Pedido no encontrado");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task Delete(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                throw new Exception("Pedido no encontrado");
            }

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.Id == id);
        }
    }
}
