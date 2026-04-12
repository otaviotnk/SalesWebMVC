# SalesWebMVC

Aplicação web para gerenciamento de registros de vendas, desenvolvida com **ASP.NET Core MVC** e **MySQL**.

## 📋 Sobre

SalesWebMVC é um sistema web baseado em CRUD que permite gerenciar vendedores, departamentos e registros de vendas. Possui busca por intervalo de datas e relatórios de vendas agrupados por departamento.

## 🚀 Funcionalidades

- **Departamentos** — Cadastro, visualização, edição e exclusão de departamentos
- **Vendedores** — CRUD completo com validação de formulário (nome, e-mail, data de nascimento, salário base)
- **Registros de Vendas** — Busca por intervalo de datas com dois modos de exibição:
  - Listagem simples
  - Agrupada por departamento
- Populamento automático do banco de dados com dados de exemplo na primeira execução
- Localização em português do Brasil (`pt-BR`)

## 🛠️ Tecnologias

| Tecnologia | Versão |
|---|---|
| .NET | 10.0 |
| ASP.NET Core MVC | 10.0 |
| Entity Framework Core | 9.0 |
| Pomelo.EntityFrameworkCore.MySql | 9.0.0 |
| MySQL | — |
| Razor Views | — |

## 🗂️ Estrutura do Projeto

```
SalesWebMVC/
├── Controllers/
│   ├── DepartmentsController.cs
│   ├── HomeController.cs
│   ├── SalesRecordsController.cs
│   └── SellersController.cs
├── Data/
│   ├── SalesWebMVCContext.cs
│   └── SeedingService.cs
├── Models/
│   ├── Enums/
│   │   └── SalesStatus.cs       # Pendente, Faturado, Cancelado
│   ├── ViewModels/
│   │   ├── ErrorViewModel.cs
│   │   └── SellerFormViewModel.cs
│   ├── Department.cs
│   ├── SalesRecord.cs
│   └── Seller.cs
├── Services/
│   ├── Exceptions/
│   │   ├── DbConcurrencyException.cs
│   │   ├── IntegrityException.cs
│   │   └── NotFoundException.cs
│   ├── DepartmentService.cs
│   ├── SalesRecordService.cs
│   └── SellerService.cs
├── Migrations/
├── appsettings.json
└── Program.cs
```

## ⚙️ Pré-requisitos

- [.NET SDK 10.0](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/)

## 🔧 Configuração e Execução

**1. Clone o repositório**

```bash
git clone https://github.com/otaviotnk/SalesWebMVC.git
cd SalesWebMVC
```

**2. Configure a conexão com o banco de dados**

Edite o arquivo `SalesWebMVC/appsettings.json` e atualize a string de conexão com suas credenciais do MySQL:

```json
"ConnectionStrings": {
  "SalesWebMVCContext": "server=localhost;userid=root;password=SUA_SENHA;database=saleswebmvcappdb"
}
```

**3. Aplique as migrations e execute**

```bash
cd SalesWebMVC
dotnet ef database update
dotnet run
```

Na primeira execução, o banco de dados será populado automaticamente com dados de exemplo.

**4. Acesse a aplicação**

Abra o navegador e acesse `https://localhost:5001` ou `http://localhost:5000`.

## 🌱 Dados de Exemplo

Na primeira execução, o serviço de seeding popula o banco com:

- **4 Departamentos**: Computers, Electronics, Fashion, Books
- **6 Vendedores**: Bob Brown, Maria Green, Alex Grey, Martha Red, Donald Blue, Alex Pink
- **30 Registros de Vendas** com datas aleatórias distribuídas ao longo do ano anterior ao atual, com status variados (Faturado, Pendente, Cancelado)

## 📦 Pacotes NuGet

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="9.0.7" />
<PackageReference Include="Pomelo.EntityFrameworkCore.MySql" Version="9.0.0" />
```

## 📄 Licença

Este projeto foi desenvolvido para fins educacionais.
