using devboost.Domain.Repository;
using devboost.Test.Config;
using devboost.Test.Warmup;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using devboost.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace devboost.Test.Repository
{
    class UserRepositoryTest
    {

        readonly IUserRepository _userRepository;
        readonly IDataStart _dataStart;


        public UserRepositoryTest()
        {
            _userRepository = StartInjection.GetServiceCollection().GetService<IUserRepository>();
            _dataStart = StartInjection.GetServiceCollection().GetService<IDataStart>();
            
            // Popula base de dados
            _dataStart.Seed();
        }


        [Fact]
        public async Task TestaConsultaClientePorNomeUsuario()
        {
            var userResult = await _userRepository.GetUser("jefferson");
            Assert.NotNull(userResult);
        }



    }
}
