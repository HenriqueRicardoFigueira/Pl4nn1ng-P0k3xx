# Pl4nn1ng P0k3xx

Pl4nn1ng P0k3xx é uma aplicação open-source web que simula uma técnica do Scrum conhecida como Planning Poker. Essa técnica permite que o time de desenvolvimento estime o tamanho de tarefas.

Como funciona:

  1 - Cada membro do time tem em mãos cartas de baralho com valores que seriam os tamanhos da tarefa. Geralmente usa-se a sequência de Fibonnaci para os tamanhos mas isso não é uma regra.
 
  2 - Um membro da equipe apresenta a tarefa e abre para votação, os outros participantes devem escolher uma carta sem apresentar aos demais.
 
  3 - Após todos os membros fazerem suas escolhas, as cartas são reveladas simultaneamente. Cada membro do time deve justificar a sua escolha, caso não haja um acordo, vota-se novamente até todos concordarem com um tamanho.

## Técnologias Utilizadas
- **.NET Core 3.1**  
    O .NET (dotNet) é uma plataforma open-source voltada para o desenvolvimento web, criada pela Microsoft, que possibilita reutilização e reaproveitamento de código. Esta plataforma possui uma ideia semelhante à do Java onde o programador pode desenvolver para qualquer sistema que suporte o .NET, ela é composta por uma máquina virtual, um compilador e uma biblioteca padrão. Também permite uma comunicação transparente entre diversas linguagens pois utiliza a CLR (Commn Language Runtime) que é um componente da máquina virtual onde realiza a gerência da execução dos programas e fornece alguns serviços como garbage collection, gerenciamento de thread e gerenciamento de memória.
    
- **Javascript**  
  Segundo seus criadores, o "JavaScript é uma linguagem de programação, leve, interpretada, orientada a objetos, baseada em protótipos e em firs class functions (funções de primeira classe), mais conhecida como a linguagem de script da internet.".
 
- **SignalR**  
  O SignalR é uma biblioteca open-source, desenvolvida por funcionários da Microsoft, que foi incorporado pela plataforma .NET. Ele auxilia e facilita a implementação de funcionalidades de tempo real com uma API que fornece serviços chamada de procedimento remoto (RPC), gerenciamento de conexão e agrupamento de conexões. Funciona com uma biblioteca no lado do Servidor(ASP.NET) e um Cliente (Javascript) utilizando uma conexão persistente que difere da conexão HTTP clássica, que possibilita transmitir mensagens a todos os clientes ao mesmo tempo e múltiplas conexões de clientes.
  A implementação do SignalR é uma abstração de meios necessários para realizar conexões cliente servidor, ela gerencia a escolha do tipo de transporte a ser utilizado, definindo por padrão o WebSocket mas podendo escolher entre Long Polling, Server Sent Events e Forever Frame. Também dois tipos de criar conexões os Hubs que permite transmitir diversos tipos de mensagem entre o cliente e o servidor sem a necessidade de criação de rotas e a PersistentConnection que expõem um serviço de broadcast HTTP. Abaixo temos a representção da arquitetura SignalR, retirada da sua documentação.

 <p align="center">
  <img src="https://github.com/HenriqueRicardoFigueira/Pl4nn1ng-P0k3xx/blob/main/documentacao/image5.png?raw=true" />
</p>

- **React**   
  O React é uma biblioteca Javascript open-source, criada pelo Facebook, utilizada para construir interfaces de usuário baseada em componentes reutilizaveis.

### Arquitetura Pl4nn1ng P0k3xx    

<p align="center">
  <img src="https://github.com/HenriqueRicardoFigueira/Pl4nn1ng-P0k3xx/blob/main/documentacao/arquitetura.jpg?raw=true)" />
</p>

O fluxo consiste em:

- **1**:  Um "jogador" cria uma sala torna-se o administrador, posteriormente envia o nome da sala para outros "jogares" que entram na mesma.
- **2**:  Os "jogadores" escolhem um tamanho para a tarefa (combinada posteriormente).
- **3**:  Administrador revela o votos de todos os jogadores.
- **4**:  Fluxo se repete enquanto existirem jogadores para votarem.
  
### Interface Pl4nn1ng P0k3xx   


 <p align="center">
  <img src="https://github.com/HenriqueRicardoFigueira/Pl4nn1ng-P0k3xx/blob/main/documentacao/interface.png?raw=true)" />
</p>

 - **AddBoar**: Função para adicionar uma "mesa" de planning para jogadores, recebe uma instancia do objeto Planning. Retorno boleano representando sucesso ou fracasso na adição.
 
 - **AddUserToBoard**: Função responsável por adicionar usário a "mesa", recebe um Id único do tipo GUID que é o identificador da "mesa" e uma instancia do usuário. Retorno boleado para representar sucesso ou fracasso na ação.
 
 - **GetUsersFromBoard**: Função que retorna a lista de usuários presentes em uma "mesa", recebe como parâmetro um Id único do tipo GUID que é o identificador da "mesa". 
 
 - **ClearUserPoint**: Função responsável por zerar os votos dos usuários a cada votação, recebe como parâmetro um Id único do tipo GUID que é o identificador da "mesa" e retorna um boleano representando o sucesso ou fracasso.

- **TooglePoints**: Função responsável por exibir os votos para todos os usuários, recebe como parâmetro um ID único do tipo GUID que é o identificador da "mesa" e o state do tipo boleano que representa se é ou não para mostrar os votos.

Ainda não possui mensagens de erros porém serão implementadas na próxima versão.

### Instruções de Uso
  Pré-requisitos:
  ```
  .NET 3.1
  Node Js Latest LTS Version: 14.17.0
  React Js Lastest LTS Version
  ```
  Utilização:
  ```
  dotnet run
  ```


### Referências:

- https://docs.microsoft.com/pt-br/dotnet/framework/get-started/
- https://docs.microsoft.com/pt-br/dotnet/framework/get-started/overview
- https://pt.wikipedia.org/wiki/.NET_Framework
- https://pt.wikipedia.org/wiki/Common_Language_Runtime
- https://www.techtudo.com.br/tudo-sobre/net-framework.html
- https://www.alura.com.br/artigos/o-que-e-net
- https://www.eduardopires.net.br/2013/04/aspnet-signalr-introducao-e-utilizacao/
- http://www.macoratti.net/13/03/net_sign1.htm
- https://docs.microsoft.com/pt-br/aspnet/signalr/overview/getting-started/introduction-to-signalr
- https://docs.microsoft.com/pt-br/aspnet/signalr/overview/security/
- https://github.com/facebook/react
