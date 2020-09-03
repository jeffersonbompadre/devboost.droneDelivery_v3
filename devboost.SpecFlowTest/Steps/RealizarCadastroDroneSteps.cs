using devboost.Domain.Repository;
using devboost.Test.Config;
using devboost.Test.Warmup;
using System;
using TechTalk.SpecFlow;
using Microsoft.Extensions.DependencyInjection;
using devboost.Domain.Model;
using System.Threading.Tasks;
using Xunit;

namespace devboost.SpecFlowTest.Steps
{
    [Binding]
    public class RealizarCadastroDroneSteps
    {
        readonly ScenarioContext _context;
        private readonly IDroneRepository _droneRepository;
        private readonly IDataStart _dataStart;

        public RealizarCadastroDroneSteps(ScenarioContext context)
        {
            _droneRepository = StartInjection.GetServiceCollection().GetService<IDroneRepository>();
            _dataStart = StartInjection.GetServiceCollection().GetService<IDataStart>();
            // Popula base de dados
            _context = context;
            
        }

        [Given(@"Que não existão drones cadastrados")]
        public void GivenQueNaoExistaoDronesCadastrados()
        {
            _dataStart.Seed();
        }
        
        [When(@"Quando eu cadastrar o drone Id:'(.*)' Capacidade: '(.*)' Velocidade:'(.*)' Autonomia:'(.*)' Carga:'(.*)' StatusDrone:'(.*)'")]
        public async Task WhenQuandoEuCadastrarODroneIdCapacidadeVelocidadeAutonomiaCargaStatusDrone(int p0, int p1, int p2, int p3, int p4, int p5)
        {
            var drone = new Drone()
            {
                Id = p0,
                Capacidade = p1,
                Velocidade = p2,
                Autonomia = p3,
                Carga = p4,
                StatusDrone = (StatusDrone)p5
            };

            await _droneRepository.AddDrone(drone);
            _context.Set(drone);
        }
        
        [Then(@"Será retornado um drone")]
        public void ThenSeraRetornadoUmDrone()
        {
            var droneResult = _context.Get<Drone>();
            Assert.NotNull(droneResult);
        }
    }
}
