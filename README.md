# AnimeApi

AnimeApi é uma API RESTful construída com .NET 9, projetada para fornecer informações sobre animes. Ela interage com um banco de dados SQL Server e oferece endpoints para consulta e manipulação de dados relacionados a animes. O projeto foi criado como parte de um processo seletivo.

## Estrutura do Projeto

A estrutura do projeto segue uma arquitetura em camadas para promover a separação de responsabilidades e facilitar a manutenção e escalabilidade:

- **Api**: Camada responsável pela API, incluindo os controllers e o roteamento dos endpoints.
- **Service**: Camada de serviço, onde reside a lógica de negócios.
- **Infra**: Camada de infraestrutura, contendo as configurações do banco de dados, repositórios e outras dependências externas.
- **Domain**: Camada que contém as entidades e modelos de dados.
- **Tests**: Camada responsável pelos testes de unidade, utilizando o xUnit.

## Funcionalidades

A API oferece as seguintes funcionalidades:
- **GET /api/animes**: Retorna uma lista de todos os animes cadastrados.
- **GET /api/animes/{id}**: Retorna um anime específico pelo seu ID.
- **GET api/anime/search**: Retorna um anime filtrando por ID, diretor ou nome, sendo possível qualquer combinação destes campos;
- **POST /api/animes**: Cadastra um novo anime no sistema.
- **PUT /api/animes/{id}**: Atualiza as informações de um anime existente.
- **DELETE /api/animes/{id}**: Remove um anime do sistema.

## Pré-requisitos

Antes de começar, você precisará de:

- **.NET 9 SDK** ou versão superior
- **SQL Server** ou banco de dados compatível
- **Ferramentas de Desenvolvimento**: Visual Studio ou outra IDE de sua preferência com suporte a .NET.

## Configuração do Banco de Dados

1. Configure o banco de dados SQL Server e crie o banco de dados para armazenar as informações dos animes.
2. No arquivo `appsettings.json`, configure a string de conexão para o SQL Server:
1. Execute as migrações para criar as tabelas no banco de dados:

 - `dotnet ef database update`

## Como Rodar o Projeto

#### Clone o repositório:

1. git clone https://github.com/ArielLopes888/AnimeApi

#### Navegue até a pasta do projeto:

2.  cd AnimeApi
#### Restaure as dependências:
3. dotnet restore
#### Compile e execute a API:
4.  dotnet run
	
#### A API estará disponível no endereço https://localhost:5001 (ou o endereço que aparecer no terminal).

