using devboost.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.Domain.Repository
{
    public interface IDroneRepository
    {
        Task<List<Drone>> GetAll();
        Task<List<Drone>> GetDronesDisponiveis();
        Task AddDrone(Drone drone);
        Task UpdateDrone(Drone drone);
    }
}
