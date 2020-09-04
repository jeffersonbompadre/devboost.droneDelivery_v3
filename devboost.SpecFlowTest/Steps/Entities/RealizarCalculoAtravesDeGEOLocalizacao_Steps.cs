using devboost.Domain.Entities;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace devboost.SpecFlowTest.Steps.Entities
{
    [Binding]
    public class RealizarCalculoAtravesDeGEOLocalizacao_Steps
    {
        readonly ScenarioContext _context;

        public RealizarCalculoAtravesDeGEOLocalizacao_Steps(ScenarioContext context)
        {
            _context = context;
        }

        [When(@"Quando informar os dados Latitude(.*):'(.*)' Longitude(.*): '(.*)' Latitude(.*):'(.*)' Longitude(.*):'(.*)' KmRetornado:'(.*)'")]
        public void WhenQuandoInformarOsDadosLatitudeLongitudeLatitudeLongitudeKmRetornado(double p0, double p1, double p2, double p3, double p4)
        {
            var result = GEOCalculaDistancia.CalculaDistanciaEmKM(new GEOParams(p0, p1, p2, p3));
            _context.Set(result);
        }
        
        [Then(@"O Calculo de KM será realizado")]
        public void ThenOCalculoDeKMSeraRealizado()
        {
            Assert.True(_context.Get<double>() > 0);
        }
    }
}
