using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Model;
using devboost.Domain.Queries.Filters;
using devboost.Test.Config;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace devboost.Test.Domain.Handles.Queries
{
    public class UserHandleTest
    {
        readonly IUserHandler _userHandler;

        public UserHandleTest()
        {
            _userHandler = StartInjection.GetServiceCollection().GetService<IUserHandler>();
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
