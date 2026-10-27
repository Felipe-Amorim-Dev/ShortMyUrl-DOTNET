# ShortMyUrl

[![.NET 8](https://img.shields.io/badge/.NET-8-blueviolet?logo=dotnet)](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
[![MongoDB](https://img.shields.io/badge/MongoDB-Database-green?logo=mongodb)](https://www.mongodb.com/)
[![Docker](https://img.shields.io/badge/Docker-Container-blue?logo=docker)](https://www.docker.com/)
[![License: MIT](https://img.shields.io/badge/license-MIT-lightgrey.svg)](LICENSE)



**ShortMyUrl** é uma aplicação web desenvolvida em .NET 8 para encurtamento de URLs, com backend em ASP.NET Core e persistência de dados no MongoDB. O cadastro, a exclusão e a consulta de links curtos estão implementados nesta revisão. O fluxo completo exige um MongoDB acessível e validação de integração antes de ser apresentado como pronto para produção.

## 🚀 Tecnologias

- .NET 8 (ASP.NET Core)
- MongoDB
- Docker & Docker Compose
- Swagger (para testes e documentação da API)

## 📁 Arquitetura do Projeto

[![CodeFlow](https://img.shields.io/badge/CodeFlow-Ver%20Arquitetura-%23ff0000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/Felipe-Amorim-Dev/ShortMyUrl-DOTNET/?repo=Felipe-Amorim-Dev%2ShortMyUrl-DOTNET)

<p>O projeto segue uma arquitetura modular baseada em camadas, com princípios de Domain-Driven Design (DDD) e separação de responsabilidades, facilitando manutenção, testes e escalabilidade.

**ShortMyUrl.API**
Camada de apresentação com ASP.NET Core Web API. Responsável por receber requisições HTTP, validar entradas e retornar respostas apropriadas. Utiliza Swagger para documentação automática da API.

ShortMyUrl.Domain
Contém a lógica de negócio (serviços de domínio e regras de validação). É independente de tecnologias externas, promovendo baixo acoplamento.

ShortMyUrl.Data
Camada de persistência de dados. Responsável por interagir com o MongoDB, utilizando repositórios genéricos e entidades persistentes.
</p>

<img src="IMG/solid_principles.png" width="600px" align="center">

## 🛠️ Como rodar o projeto

### Pré-requisitos

- [.NET SDK 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Docker](https://www.docker.com/)
- [MongoDB Compass](https://www.mongodb.com/products/compass) (opcional)

### MongoDB Container (independente)

Primeiro crie a rede interna do docker
```bash
docker network create nome-da-sua-network
```
Depois crie o container para o mongoDb

```bash
docker run -d --name mongodb-container -p 27017:27017 --network nome-da-sua-network mongo
```

### Rodando a API

Abra um terminal onde o arquivo **docker-compose.yml** está e rode o comando abaixo:

```bash
docker compose up --build
```

Acesse em: [http://localhost:8081/swagger](http://localhost:8081/swagger)

## 🔧 Configurações

```yaml
# docker-compose.yml (exemplo)
services:
  shortmyurl-api:
    ...
    environment:
      - MongoDbSettings__ConnectionString=mongodb://mongodb-container:27017
    networks:
      - shortmyurl-network

networks:
  shortmyurl-network:
    name: shortmyurl-network
```

## 📁 Estrutura

- `ShortMyUrl.API` — Camada de apresentação (Controllers e configurações).
- `ShortMyUrl.Domain` — Regras de negócio.
- `ShortMyUrl.Data` — Repositórios e acesso ao MongoDB.

## Estado atual

O método `Encurtar` usa a configuração `ShortUrl:BaseUrl` para formar o endereço da API, não mais o domínio do site de destino. O serviço gera um código aleatório de 12 caracteres e a rota `GET /r/{codigo}` busca o endereço no MongoDB para retornar um redirecionamento HTTP 301. Ainda é necessário testar colisões concorrentes e configurar um índice único no MongoDB antes de disponibilizar o sistema publicamente.

A presença das camadas API, Domain e Data não significa adoção completa de DDD. O projeto é um exercício de organização em camadas.

## 📜 Licença

Este projeto está licenciado sob a licença MIT.


## Como testar o fluxo

O `docker-compose.yml` executa a API e uma instância local do MongoDB. Depois de iniciar os contêineres:

```bash
docker compose up --build
curl -X POST http://localhost:8081/api/url/encurtar -H "Content-Type: application/json" -d '{"urlOriginal":"https://example.org/documentacao"}'
```

Copie o endereço retornado em `url` e consulte-o com `curl -I`. O esperado é um redirecionamento HTTP **301** com cabeçalho `Location` apontando para a URL original. Em execução local sem Docker, altere `ShortUrl:BaseUrl` para a porta efetivamente publicada pelo ASP.NET Core.

**Atenção:** o redirecionamento ainda não foi validado por testes ponta a ponta. A CI atual verifica a compilação da solução, não o banco MongoDB em execução.
