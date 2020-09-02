using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Test.Config;
using devboost.Test.Warmup;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace devboost.Test.Domain.Handles
{
    public class ClienteQueryHandlerTest
    {
        readonly IClientQueryHandler _clientQueryHandler;
        readonly IDataStart _dataStart;

        public ClienteQueryHandlerTest()
        {
            _clientQueryHandler = StartInjection.GetServiceCollection().GetService<IClientQueryHandler>();
            _dataStart = StartInjection.GetServiceCollection().GetService<IDataStart>();
            // Popula base de dados
            _dataStart.Seed();
        }

        [Fact]
        public async Task TestaRetornoTodosCliente()
        {
            var cliResult = await _clientQueryHandler.GetAll();
            Assert.NotNull(cliResult);
        }
    }
}
