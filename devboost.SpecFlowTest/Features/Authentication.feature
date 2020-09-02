Feature: Realizar Login para Autenticar no sistema

Scenario: Realizar o login
	Given Que exista um usuário cadastrado na base
	When Quando for informado o login
	Then Será retornado um token
	And será retornado um status code 200
