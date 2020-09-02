using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.Test.Config;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace devboost.Test.Domain.Handles
{
    public class ClienteQueryHandlerTest
    {
        readonly IClienteRepository _clienteRepository;
        readonly IClientQueryHandler _clientQueryHandler;

        public ClienteQueryHandlerTest()
        {
            _clienteRepository = StartInjection.GetServiceCollection().GetService<IClienteRepository>();
            _clientQueryHandler = StartInjection.GetServiceCollection().GetService<IClientQueryHandler>();
            AdicionaCliente("Jefferson", "jefbpd@gmail.com", "(11)999-9999", -23.6578, -43.56079, "jefferson", "12345", "ADMIN");
        }

        private void AdicionaCliente(string nome, string eMail, string telefone, double latitude, double longitude, string usuario, string senha, string perfil)
        {
            var cliente = new Cliente(nome, eMail, telefone, latitude, longitude)
            {
                User = new User(usuario, senha, perfil)
            };
            Task.FromResult(_clienteRepository.AddCliente(cliente));
        }

        [Fact]
        public async Task TestaRetornoTodosCliente()
        {
            var cliResult = await _clientQueryHandler.GetAll();
            Assert.NotNull(cliResult);
        }
    }
}
