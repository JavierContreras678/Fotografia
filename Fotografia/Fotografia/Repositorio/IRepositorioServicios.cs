using Fotografia.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fotografia.Repositorio
{
    public interface IRepositorioServicios
    {
        Task<List<Servicio>> GetAll();
        Task<Servicio?> Get(int id);
        Task<Servicio> Add(Servicio servicio);
        Task Update(int id, Servicio servicio);
        Task Delete(int id);
    }
}
