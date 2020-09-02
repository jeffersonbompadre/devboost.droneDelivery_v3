using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Model;
using devboost.Domain.Queries.Filters;
using devboost.Test.Config;
using devboost.Test.Warmup;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace devboost.Test.Domain.Handles
{
    public class UserHandleTest
    {
        readonly IUserHandler _userHandler;
        readonly IDataStart _dataStart;

        public UserHandleTest()
        {
            _userHandler = StartInjection.GetServiceCollection().GetService<IUserHandler>();
            _dataStart = StartInjection.GetServiceCollection().GetService<IDataStart>();
            _dataStart.Seed();
        }

        [Fact]
        public async Task GetUser()
        {
            User user = await _userHandler.GetUser(new QueryUserFilter 
            {
                UserName = "Allan"
            });

            Assert.NotNull(user);
        }
    }
}
