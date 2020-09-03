Feature: Realizar Calculo através de GEOLocalização.

Scenario: Realiza Cálculo GEOLocalization
	When Quando informar os dados Latitude1:'<latitude1>' Longitude1: '<longitude1>' Latitude2:'<Latitude2>' Longitude2:'<Longitude2>' KmRetornado:'<KmRetornado>'
	Then O Calculo de KM será realizado
	Examples: 
	| Latitude1   | Longitude1  | Latitude2   | Longitude2  | KmCalculado        |
	| -23.5880684 | -46.6564195 | -23.5990684 | -46.6784195 | 2.5536463859394547 |