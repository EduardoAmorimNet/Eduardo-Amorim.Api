Olá!

A Api "Eduardo-Amorim.Api" foi projetada e escrita em Net8.0
A Arquitetura utiliza foi de Micro Serviços obedecendo as regras de S.O.L.I.D, visando isso; as camadas do projeto são navegáveis e inteiramente acessíveis com suas interfaces e referências aos que herdam da mesma.

Para facilitar o entendimento os Folders foram separados em: Aplicação, Dominio, Infraestrutura, Testes, UI.
  * **Aplicação**: Serviços e acoplamento de regras de negócios para centralização (Conceito Domain-Driven Design *Vaughn Vernon*)
  * **Dominio**: Classes de transporte de Objetos, sendo inteiramente servidas só e somente a aplicação (famigerado DTO)
  * **Infraestrutura**: Referencia todas base do Projeto juntamente com componentes reutilizáveis tais como: Regras de HTTP, Exceptions tratados, Logs personalizadas, Configurações de Grafana, Google Dash ou DataDog, Configurações de Sensedia
  * **Testes**: Camada de Testes unitários (Xunit, Moq, Moquito, .NetUnitTest...)
  * **UI**: Camada que promove as interações com serviços: EndPoints
  * *Dentro de UI existe um Lib especifica para conversão de Dominio em MODEL. Patterns mais comuns orientam a não servir ao Cliente / Usuário do sistema o mesmo objeto de Domino; ou seja: Todo DTO possui seu Model.*

O Projeto está aplicado e executando na porta 44379, caso você possua alguma aplicação que trabalhe nesse porta, basta ir até: src/Eduardo-Amorim.Api/Properties/launchSettings.json e alterar o "sslPort" para uma porta de sua escolha.

Observação: A biblioteca do Xunit permite usar teorias em métodos para simular diversos valores evitando o acoplamento em rodadas de testes, exemplo:

[Theory]
[InlineData(-1)]
[InlineData(0)]
[InlineData(1)]
public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
{
    var result = _primeService.IsPrime(value);

    Assert.False(result, $"{value} should not be prime");
}

Porém, a versão aplicada nesse projeto do Xunit com o Microsoft.VisualStudio.TestPlatform.MSTest não está permitindo usar essa prática, por esse motivo os testes foram implementados de maneira a chamadas únicas para cada método.


*** ANGULAR ***

A aplicação está rodando por default na porta: 4200
Caso tenha você tenha alguma aplicação rodando nessa porta é necessário alterar a configuração do projeto para não gerar conflito.

Para executar o projeto basta usar o comando: npm run start

Duvida: Mas o comando convencional para gerar o Angular não é o "ng serve"?
Resposta: Sim, porém, estou habilitando o cors via Angular para receber qualquer chamada bidirecional, sem precisar de injetar no back-end configurações do cors. Para que isso funcione o Angular precisa buscar o arquivo de configuração que criei chamado "proxy.conf.json"; Esse que habilitar o Cors inteiramente no front sem dependência do back-end.

Se em sua máquina estiver faltando alguma biblioteca basta usar o comando:npm install ou npm install --force
