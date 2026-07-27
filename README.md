# 📦 Stock Control

Sistema de Controle de Estoque desenvolvido com **.NET 10**, **ASP.NET Core Web API**, **Entity Framework Core**, **PostgreSQL** e **.NET MAUI**.

O objetivo do projeto é fornecer uma solução moderna para gerenciamento de produtos, fornecedores, categorias e movimentações de estoque, seguindo boas práticas de arquitetura e desenvolvimento.

---

# 🚀 Objetivo

O Stock Control foi desenvolvido para auxiliar empresas no controle de estoque, permitindo:

* Cadastro de produtos
* Cadastro de categorias
* Cadastro de fornecedores
* Controle de entradas e saídas
* Acompanhamento do estoque mínimo
* Dashboard com indicadores
* Relatórios gerenciais
* Autenticação de usuários com JWT

Além de resolver um problema real, o projeto também tem como finalidade demonstrar conhecimentos em desenvolvimento Full Stack utilizando tecnologias do ecossistema .NET.

---

# 🛠 Tecnologias Utilizadas

## Backend

* .NET 10
* ASP.NET Core Web API
* Entity Framework Core
* PostgreSQL
* JWT Authentication
* Swagger / OpenAPI
* Dependency Injection
* LINQ

## Frontend

* .NET MAUI
* MVVM
* CommunityToolkit.Mvvm
* HttpClient
* Preferences (armazenamento local)

---

# 🏛 Arquitetura

O projeto foi estruturado em camadas para facilitar manutenção, organização e escalabilidade.

```text
Controllers
│
├── Services
│
├── Models
│
├── Data
│
├── DTOs
│
├── Helpers
│
└── Database
```

### Controllers

Responsáveis por receber as requisições HTTP e encaminhá-las para a camada de serviço.

### Services

Contêm toda a regra de negócio da aplicação.

### Models

Representam as entidades do banco de dados.

### Data

Configuração do Entity Framework e DbContext.

### DTOs

Objetos utilizados para entrada e saída de dados da API.

### Helpers

Classes auxiliares utilizadas em validações, autenticação e funcionalidades compartilhadas.

---

# 🔒 Autenticação

A API utiliza autenticação baseada em **JWT (JSON Web Token)**.

Após o login, um Token é gerado e deverá ser enviado em todas as requisições protegidas através do Header:

```http
Authorization: Bearer {Token}
```

---

# 📦 Funcionalidades

## Usuários

* Cadastro
* Login
* Atualização de dados
* Alteração de senha

---

## Produtos

* Cadastro
* Consulta
* Atualização
* Ativação
* Desativação
* Controle de estoque mínimo

---

## Categorias

* Cadastro
* Consulta
* Atualização
* Exclusão

---

## Fornecedores

* Cadastro
* Consulta
* Atualização
* Exclusão

---

## Movimentações

* Entrada de estoque
* Saída de estoque
* Ajustes
* Histórico completo

---

# 📊 Dashboard

O aplicativo possui um Dashboard com informações estratégicas como:

* Total de produtos cadastrados
* Produtos com estoque baixo
* Valor total do estoque
* Últimas movimentações
* Entradas por período
* Saídas por período
* Produtos mais movimentados

---

# 📱 Telas do Aplicativo

## Login

* Autenticação de usuários
* Recuperação de senha
* Persistência da sessão

---

## Dashboard

Visão geral do sistema contendo indicadores e gráficos.

---

## Produtos

* Pesquisa
* Cadastro
* Edição
* Ativação/Desativação
* Consulta de estoque

---

## Categorias

Gerenciamento completo das categorias dos produtos.

---

## Fornecedores

Gerenciamento completo dos fornecedores.

---

## Movimentações

Registro de todas as entradas e saídas do estoque.

---

## Relatórios

Indicadores e consultas gerenciais para acompanhamento do estoque.

---

# 🗄 Banco de Dados

O sistema utiliza PostgreSQL.

Principais entidades:

* Usuários
* Produtos
* Categorias
* Fornecedores
* Movimentações de Estoque

---

# 📌 Principais Recursos

* API REST
* Arquitetura em Camadas
* Entity Framework Core
* Dependency Injection
* JWT Authentication
* Swagger
* Validações utilizando DataAnnotations
* Tratamento de erros
* Persistência com PostgreSQL

---

# ▶ Como Executar

## Clone o repositório

```bash
git clone https://github.com/seu-usuario/StockControl.git
```

---

## Configure a Connection String

Edite o arquivo:

```text
appsettings.json
```

Exemplo:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=StockControl;Username=postgres;Password=sua_senha"
}
```

---

## Execute as Migrations

```bash
dotnet ef database update
```

---

## Execute a API

```bash
dotnet run
```

---

## Acesse o Swagger

```text
https://localhost:xxxx/swagger
```

---

# 📈 Próximas Implementações

* Dashboard com gráficos
* Relatórios em PDF
* Exportação para Excel
* Pesquisa avançada
* Paginação
* Filtros dinâmicos
* Notificações de estoque mínimo
* Modo escuro
* Publicação em nuvem
* Aplicativo Android

---

# 🎯 Objetivos de Aprendizado

Este projeto foi desenvolvido para consolidar conhecimentos em:

* Arquitetura de Software
* APIs REST
* ASP.NET Core
* Entity Framework Core
* PostgreSQL
* Injeção de Dependência
* Autenticação JWT
* .NET MAUI
* MVVM
* Consumo de APIs
* Boas práticas de desenvolvimento

---

# 📷 Demonstração

Em breve serão adicionadas imagens da API, do Dashboard e das telas do aplicativo.

---

# 👨‍💻 Autor

**Adolfo Nalin Júnior**

Desenvolvedor .NET apaixonado por criar aplicações modernas, organizadas e escaláveis, utilizando as melhores práticas do ecossistema .NET.

---

## ⭐ Contribuição

Sugestões, melhorias e contribuições são sempre bem-vindas. Caso encontre algum problema ou tenha alguma ideia para evoluir o projeto, fique à vontade para abrir uma Issue ou enviar um Pull Request.
