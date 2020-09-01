using devboost.Domain.Repository;
using devboost.Test.Config;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace devboost.Test.Repository
{
    public class ClientRepositoryTest
    {
        readonly IClienteRepository _clienteRepository;

        public ClientRepositoryTest()
        {
            _clienteRepository = StartInjection.GetServiceCollection().GetService<IClienteRepository>();
        }

        [Fact]
        public void TestaRetornoDeTOdosCliente()
        {
            var cliResult = _clienteRepository.GetAll();
            Assert.NotNull(cliResult);
        }
    }
}
