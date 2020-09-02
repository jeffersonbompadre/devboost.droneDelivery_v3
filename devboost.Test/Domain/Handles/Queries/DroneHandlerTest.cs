using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Model;
using devboost.Test.Config;
using devboost.Test.Warmup;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace devboost.Test.Domain.Handles.Queries
{
    public class DroneHandlerTest
    {
        IDroneHandler _droneHandler;
        readonly IDataStart _dataStart;

        public DroneHandlerTest()
        {
            _droneHandler = StartInjection.GetServiceCollection().GetService<IDroneHandler>();
            _dataStart = StartInjection.GetServiceCollection().GetService<IDataStart>();
            // Popula base de dados
            _dataStart.Seed();
        }

        [Fact]
        public async Task BuscarDrone()
        {
            List<Drone> lista = await _droneHandler.BuscarDrone();
            Assert.True(lista.Count > 0);
        }
    }
}
