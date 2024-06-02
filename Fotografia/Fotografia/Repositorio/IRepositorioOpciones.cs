using Fotografia.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fotografia.Repositorio
{
    public interface IRepositorioOpciones
    {
        Task<List<Opcion>> GetAll();
        Task<Opcion?> Get(int id);
        Task<Opcion> Add(Opcion opcion);
        Task Update(int id, Opcion opcion);
        Task Delete(int id);
    }
}
