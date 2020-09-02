using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.Test.Config;
using devboost.Test.Warmup;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace devboost.Test.Repository
{
    public class ClientRepositoryTest
    {
        readonly IClienteRepository _clienteRepository;
        readonly IDataStart _dataStart;

        public ClientRepositoryTest()
        {
            _clienteRepository = StartInjection.GetServiceCollection().GetService<IClienteRepository>();
            _dataStart = StartInjection.GetServiceCollection().GetService<IDataStart>();
            // Popula base de dados
            _dataStart.Seed();
        }

        [Theory]
        [InlineData("Novo Cliente", "novo.cliente@domain.com", "(11)999-9999", -23.6578, -43.56079, "jefferson", "12345", "ADMIN")]
        public async Task TestaAdicaoDeCliente(string nome, string eMail, string telefone, double latitude, double longitude, string usuario, string senha, string perfil)
        {
            var cliente = new Cliente(nome, eMail, telefone, latitude, longitude)
            {
                User = new User(usuario, senha, perfil)
            };
            await _clienteRepository.AddCliente(cliente);
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
            var cliResult = await _clienteRepository.Get("Pantera Negra");
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
