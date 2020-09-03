using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Queries.Filters;
using devboost.Test.Config;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace devboost.Test.Domain.Handles.Queries
{
    public class LoginHandlerTest
    {
        readonly ILoginHandler _loginHandler;

        public LoginHandlerTest()
        {
            _loginHandler = StartInjection.GetServiceCollection().GetService<ILoginHandler>();
        }

        [Theory]
        [InlineData("Eric", "12345")]
        public async void TestaLoginUser(string userName, string password)
        {
            var login = await _loginHandler.LoginUser(new QueryUserFilter { UserName = userName, Password = password });
            Assert.NotNull(login);
        }
    }
}
