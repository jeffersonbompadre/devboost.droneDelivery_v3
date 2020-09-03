using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Queries.Filters;
using devboost.Test.Config;
using devboost.Test.Warmup;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace devboost.Test.Domain.Handles.Queries
{
    public class LoginHandlerTest
    {
        readonly ILoginHandler _loginHandler;
        readonly IDataStart _dataStart;

        public LoginHandlerTest()
        {
            _loginHandler = StartInjection.GetServiceCollection().GetService<ILoginHandler>();
            _dataStart = StartInjection.GetServiceCollection().GetService<IDataStart>();
            // Popula base de dados
            _dataStart.Seed();
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
