# ShortMyUrl

![.NET 8](https://img.shields.io/badge/.NET-8.0-%237025F7?style=for-the-badge&logo=dotnet&logoColor=white)
![MongoDB](https://img.shields.io/badge/MongoDB-Database-%2347A248?style=for-the-badge&logo=mongodb&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-Container-%230db7ed?style=for-the-badge&logo=docker&logoColor=white)
![License: MIT](https://img.shields.io/badge/License-MIT-%23333?style=for-the-badge&logo=license&logoColor=white)
![Build](https://img.shields.io/badge/Build-Passing-%2300C853?style=for-the-badge&logo=githubactions&logoColor=white)


**ShortMyUrl** é uma aplicação web desenvolvida em .NET 8 para encurtamento de URLs, com backend em ASP.NET Core e persistência de dados no MongoDB. Ideal para criar, gerenciar e redirecionar links curtos de forma rápida e eficiente.

Esse projeto também tem em JAVA 17

[![ShortMyUrl-JAVA](https://img.shields.io/badge/Repo-ShortMyUrl--JAVA-red?style=for-the-badge&logo=github)](https://github.com/Felipe-Amorim-Dev/ShortMyUrl-JAVA)

## 🚀 Tecnologias

- .NET 8 (ASP.NET Core)
- MongoDB
- Docker & Docker Compose
- Swagger (para testes e documentação da API)

## 📁 Arquitetura do Projeto

<p>O projeto segue uma arquitetura modular baseada em camadas, com princípios de <strong>Domain-Driven Design (DDD)</strong> e separação de responsabilidades, facilitando manutenção, testes e escalabilidade.

**ShortMyUrl.API**
Camada de apresentação com ASP.NET Core Web API. Responsável por receber requisições HTTP, validar entradas e retornar respostas apropriadas. Utiliza Swagger para documentação automática da API.

**ShortMyUrl.Domain**
Contém a lógica de negócio (serviços de domínio e regras de validação). É independente de tecnologias externas, promovendo baixo acoplamento.

**ShortMyUrl.Data**
Camada de persistência de dados. Responsável por interagir com o MongoDB, utilizando repositórios genéricos e entidades persistentes.
</p>

<img src="IMG/Arquitetura do Projeto.png" width="100%" align="center">

## 🛠️ Como rodar o projeto

### ✅ Pré-requisitos

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

<hr>

### Caso seu projeto não consiga se conectar ao container do MongoDB, troque a ConectString de mongodb://seu-endereço-de-ip:27017

<hr>

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

## 📜 Licença

Este projeto está licenciado sob a licença MIT.

