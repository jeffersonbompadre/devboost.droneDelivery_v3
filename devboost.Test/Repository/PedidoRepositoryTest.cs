using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.Test.Config;
using devboost.Test.Warmup;
using Microsoft.Extensions.DependencyInjection;
using System;
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
            List<Pedido> lista = await _pedidoRepository.GetPedidos(StatusPedido.aguardandoEntrega);
            Assert.True(lista.Count > 0);
        }

        [Fact]
        public async Task GetPedidosPorStatusPesoDistancia()
        {
            List<Pedido> listaPedidos = await _pedidoRepository.GetPedidos(StatusPedido.aguardandoEntrega, 2, 2);
            Assert.True(listaPedidos.Count > 0);
        }

        [Fact]
        public async Task AddPedido()
        {
            await _pedidoRepository.AddPedido(new Pedido 
            { Id = Guid.NewGuid(),
                Peso = 4,
                DataHora = DateTime.Now,
                DistanciaParaOrigem = 2,
                StatusPedido = StatusPedido.despachado
            });

            List<Pedido> lista = await _pedidoRepository.GetPedidos(StatusPedido.despachado);
            Assert.True(lista.Count > 0);
        }
    }
}
