﻿using devboost.Domain.Model;
using devboost.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.Test.Warmup
{
    public class DataStart : IDataStart
    {
        readonly IPedidoRepository _pedidoRepository;
        readonly IDroneRepository _droneRepository;
        readonly IUserRepository _userRepository;
        readonly IClienteRepository _clienteRepository;

        readonly List<Drone> droneData = new List<Drone>()
        {
            new Drone() { Id = 1, Capacidade = 12, Velocidade = 35, Autonomia = 15, Carga = 100, StatusDrone = StatusDrone.disponivel },
            new Drone() { Id = 2, Capacidade = 7, Velocidade = 25, Autonomia = 35, Carga = 50, StatusDrone = StatusDrone.disponivel },
            new Drone() { Id = 3, Capacidade = 5, Velocidade = 25, Autonomia = 35, Carga = 25, StatusDrone = StatusDrone.disponivel },
            new Drone() { Id = 4, Capacidade = 10, Velocidade = 40, Autonomia = 20, Carga = 100, StatusDrone = StatusDrone.disponivel },
            new Drone() { Id = 5, Capacidade = 8, Velocidade = 60, Autonomia = 25, Carga = 100, StatusDrone = StatusDrone.disponivel },
            new Drone() { Id = 6, Capacidade = 7, Velocidade = 50, Autonomia = 30, Carga = 20, StatusDrone = StatusDrone.disponivel },
            new Drone() { Id = 7, Capacidade = 12, Velocidade = 35, Autonomia = 15, Carga = 0, StatusDrone = StatusDrone.indisponivel },
            new Drone() { Id = 8, Capacidade = 7, Velocidade = 25, Autonomia = 35, Carga = 5, StatusDrone = StatusDrone.indisponivel }
        };

        readonly List<User> userData = new List<User>()
        {
            new User("Afonso", "12345", "admin"),
            new User("Allan", "12345", "admin"),
            new User("Eric", "12345", "admin"),
            new User("Jefferson", "12345", "admin")
        };

        readonly List<Cliente> clienteData = new List<Cliente>()
        {
            new Cliente("Hulk", "hulk@domain.com", "(11) 9999-9999", -23.5990684,-46.6784195),
            new Cliente("Thor", "thor@domain.com", "(11) 9999-9999", -23.6990684,-46.6684195),
            new Cliente("Pantera Negra", "pantera.negra@domain.com", "(11) 9999-9999", -23.5990684,-46.6684195),
            new Cliente("Iron Man", "iron.man@domain.com", "(11) 9999-9999", -23.5890684,-46.6584195),
        };

        readonly List<Pedido> pedidoData = new List<Pedido>()
        {
            new Pedido() { Id = Guid.NewGuid(), Peso = 1, DataHora = DateTime.Now, DistanciaParaOrigem = 1, StatusPedido = StatusPedido.aguardandoEntrega },
            new Pedido() { Id = Guid.NewGuid(), Peso = 2, DataHora = DateTime.Now, DistanciaParaOrigem = 2, StatusPedido = StatusPedido.aguardandoEntrega },
            new Pedido() { Id = Guid.NewGuid(), Peso = 3, DataHora = DateTime.Now, DistanciaParaOrigem = 0.5, StatusPedido = StatusPedido.aguardandoEntrega },
            new Pedido() { Id = Guid.NewGuid(), Peso = 1, DataHora = DateTime.Now, DistanciaParaOrigem = 0.2, StatusPedido = StatusPedido.aguardandoEntrega },
            new Pedido() { Id = Guid.NewGuid(), Peso = 2, DataHora = DateTime.Now, DistanciaParaOrigem = 3, StatusPedido = StatusPedido.aguardandoEntrega }
        };

        public DataStart(IPedidoRepository pedidoRepository, IDroneRepository droneRepository, IUserRepository userRepository, IClienteRepository clienteRepository)
        {
            _pedidoRepository = pedidoRepository;
            _droneRepository = droneRepository;
            _userRepository = userRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task Seed()
        {
            await AddDrone();
            await AddUser();
            await AddCliente();
            await AddPedido();
        }

        async Task AddDrone()
        {
            foreach (var drone in droneData)
            {
                await _droneRepository.AddDrone(drone);
            }
        }

        async Task AddUser()
        {
            foreach (var user in userData)
            {
                await _userRepository.AddUser(user);
            }
        }

        async Task AddCliente()
        {
            var i = 0;
            var users = new string[] { "Afonso", "Allan", "Eric", "Jefferson" };
            foreach (var cliente in clienteData)
            {
                var user = await _userRepository.GetUser(users[i++]);
                cliente.User = user;
                await _clienteRepository.AddCliente(cliente);
            }
        }

        async Task AddPedido()
        {
            foreach (var pedido in pedidoData)
            {
                pedido.Cliente = clienteData[new Random().Next(0, 3)];
                await _pedidoRepository.AddPedido(pedido);
            }
        }
    }
}
