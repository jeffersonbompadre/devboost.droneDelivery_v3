using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.Test.Config;
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

        public DroneRepositoryTest()
        {
            _droneRepository = StartInjection.GetServiceCollection().GetService<IDroneRepository>();
        }

        [Fact]
        public async Task TestaRetornoDeTodosDrone()
        {
            var cliResult = await _droneRepository.GetAll();
            Assert.NotNull(cliResult);
        }

        [Fact]
        public async Task TestaConsultaDroneDisponivel()
        {
            var cliResult = await _droneRepository.GetDronesDisponiveis();
            Assert.NotNull(cliResult);
        }
    }
}
