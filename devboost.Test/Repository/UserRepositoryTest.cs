using devboost.Domain.Repository;
using devboost.Test.Config;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace devboost.Test.Repository
{
    public class UserRepositoryTest
    {
        readonly IUserRepository _userRepository;

        public UserRepositoryTest()
        {
            _userRepository = StartInjection.GetServiceCollection().GetService<IUserRepository>();
        }

        [Fact]
        public async Task TestaConsultaClientePorNomeUsuario()
        {
            var userResult = await _userRepository.GetUser("jefferson");
            Assert.NotNull(userResult);
        }
    }
}
