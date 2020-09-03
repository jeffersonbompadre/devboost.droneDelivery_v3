using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.Test.Config;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace devboost.Test.Repository
{
    public class PedidoRepositoryTest
    {
        readonly IPedidoRepository _pedidoRepository;
        readonly IDroneRepository _droneRepository;

        public PedidoRepositoryTest()
        {
            _pedidoRepository = StartInjection.GetServiceCollection().GetService<IPedidoRepository>();
            _droneRepository = StartInjection.GetServiceCollection().GetService<IDroneRepository>();
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
            {
                Id = Guid.NewGuid(),
                Peso = 4,
                DataHora = DateTime.Now,
                DistanciaParaOrigem = 2,
                StatusPedido = StatusPedido.despachado
            });

            List<Pedido> lista = await _pedidoRepository.GetPedidos(StatusPedido.despachado);
            Assert.True(lista.Count > 0);
        }

        [Fact]
        public async Task UpdatePedido()
        {
            List<Pedido> lista = await _pedidoRepository.GetPedidos(StatusPedido.aguardandoEntrega);
            Pedido p = lista[0];
            p.Peso = 5;
            p.DistanciaParaOrigem = 3;

            await _pedidoRepository.UpdatePedido(p);

            List<Pedido> pedidos = await _pedidoRepository.GetPedidos(StatusPedido.aguardandoEntrega);
            Assert.True(pedidos[0].Peso == 5);
            Assert.True(pedidos[0].DistanciaParaOrigem == 3);
        }

        [Fact]
        public async Task AddPedidoDrone()
        {
            List<Pedido> pedidos = await _pedidoRepository.GetPedidos(StatusPedido.aguardandoEntrega);
            List<Drone> drones = await _droneRepository.GetDronesDisponiveis();

            Drone d = drones[0];
            Pedido p = pedidos[0];

            await _pedidoRepository.AddPedidoDrone(new PedidoDrone
            {
                DroneId = d.Id,
                PedidoId = p.Id
            });

            List<Pedido> ps = await _pedidoRepository.GetPedidos(StatusPedido.aguardandoEntrega);
            Assert.True(ps.Any(p => p.PedidosDrones.Count > 0));
        }
    }
}
