using System;
using TechTalk.SpecFlow;

namespace devboost.SpecFlowTest.Steps
{
    [Binding]
    public class RealizarLoginParaAutenticarNoSistemaSteps
    {
        readonly ScenarioContext _context;

        public RealizarLoginParaAutenticarNoSistemaSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"Que exista um usuário cadastrado na base")]
        public void GivenQueExistaUmUsuarioCadastradoNaBase()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Quando for informado o login")]
        public void WhenQuandoForInformadoOLogin()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Será retornado um token")]
        public void ThenSeraRetornadoUmToken()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"será retornado um status code (.*)")]
        public void ThenSeraRetornadoUmStatusCode(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
