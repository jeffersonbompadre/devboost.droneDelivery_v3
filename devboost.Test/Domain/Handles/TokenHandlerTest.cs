using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Model;
using devboost.Test.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using devboost.Test.Warmup;

namespace devboost.Test.Domain.Handles
{
    public class TokenHandlerTest
    {
        private ITokenHandler _tokenHandler;
        private IDataStart _dataStart;

        public TokenHandlerTest()
        {
            _tokenHandler = StartInjection.GetServiceCollection().GetService<ITokenHandler>();
            _dataStart = StartInjection.GetServiceCollection().GetService<IDataStart>();
            // Popula base de dados
            _dataStart.Seed();
        }

        [Theory]
        [InlineData("Eric Joseph", "12345", "admin")]
        public async Task TestaConsultaClientePorNomeUsuario(string userName, string password, string role)
        {
            var user = new User(userName, password, role);

            var userResult = await _tokenHandler.GenerateToken(user);
            Assert.NotNull(userResult);
        }

        [Theory]
        [InlineData("Eric Joseph", "12345", "")]
        public async Task TestaConsultaClientePorNomeUsuarioErro(string userName, string password, string role)
        {
            var user = new User(userName, password, role);

            var userResult = await _tokenHandler.GenerateToken(user);
            Assert.Empty(userResult);
        }
    }
}
