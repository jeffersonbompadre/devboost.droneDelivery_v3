using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Model;
using devboost.Test.Config;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace devboost.Test.Domain.Handles.Queries
{
    public class DroneHandlerTest
    {
        IDroneHandler _droneHandler;

        public DroneHandlerTest()
        {
            var _serviceProvider = new StartInjection().ServiceProvider;
            _droneHandler = _serviceProvider.GetService<IDroneHandler>();
        }

        [Fact]
        public async Task BuscarDrone()
        {
            List<Drone> lista = await _droneHandler.BuscarDrone();
            Assert.True(lista.Count > 0);
        }
    }
}
