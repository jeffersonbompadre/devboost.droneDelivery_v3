using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.Test.Config;
using devboost.Test.Warmup;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace devboost.Test.Repository
{
    public class PedidoRepositoryTest
    {        
        readonly IPedidoRepository _pedidoRepository;        
        readonly IDataStart _dataStart;

        public PedidoRepositoryTest()
        {
            _dataStart = StartInjection.GetServiceCollection().GetService<IDataStart>();
            _pedidoRepository = StartInjection.GetServiceCollection().GetService<IPedidoRepository>();
            _dataStart.Seed();
        }

        [Fact]
        public async Task GetPedidos()
        {
            List<Pedido> lista = await _pedidoRepository.GetPedidos(StatusPedido.aguardandoAprovacao);
            Assert.NotNull(lista);
        }
    }
}
