# AnimeApi

AnimeApi � uma API RESTful constru�da com .NET 9, projetada para fornecer informa��es sobre animes. Ela interage com um banco de dados SQL Server e oferece endpoints para consulta e manipula��o de dados relacionados a animes. O projeto foi criado como parte de um processo seletivo.

## Estrutura do Projeto

A estrutura do projeto segue uma arquitetura em camadas para promover a separa��o de responsabilidades e facilitar a manuten��o e escalabilidade:

- **Api**: Camada respons�vel pela API, incluindo os controllers e o roteamento dos endpoints.
- **Service**: Camada de servi�o, onde reside a l�gica de neg�cios.
- **Infra**: Camada de infraestrutura, contendo as configura��es do banco de dados, reposit�rios e outras depend�ncias externas.
- **Domain**: Camada que cont�m as entidades e modelos de dados.
- **Tests**: Camada respons�vel pelos testes de unidade, utilizando o xUnit.

## Funcionalidades

A API oferece as seguintes funcionalidades:
- **GET /api/animes**: Retorna uma lista de todos os animes cadastrados.
- **GET /api/animes/{id}**: Retorna um anime espec�fico pelo seu ID.
- **GET api/anime/search**: Retorna um anime filtrando por ID, diretor ou nome, sendo poss�vel qualquer combina��o destes campos;
- **POST /api/animes**: Cadastra um novo anime no sistema.
- **PUT /api/animes/{id}**: Atualiza as informa��es de um anime existente.
- **DELETE /api/animes/{id}**: Remove um anime do sistema.

## Pr�-requisitos

Antes de come�ar, voc� precisar� de:

- **.NET 9 SDK** ou vers�o superior
- **SQL Server** ou banco de dados compat�vel
- **Ferramentas de Desenvolvimento**: Visual Studio ou outra IDE de sua prefer�ncia com suporte a .NET.

## Configura��o do Banco de Dados

1. Configure o banco de dados SQL Server e crie o banco de dados para armazenar as informa��es dos animes.
2. No arquivo `appsettings.json`, configure a string de conex�o para o SQL Server:
1. Execute as migra��es para criar as tabelas no banco de dados:

 - `dotnet ef database update`

## Como Rodar o Projeto

#### Clone o reposit�rio:

1. git clone https://github.com/ArielLopes888/AnimeApi

#### Navegue at� a pasta do projeto:

2.  cd AnimeApi
#### Restaure as depend�ncias:
3. dotnet restore
#### Compile e execute a API:
4.  dotnet run
	
#### A API estar� dispon�vel no endere�o https://localhost:5001 (ou o endere�o que aparecer no terminal).

