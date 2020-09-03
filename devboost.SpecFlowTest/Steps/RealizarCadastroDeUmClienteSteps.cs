﻿using devboost.Domain.Repository;
using devboost.Test.Config;
using devboost.Test.Warmup;
using System;
using TechTalk.SpecFlow;
using Microsoft.Extensions.DependencyInjection;
using devboost.Domain.Model;
using System.Threading.Tasks;
using Xunit;

namespace devboost.SpecFlowTest.Steps
{
    [Binding]
    public class RealizarCadastroDeUmClienteSteps
    {
        readonly ScenarioContext _context;
        readonly IClienteRepository _clienteRepository;
        readonly IDataStart _dataStart;

        public RealizarCadastroDeUmClienteSteps(ScenarioContext context)
        {
            _clienteRepository = StartInjection.GetServiceCollection().GetService<IClienteRepository>();
            _dataStart = StartInjection.GetServiceCollection().GetService<IDataStart>();
            _context = context;
            // Popula base de dados
            
        }

        [Given(@"Que não existão clientes cadastrados")]
        public void GivenQueNaoExistaoClientesCadastrados()
        {
            _dataStart.Seed();
        }
        
        [When(@"Quando eu cadastrar o cliente Nome:'(.*)' Email: '(.*)' Telefone:'(.*)' Latitude:'(.*)' Longitude:'(.*)' Usuario:'(.*)' Senha:'(.*)' Perfil:'(.*)'")]
        public async Task WhenQuandoEuCadastrarOClienteNomeEmailTelefoneLatitudeLongitudeUsuario(string p0, string p1, string p2, double p3, double p4, string p5,
            string p6, string p7)
        {
            var cliente = new Cliente(p0, p1, p2, p3, p4)
            {
                User = new User(p5, p6, p7)
            };
            await _clienteRepository.AddCliente(cliente);

            _context.Set(cliente);
        }
        
        
        [Then(@"Será retornado um cliente")]
        public void ThenSeraRetornadoUmCliente()
        {
            Assert.NotNull(_context.Get<Cliente>());
        }
    }
}
