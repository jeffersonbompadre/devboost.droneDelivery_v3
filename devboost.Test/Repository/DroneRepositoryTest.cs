using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.Test.Config;
using devboost.Test.Warmup;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace devboost.Test.Repository
{
    public class DroneRepositoryTest
    {
        readonly IDroneRepository _droneRepository;
        private readonly IDataStart _dataStart;

        public DroneRepositoryTest()
        {
            _droneRepository = StartInjection.GetServiceCollection().GetService<IDroneRepository>();
            _dataStart = StartInjection.GetServiceCollection().GetService<IDataStart>();
            // Popula base de dados
            _dataStart.Seed();
        }

        [Theory]
        [InlineData(20, 12, 35, 15, 100, StatusDrone.disponivel)]
        public async Task TestaAdicaoDeDrone(int id, int capacidade, int velocidade, int autonomia, int carga, StatusDrone status)
        {
            var drone = new Drone() 
            { 
                Id = id, Capacidade = capacidade, Velocidade = velocidade, Autonomia = autonomia, 
                Carga = carga, StatusDrone = status
            };

            await _droneRepository.AddDrone(drone);
        }

        [Fact]
        public async Task TestaRetornoDeTodosDrone()
        {
            var droneResult = await _droneRepository.GetAll();
            Assert.NotNull(droneResult);
        }

        [Fact]
        public async Task TestaConsultaDroneDisponivel()
        {
            var droneResult = await _droneRepository.GetDronesDisponiveis();
            Assert.NotNull(droneResult);
        }

        [Theory]
        [InlineData(1, 11, 30, 14, 99, StatusDrone.emTrajeto)]
        public async Task TestaAtualizaDrone(int id, int capacidade, int velocidade, int autonomia, int carga, StatusDrone status)
        {
            var drone = new Drone()
            {
                Id = id,
                Capacidade = capacidade,
                Velocidade = velocidade,
                Autonomia = autonomia,
                Carga = carga,
                StatusDrone = status
            };
            await _droneRepository.UpdateDrone(drone);
        }
    }
}
