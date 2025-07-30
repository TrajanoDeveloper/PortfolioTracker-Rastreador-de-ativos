# 📊Portfolio Ativos(Em desenvolvimento)

Sistema para acompanhamento de carteira de investimentos desenvolvido em ASP.NET Core 9 e Angular.

## 🏗️ Arquitetura

O projeto segue uma arquitetura em camadas (Clean Architecture) organizada da seguinte forma:

```
PortfolioAtivos/
├── SCR
|   ├── 1-PRESENTATION         
│   │   ├── PortfolioTracker.API/
|   |   ├── Dependências
|   |   ├── Properties
|   |   └── Controllers
│   │   |   └── AtivosController.cs
|   |   ├── appsettings.json
|   |   ├── PortfolioTracker.API.http
|   |   └── Program.cs
│   ├── 2-APPLICATION           
│   │   ├── PortfolioAtivos.Application/
|   |   ├── Dependências
|   |   ├── DTO
│   │   |   ├── AtivoDto.cs
│   │   |   ├── DashboardDto.cs
│   │   |   └── OperacaoDto.cs
|   |   ├── Interfaces
│   │   |   ├── IAtivoService.cs
│   │   |   ├── IDashboardService.cs
│   │   |   └── IOperacaoService.cs
|   |   ├── Mappings
│   │   |   └── AutoMapperProfile.cs
|   |   ├── Services
│   │   |   └── AtivoService.cs
│   ├── 3-DOMAIN              
│   │   ├── PortfolioAtivos.Domain/
|   |   ├── Dependências
|   |   ├── Entities
│   │   |   ├── Ativo.cs
│   │   |   ├── Carteira.cs
│   │   |   ├── Cotacao.cs
│   │   |   ├── Operacao.cs
│   │   |   ├── Posicao.cs
│   │   |   └── Usuario.cs
|   |   ├── Enus
│   │   |   ├── TipoAtivo.cs
│   │   |   └── TipoOperacao.cs      
│   ├── 4-INFRASTRUCTURE       
│   |   ├── PortfolioAtivos.Infrastructure/
|   |   ├── Dependências
|   |   ├── Data
│   │   |   └── PortfolioAtivosContext.cs
|   |   ├── Repository
│   │   |   ├── Repository.cs
│   │   |   └── UnitOfWork.cs



```

## 🚀 Tecnologias Utilizadas

### Backend
- **ASP.NET Core 9** - Framework web
- **Entity Framework Core 9** - ORM
- **SQL Server** - Banco de dados
- **AutoMapper** - Mapeamento de objetos
- **Swagger/OpenAPI** - Documentação da API

### Frontend (Planejado)
- **Angular 17+** - Framework frontend
- **TypeScript** - Linguagem
- **Chart.js** - Gráficos
- **Bootstrap/Angular Material** - UI Components

## 📊 Funcionalidades

### ✅ Implementadas
- **CRUD de Ativos** - Gerenciamento completo de ativos (Ações, FIIs, ETFs, Renda Fixa)
- **API REST** - Endpoints documentados com Swagger
- **Banco de Dados** - Estrutura completa com relacionamentos
- **Arquitetura Limpa** - Separação de responsabilidades em camadas
- **Seed Data** - Dados iniciais pré-cadastrados

### 🔄 Em Desenvolvimento
- **CRUD de Operações** - Compra, venda, dividendos
- **Dashboard** - Visão consolidada da carteira
- **Relatórios** - Geração de relatórios personalizados
- **Integração APIs** - Cotações em tempo real
- **Frontend Angular** - Interface do usuário

## 🛠️ Como Executar

### Pré-requisitos
- Visual Studio 2022 ou VS Code
- .NET 9 SDK
- SQL Server (LocalDB ou SQL Server Express)
- Node.js 18+ (para o frontend)

### 1. Clonar o Repositório
```bash
git clone <repository-url>
cd PortfolioTracker
```

### 2. Configurar Banco de Dados
```bash
# Atualizar connection string no appsettings.json
# Executar migrações
dotnet ef database update --project src/4-INFRASTRUCTURE/PortfolioTracker.Infrastructure --startup-project src/1-PRESENTATION/PortfolioTracker.API
```

### 3. Executar a API
```bash
cd src/1-PRESENTATION/PortfolioTracker.API
dotnet run
```

A API estará disponível em: `https://localhost:5001`
Swagger UI: `https://localhost:5001`

### 4. Executar Frontend (Quando disponível)
```bash
cd frontend
npm install
ng serve
```

## 📋 Estrutura do Banco de Dados

### Entidades Principais
- **Usuario** - Usuários do sistema
- **Carteira** - Carteiras de investimento
- **Ativo** - Ativos financeiros (Ações, FIIs, ETFs, etc.)
- **Posicao** - Posições atuais na carteira
- **Operacao** - Histórico de operações
- **Cotacao** - Histórico de cotações

### Relacionamentos
- Usuario → Carteiras (1:N)
- Carteira → Posicoes (1:N)
- Carteira → Operacoes (1:N)
- Ativo → Posicoes (1:N)
- Ativo → Operacoes (1:N)
- Ativo → Cotacoes (1:N)

## 🔧 Configuração para Desenvolvimento

### Visual Studio 2022
1. Abrir `PortfolioTracker.sln`
2. Definir `PortfolioTracker.API` como projeto de inicialização
3. Pressionar F5 para executar

### Connection String
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=PortfolioTrackerDB;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true"
  }
}
```

## 📚 Documentação da API

A documentação completa da API está disponível através do Swagger UI quando a aplicação está em execução.

### Endpoints Principais
- `GET /api/ativos` - Listar todos os ativos
- `GET /api/ativos/{id}` - Obter ativo por ID
- `POST /api/ativos` - Criar novo ativo
- `PUT /api/ativos/{id}` - Atualizar ativo
- `DELETE /api/ativos/{id}` - Remover ativo

## 🧪 Testes

```bash
# Executar testes unitários
dotnet test

# Executar testes de integração
dotnet test --filter Category=Integration
```

⭐ Se este projeto foi útil para você, considere dar uma estrela no repositório! ⭐

Desenvolvido com ❤️ usando ASP.NET Core

## Contato
alexandre.trajano@gmail.com

www.linkedin.com/in/alexandre-trajano-b3417a39

