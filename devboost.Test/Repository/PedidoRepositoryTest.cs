using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.Test.Config;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.Test.Repository
{
    public class PedidoRepositoryTest
    {
        private static readonly Guid V = Guid.NewGuid();
        readonly IPedidoRepository _pedidoRepository;
        readonly IClienteRepository _clienteRepository;

        public PedidoRepositoryTest()
        {
            _clienteRepository = StartInjection.GetServiceCollection().GetService<IClienteRepository>();
            _pedidoRepository = StartInjection.GetServiceCollection().GetService<IPedidoRepository>();
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

        public async Task<List<Pedido>> GetPedidos()
        {
            List<Pedido> lista = await _pedidoRepository.GetPedidos()
        }
    }
}
