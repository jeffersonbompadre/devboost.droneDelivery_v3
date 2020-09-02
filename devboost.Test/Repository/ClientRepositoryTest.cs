using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.Test.Config;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace devboost.Test.Repository
{
    public class ClientRepositoryTest
    {
        readonly IClienteRepository _clienteRepository;

        public ClientRepositoryTest()
        {
            _clienteRepository = StartInjection.GetServiceCollection().GetService<IClienteRepository>();
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

        [Theory]
        [InlineData("Jefferson", "jefbpd@gmail.com", "(11)999-9999", -23.6578, -43.56079, "jefferson", "12345", "ADMIN")]
        public void TestaAdicaoDeCliente(string nome, string eMail, string telefone, double latitude, double longitude, string usuario, string senha, string perfil)
        {
            AdicionaCliente(nome, eMail, telefone, latitude, longitude, usuario, senha, perfil);
        }

        [Fact]
        public async Task TestaRetornoDeTodosCliente()
        {
            var cliResult = await _clienteRepository.GetAll();
            Assert.NotNull(cliResult);
        }

        [Fact]
        public async Task TestaConsultaClientePorNome()
        {
            var cliResult = await _clienteRepository.Get("Jefferson");
            Assert.NotNull(cliResult);
        }

        [Fact]
        public async Task TestaConsultaClientePorNomeUsuario()
        {
            var cliResult = await _clienteRepository.GetByUserName("jefferson");
            Assert.NotNull(cliResult);
        }
    }
}
