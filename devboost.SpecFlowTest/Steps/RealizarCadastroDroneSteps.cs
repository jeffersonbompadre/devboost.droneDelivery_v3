using System;
using TechTalk.SpecFlow;

namespace devboost.SpecFlowTest.Steps
{
    [Binding]
    public class RealizarCadastroDroneSteps
    {
        [Given(@"Que não existão drones cadastrados")]
        public void GivenQueNaoExistaoDronesCadastrados()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Quando eu cadastrar o drone Id:'(.*)' Capacidade: '(.*)' Velocidade:'(.*)' Autonomia:'(.*)' Carga:'(.*)' StatusDrone:'(.*)'")]
        public void WhenQuandoEuCadastrarODroneIdCapacidadeVelocidadeAutonomiaCargaStatusDrone(int p0, int p1, int p2, int p3, int p4, string p5)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Será retornado um drone")]
        public void ThenSeraRetornadoUmDrone()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
