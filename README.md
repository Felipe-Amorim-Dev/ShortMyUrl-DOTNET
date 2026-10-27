<p align="center"><img src="docs/Capa-ShortMyUrl.png" alt="Capa do projeto ShortMyUrl-DOTNET" width="100%" /></p>

<h1 align="center">🔗 ShortMyUrl API</h1>

<p align="center"><em>Encurtamento e redirecionamento de URLs usando .NET e MongoDB.</em></p>

<p align="center">🇧🇷 Português | 🇺🇸 <a href="README.en.md">English</a></p>

<p align="center"><img src="https://img.shields.io/badge/licen%C3%A7a-MIT-006bed?style=flat-square" alt="MIT" /> <img src="https://img.shields.io/github/last-commit/Felipe-Amorim-Dev/ShortMyUrl-DOTNET?style=flat-square&color=006bed" alt="Last commit" /></p>

<p align="center"><a href="#sobre">Sobre</a> • <a href="#tecnologias">Tecnologias</a> • <a href="#como-rodar">Como rodar</a> • <a href="#licenca">Licença</a> • <a href="#autor">Autor</a></p>

---

<a id="sobre"></a>
## 📖 Sobre

API ASP.NET Core 8 que gera identificadores curtos, persiste links no MongoDB e redireciona URLs pela rota GET /r/{codigo}. Conta com Docker Compose e documentação Swagger.

## ✨ Funcionalidades

- Criar e consultar URLs curtas
- Excluir links registrados
- Redirecionar para URL original

## 🛠️ Tecnologias

![C#](https://img.shields.io/badge/C%23-006bed?style=for-the-badge) ![.NET 8](https://img.shields.io/badge/.NET_8-006bed?style=for-the-badge) ![MongoDB 7](https://img.shields.io/badge/MongoDB_7-006bed?style=for-the-badge) ![Docker](https://img.shields.io/badge/Docker-006bed?style=for-the-badge) ![Swagger](https://img.shields.io/badge/Swagger-006bed?style=for-the-badge)

## 📦 Pré-requisitos

Docker Engine e Docker Compose.

<a id="como-rodar"></a>
## 🚀 Como rodar

```bash
git clone https://github.com/Felipe-Amorim-Dev/ShortMyUrl-DOTNET.git
cd ShortMyUrl-DOTNET
docker compose up --build
```

Swagger: http://localhost:8081/swagger

## 🔗 Repositórios relacionados

- [ShortMyUrl-Web](https://github.com/Felipe-Amorim-Dev/ShortMyUrl-Web) — Front-end Angular 19

<a id="licenca"></a>
## 📄 Licença

Distribuído sob a [licença MIT](LICENSE).

<a id="autor"></a>
## 👤 Autor

**Felipe Figueiredo Amorim** — Desenvolvedor Full Stack.

[![LinkedIn](https://img.shields.io/badge/LinkedIn-Felipe%20Amorim-0A66C2?style=for-the-badge&logo=linkedin)](https://www.linkedin.com/in/felipe-amorim-dev/) [![E-mail](https://img.shields.io/badge/E--mail-contato-006bed?style=for-the-badge)](mailto:felipe.f.amorim@outlook.com)

<p align="center"><strong>Obrigado por visitar! / Thanks for visiting!</strong></p>
