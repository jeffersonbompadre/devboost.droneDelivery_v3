using devboost.Domain.Commands.Request;
using devboost.Domain.Handles.Commands.Interfaces;
using devboost.Test.Config;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace devboost.Test.Domain.Handles
{
    public class ClienteHandlerTest
    {
        readonly IClienteHandler _clientHandler;

        public ClienteHandlerTest()
        {
            _clientHandler = StartInjection.GetServiceCollection().GetService<IClienteHandler>();
        }

        [Theory]
        [InlineData("João da Silva", "joao.silva@domain.com", "(11) 9999-9999", -23.5990684, -46.6784195, "Jefferson")]
        public async void TestaAddCliente(string nome, string email, string telefone, double latitude, double longitude, string usuario)
        {
            await _clientHandler.AddCliente(new ClienteRequest()
            {
                Nome = nome,
                EMail = email,
                Telefone = telefone,
                Latitude = latitude,
                Longitude = longitude
            }, usuario);
        }
    }
}
