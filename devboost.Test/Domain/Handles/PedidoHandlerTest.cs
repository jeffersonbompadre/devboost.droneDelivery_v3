using devboost.Domain.Commands.Request;
using devboost.Domain.Handles.Commands.Interfaces;
using devboost.Test.Config;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace devboost.Test.Domain.Handles
{
    public class PedidoHandlerTest
    {
        readonly IPedidoHandler _pedidoHandler;

        public PedidoHandlerTest()
        {
            var _serviceProvider = new StartInjection().ServiceProvider;
            _pedidoHandler = _serviceProvider.GetService<IPedidoHandler>();
        }

        [Theory]
        [InlineData(5, "Eric")]
        public async void TestaRealizarPedido(int peso, string usuario)
        {
            var pedido = await _pedidoHandler.RealizarPedido(new RealizarPedidoRequest { Peso = peso }, usuario);
            Assert.NotNull(pedido);
        }

        [Fact]
        public async void TestaDistribuirPedido()
        {
            await _pedidoHandler.DistribuirPedido();
        }
    }
}
