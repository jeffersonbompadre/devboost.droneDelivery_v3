using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Test.Config;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace devboost.Test.Domain.Handles.Queries
{
    public class ClienteQueryHandlerTest
    {
        readonly IClientQueryHandler _clientQueryHandler;

        public ClienteQueryHandlerTest()
        {
            _clientQueryHandler = StartInjection.GetServiceCollection().GetService<IClientQueryHandler>();
        }

        [Fact]
        public async Task TestaRetornoTodosCliente()
        {
            var cliResult = await _clientQueryHandler.GetAll();
            Assert.NotNull(cliResult);
        }
    }
}
