# 💸 CashFlow API

[![My Skills](https://skillicons.dev/icons?i=cs,dotnet,mysql&theme=dark)](https://skillicons.dev)

API RESTful para **gestão e controle de fluxo de caixa pessoal**, desenvolvida em **.NET 10** e fundamentada nos princípios de **Clean Architecture**, **SOLID** e boas práticas de desenvolvimento de software. A solução oferece operações completas de CRUD sobre despesas financeiras e motores dedicados para geração de relatórios consolidados em formatos **Excel (`.xlsx`)** e **PDF**.

---

## 📋 Índice

- [Sobre o Projeto](#-sobre-o-projeto)
- [Funcionalidades](#-funcionalidades)
- [Tecnologias Utilizadas](#-tecnologias-utilizadas)
- [Estrutura do Projeto](#-estrutura-do-projeto)
- [Pré-requisitos](#-pré-requisitos)
- [Instalação e Execução](#-instalação-e-execução)
- [Como Usar a API](#-como-usar-a-api)
- [Endpoints](#-endpoints)
- [Exemplos com curl](#-exemplos-com-curl)
- [Testando com o Scalar](#-testando-com-o-scalar)
- [Respostas de Erro](#-respostas-de-erro)
- [Próximas Implementações](#-próximas-implementações)
- [Como Contribuir](#-como-contribuir)

---

## 💡 Sobre o Projeto

O **CashFlow** foi concebido para resolver um desafio cotidiano fundamental: o **controle financeiro e a previsibilidade de gastos**. Muitas vezes, a falta de visibilidade sobre saídas financeiras, aliada à ausência de categorização por métodos de pagamento e à dispersão de registros, dificulta o planejamento financeiro individual.

Para além de um simples CRUD de despesas, o projeto foi desenvolvido com foco em **arquitetura sustentável, alta testabilidade e separação rigorosa de responsabilidades**, simulando os padrões de exigência de aplicações corporativas modernas:

### 🎯 Proposta de Valor & Negócio
- **Consistência e Integridade Contábil:** O sistema não aceita lançamentos de despesas em datas futuras (despesas são fatos contábeis consolidados), nem valores negativos ou zerados, assegurando que o saldo e o histórico reflitam eventos financeiros reais.
- **Classificação por Meio de Pagamento:** Cada lançamento é categorizado conforme o tipo de liquidação (Dinheiro, Cartão de Crédito, Cartão de Débito, Transferência Eletrônica/Pix), permitindo análises granulares sobre hábitos de consumo.
- **Exportação Analítica Mensal:** Possibilita o fechamento do período com a geração sob demanda de relatórios prontos para uso profissional:
  - **Planilha Excel (`.xlsx`):** Dados estruturados em tabela, com formatação numérica de moedas, datas amigáveis e totalizações automáticas.
  - **Documento PDF (`.pdf`):** Relatório diagramado com layout visual agradável, paleta de cores corporativa, tabelas alinhadas e tipografia customizada (`Raleway` e `WorkSans`) embutida diretamente no assembly.

### 🏛️ Pilares de Engenharia & Arquitetura
- **Clean Architecture (Arquitetura Limpa):** O núcleo da aplicação (`Domain`) é 100% puro e agnóstico, sem referências ao Entity Framework Core ou qualquer pacote externo. As regras são orquestradas por Casos de Uso independentes em `Application`, enquanto banco de dados e drivers ficam estritamente isolados em `Infrastructure`.
- **Inversão de Dependência (DIP) & Segregação de Interfaces (ISP):** Os Casos de Uso interagem exclusivamente com contratos de repositório especializados (`IExpensesReadOnlyRepository`, `IExpensesWriteOnlyRepository`, `IExpensesUpdateOnlyRepository`), evitando o vazamento de métodos desnecessários e facilitando a criação de mocks para testes.
- **Internacionalização Nativa (i18n):** Suporte dinâmico a múltiplos idiomas (`pt-BR`, `pt-PT`, `en`, `fr`) resolvido por middleware HTTP através do header `Accept-Language`, tanto para mensagens de validação e erro quanto para textos presentes nos relatórios gerados.
- **Validação Declarativa e Fluente:** Utilização do `FluentValidation` para blindar a camada de entrada (DTOs) antes que dados inconsistentes cheguem aos Casos de Uso ou entidades de domínio.

---

## ✅ Funcionalidades

- **Registrar despesa** — cadastra título, descrição, data, valor e forma de pagamento.
- **Listar todas as despesas** — retorna lista resumida com id, título e valor.
- **Consultar despesa por ID** — retorna os dados completos de uma despesa específica.
- **Atualizar despesa** — substitui os dados de uma despesa existente.
- **Excluir despesa** — remove uma despesa pelo id.
- **Relatório Excel** — gera planilha `.xlsx` com as despesas de um determinado mês.
- **Relatório PDF** — gera documento `.pdf` estilizado com as despesas de um determinado mês.
- **Internacionalização (i18n)** — mensagens de erro retornadas no idioma informado pelo header `Accept-Language` (suporte a `en`, `pt-BR`, `pt-PT` e `fr`).

---

## 🛠 Tecnologias Utilizadas

| Tecnologia / Pacote              | Versão  | Função                                             |
| -------------------------------- | ------- | -------------------------------------------------- |
| .NET / ASP.NET Core              | 10.0    | Framework base da API                              |
| Entity Framework Core            | 9.0.0   | ORM para acesso ao banco de dados                  |
| Pomelo.EntityFrameworkCore.MySql | 9.0.0   | Provider MySQL para o EF Core                      |
| MySQL                            | 8.0.46  | Banco de dados relacional                          |
| AutoMapper                       | 16.2.0  | Mapeamento entre entidades, requests e responses   |
| FluentValidation                 | 12.1.1  | Validação declarativa das requisições              |
| ClosedXML                        | 0.105.1 | Geração de relatórios Excel (`.xlsx`)              |
| PDFsharp-MigraDoc                | 6.2.4   | Geração de relatórios PDF com layout personalizado |
| Scalar.AspNetCore                | 2.17.2  | Interface interativa de documentação da API        |
| Microsoft.AspNetCore.OpenApi     | 10.0.11 | Geração do contrato OpenAPI                        |
| xUnit                            | 2.9.3   | Framework de testes unitários                      |
| Shouldly                         | 4.3.0   | Asserções legíveis nos testes                      |
| Bogus                            | 35.6.5  | Geração de dados falsos para os testes             |

---

## 📁 Estrutura do Projeto

```text
📁 CashFlow/
├── 🧩 CashFlow.slnx                          # Arquivo de solução
│
├── 📁 src/
│   ├── 📁 CashFlow.Api/                      # Camada de apresentação (entrada HTTP)
│   │   ├── 📁 Controllers/
│   │   │   ├── 📄 ExpensesController.cs      # Endpoints de CRUD de despesas
│   │   │   └── 📄 ReportController.cs        # Endpoints de relatórios Excel e PDF
│   │   ├── 📁 Filters/
│   │   │   └── 📄 ExceptionFilter.cs         # Filtro global de exceções → traduz exceções em respostas HTTP
│   │   ├── 📁 Middleware/
│   │   │   └── 📄 CultureMiddleware.cs       # Define o locale da requisição via Accept-Language
│   │   ├── 📁 Properties/
│   │   │   └── ⚙️ launchSettings.json        # Perfis de execução (HTTP: 5024, HTTPS: 7117)
│   │   ├── ⚙️ appsettings.json               # Configurações base (logging)
│   │   ├── ⚙️ appsettings.Development.json   # Connection string do MySQL (ambiente de desenvolvimento)
│   │   ├── 🌐 CashFlow.Api.http              # Arquivo de requisições HTTP (atualmente vazio)
│   │   └── 📄 Program.cs                     # Ponto de entrada da aplicação
│   │
│   ├── 📁 CashFlow.Application/              # Camada de aplicação (casos de uso e regras de negócio)
│   │   ├── 📁 AutoMapper/
│   │   │   └── 📄 AutoMapping.cs             # Perfil de mapeamento Request ↔ Entidade ↔ Response
│   │   ├── 📁 UseCases/Expenses/
│   │   │   ├── 📄 ExpenseValidator.cs        # Validações com FluentValidation
│   │   │   ├── 📁 Register/                  # Caso de uso: registrar despesa
│   │   │   ├── 📁 GetAll/                    # Caso de uso: listar todas as despesas
│   │   │   ├── 📁 GetById/                   # Caso de uso: buscar despesa por ID
│   │   │   ├── 📁 Delete/                    # Caso de uso: excluir despesa
│   │   │   ├── 📁 Update/                    # Caso de uso: atualizar despesa
│   │   │   └── 📁 Reports/
│   │   │       ├── 📁 Excel/                 # Caso de uso: gerar relatório Excel
│   │   │       └── 📁 Pdf/                   # Caso de uso: gerar relatório PDF
│   │   │           ├── 📁 Colors/            # Helper de cores do PDF
│   │   │           ├── 📁 Fonts/             # Fontes customizadas (Raleway, WorkSans) embutidas
│   │   │           └── 📁 Image/             # Ícone do cabeçalho do PDF
│   │   └── 📄 DependencyInjectionExtension.cs # Registro dos casos de uso e AutoMapper
│   │
│   ├── 📁 CashFlow.Communication/            # Camada de contratos de comunicação (DTOs)
│   │   ├── 📁 Enums/
│   │   │   └── 📄 PaymentType.cs             # Enum de formas de pagamento
│   │   ├── 📁 Requests/
│   │   │   └── 📄 RequestRegisterExpenseJson.cs # DTO de entrada para criar/atualizar despesa (classe RequestExpenseJson)
│   │   └── 📁 Responses/
│   │       ├── 📄 ResponseErrorJson.cs        # DTO de resposta de erro
│   │       ├── 📄 ResponseExpenseJson.cs      # DTO de resposta completa de despesa
│   │       ├── 📄 ResponseExpensesJson.cs     # DTO de lista de despesas
│   │       ├── 📄 ResponseRegisterExpenseJson.cs # DTO de retorno ao registrar despesa
│   │       └── 📄 ResponseShortExpenseJson.cs # DTO resumido (id, título, valor)
│   │
│   ├── 📁 CashFlow.Domain/                   # Camada de domínio (entidades e interfaces)
│   │   ├── 📁 Entities/
│   │   │   └── 📄 Expense.cs                 # Entidade principal de despesa
│   │   ├── 📁 enum/
│   │   │   └── 📄 PaymentType.cs             # Enum de domínio de formas de pagamento
│   │   ├── 📁 Extensions/
│   │   │   └── 📄 PaymentTypeExtensions.cs   # Extensão para converter enum em texto localizado
│   │   ├── 📁 Reports/
│   │   │   ├── 📁 PaymentTypes/              # Recursos i18n para nomes das formas de pagamento
│   │   │   └── 📁 ReportGeneration/          # Recursos i18n para textos dos relatórios
│   │   └── 📁 Repositories/
│   │       ├── 📄 IUnitOfWork.cs             # Interface do padrão Unit of Work
│   │       └── 📁 Expenses/
│   │           ├── 📄 IExpensesReadOnlyRepository.cs    # Contrato de leitura
│   │           ├── 📄 IExpensesWriteOnlyRepository.cs   # Contrato de escrita/exclusão
│   │           └── 📄 IExpensesUpdateOnlyRepository.cs  # Contrato de atualização
│   │
│   ├── 📁 CashFlow.Exception/                # Camada de exceções customizadas e mensagens i18n
│   │   ├── 📁 ExceptionsBase/
│   │   │   ├── 📄 CashFlowException.cs       # Classe base abstrata
│   │   │   ├── 📄 ErrorOnValidationException.cs # Exceção de validação → HTTP 400
│   │   │   └── 📄 NotFoundException.cs        # Exceção de não encontrado → HTTP 404
│   │   └── 📁 Resources/
│   │       └── 🌍 ResourceErrorMessages.*    # Mensagens de erro em en, pt-BR, pt-PT e fr
│   │
│   └── 📁 CashFlow.Infrastructure/           # Camada de infraestrutura (EF Core, repositórios)
│       ├── 📁 DataAccess/
│       │   ├── 📄 CashFlowDbContext.cs        # DbContext: tabela `expenses`
│       │   ├── 📄 UnitOfWork.cs               # Implementação do Unit of Work
│       │   └── 📁 Repositories/
│       │       └── 📄 ExpenseRepository.cs    # Implementação dos três contratos de repositório
│       └── 📄 DependencyInjectionExtension.cs # Registro do DbContext e repositórios
│
└── 📁 tests/
    ├── 📁 CommonTestUtilities/               # Utilitários compartilhados entre os projetos de teste
    │   └── 📁 Requests/
    │       └── 🧪 RequestRegisterExpenseJsonBuilder.cs # Builder com Bogus para gerar requests válidos
    └── 📁 Validators.Test/                   # Testes unitários do validador de despesas
        └── 📁 Expenses/Register/
            └── 🧪 RegisterExpenseValidatorTests.cs     # Cenários: sucesso e erros de validação
```

---

## 📦 Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [MySQL 8.0+](https://dev.mysql.com/downloads/) ou cliente compatível (MySQL Workbench, DBeaver, etc.)

---

## 🚀 Instalação e Execução

### 1. Clone o repositório

```bash
# Windows / macOS / Linux
git clone <url-do-repositorio>
cd CashFlow
```

### 2. Configure a conexão com o banco de dados

Edite o arquivo `src/CashFlow.Api/appsettings.Development.json` com as credenciais do seu MySQL:

```json
{
  "ConnectionStrings": {
    "Connection": "Server=localhost;Database=cashflowdb;Uid=root;Pwd=SUA_SENHA;"
  }
}
```

> [!TIP]
> Para ambientes de produção, utilize **User Secrets** ou variáveis de ambiente em vez de editar o `appsettings.json` diretamente. O projeto já está configurado com `UserSecretsId`.

### 3. Crie o banco de dados e as tabelas

Execute o script SQL abaixo no seu cliente MySQL preferido (MySQL Workbench, DBeaver, linha de comando, etc.):

```sql
CREATE DATABASE IF NOT EXISTS cashflowdb;
USE cashflowdb;

CREATE TABLE IF NOT EXISTS expenses (
    Id BIGINT AUTO_INCREMENT PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    Description TEXT NULL,
    Date DATETIME NOT NULL,
    Amount DECIMAL(18, 2) NOT NULL,
    PaymentType INT NOT NULL
);
```

### 4. Execute a aplicação

```bash
# Windows / macOS / Linux
dotnet run --project src/CashFlow.Api
```

A API estará disponível em:

| Protocolo | URL                      |
| --------- | ------------------------ |
| HTTP      | `http://localhost:5024`  |
| HTTPS     | `https://localhost:7117` |

---

## 📖 Como Usar a API

### Rota base

```
http://localhost:5024
```

### Entidade `Expense` (corpo da requisição)

```json
{
  "title": "Supermercado",
  "description": "Compras do mês",
  "date": "2026-11-01T10:00:00",
  "amount": 350.75,
  "paymentType": 0
}
```

### Regras dos campos

| Campo         | Tipo         | Obrigatoriedade | Regras                                                                                                |
| ------------- | ------------ | --------------- | ----------------------------------------------------------------------------------------------------- |
| `title`       | `string`     | **Obrigatório** | Não pode ser vazio ou nulo                                                                            |
| `description` | `string`     | Opcional        | Sem restrições                                                                                        |
| `date`        | `DateTime`   | **Obrigatório** | Deve ser uma data **igual ou anterior** à data/hora atual (UTC) — despesas futuras não são permitidas |
| `amount`      | `decimal`    | **Obrigatório** | Deve ser **maior que zero**                                                                           |
| `paymentType` | `int` (enum) | **Obrigatório** | Deve ser um valor válido do enum `PaymentType` (veja tabela abaixo)                                   |

### Enum `PaymentType`

| Valor numérico | Nome                 |
| -------------- | -------------------- |
| `0`            | `Cash`               |
| `1`            | `CreditCard`         |
| `2`            | `DebitCard`          |
| `3`            | `ElectronicTransfer` |

> [!NOTE]
> A data da despesa não pode ser futura porque o sistema registra **eventos financeiros já ocorridos**. Registrar uma despesa futura antes que ela aconteça comprometeria a integridade do fluxo de caixa.

---

## 📡 Endpoints

### Despesas — `/expenses`

| Método   | Rota             | Descrição                              | Status de sucesso           |
| -------- | ---------------- | -------------------------------------- | --------------------------- |
| `POST`   | `/expenses`      | Registra uma nova despesa              | `201 Created`               |
| `GET`    | `/expenses`      | Lista todas as despesas (resumo)       | `200 OK` / `204 No Content` |
| `GET`    | `/expenses/{id}` | Busca uma despesa pelo ID              | `200 OK`                    |
| `PUT`    | `/expenses/{id}` | Atualiza todos os dados de uma despesa | `204 No Content`            |
| `DELETE` | `/expenses/{id}` | Remove uma despesa                     | `204 No Content`            |

### Relatórios — `/report`

| Método | Rota            | Descrição                            | Parâmetro                                             | Status de sucesso           |
| ------ | --------------- | ------------------------------------ | ----------------------------------------------------- | --------------------------- |
| `GET`  | `/report/excel` | Gera planilha Excel do mês informado | `month` (header, `DateOnly`, ex.: `2026-11`)          | `200 OK` / `204 No Content` |
| `GET`  | `/report/pdf`   | Gera PDF do mês informado            | `month` (query string, `DateOnly`, ex.: `2026-11-01`) | `200 OK` / `204 No Content` |

> [!NOTE]
> Os endpoints de relatório retornam `204 No Content` quando não existem despesas registradas para o mês informado.

---

## 💻 Exemplos com curl

### Registrar uma despesa

```bash
curl -X POST http://localhost:5024/expenses \
  -H "Content-Type: application/json" \
  -H "Accept-Language: pt-BR" \
  -d '{
    "title": "Supermercado",
    "description": "Compras do mês",
    "date": "2026-11-01T10:00:00",
    "amount": 350.75,
    "paymentType": 1
  }'
```

**Resposta esperada (`201 Created`):**

```json
{
  "title": "Supermercado"
}
```

---

### Listar todas as despesas

```bash
curl -X GET http://localhost:5024/expenses
```

**Resposta esperada (`200 OK`):**

```json
{
  "expenses": [
    {
      "id": 1,
      "title": "Supermercado",
      "amount": 350.75
    }
  ]
}
```

---

### Buscar despesa por ID

```bash
curl -X GET http://localhost:5024/expenses/1
```

**Resposta esperada (`200 OK`):**

```json
{
  "id": 1,
  "title": "Supermercado",
  "description": "Compras do mês",
  "date": "2026-11-01T10:00:00",
  "amount": 350.75,
  "paymentType": 1
}
```

---

### Atualizar uma despesa

```bash
curl -X PUT http://localhost:5024/expenses/1 \
  -H "Content-Type: application/json" \
  -d '{
    "title": "Supermercado Atualizado",
    "description": "Compras de novembro",
    "date": "2026-11-01T10:00:00",
    "amount": 420.00,
    "paymentType": 2
  }'
```

**Resposta esperada (`204 No Content`):** corpo vazio.

---

### Excluir uma despesa

```bash
curl -X DELETE http://localhost:5024/expenses/1
```

**Resposta esperada (`204 No Content`):** corpo vazio.

---

### Gerar relatório Excel

```bash
curl -X GET http://localhost:5024/report/excel \
  -H "month: 2026-11-01" \
  --output relatorio-2026-11.xlsx
```

---

### Gerar relatório PDF

```bash
curl -X GET "http://localhost:5024/report/pdf?month=2026-11-01" \
  --output relatorio-2026-11.pdf
```

---

## 🧪 Testando com o Scalar

Ao rodar a aplicação em ambiente de desenvolvimento, a documentação interativa fica disponível em:

```
http://localhost:5024/scalar
```

O Scalar lê automaticamente o contrato OpenAPI gerado pelo `Microsoft.AspNetCore.OpenApi` e permite executar todas as requisições diretamente pelo navegador.

---

## ❌ Respostas de Erro

Todos os erros retornam o seguinte formato JSON:

```json
{
  "errorMessages": ["Mensagem de erro aqui"]
}
```

### Tabela de erros

| Situação                      | Status HTTP                 | Exemplo de mensagem (`pt-BR`)                       |
| ----------------------------- | --------------------------- | --------------------------------------------------- |
| Título não informado          | `400 Bad Request`           | `"O título é obrigatório."`                         |
| Valor igual ou menor que zero | `400 Bad Request`           | `"O valor deve ser maior que zero."`                |
| Data no futuro                | `400 Bad Request`           | `"As despesas não podem ser referentes ao futuro."` |
| Forma de pagamento inválida   | `400 Bad Request`           | `"O tipo de pagamento é inválido."`                 |
| Despesa não encontrada        | `404 Not Found`             | `"Despesa não encontrada."`                         |
| Erro interno inesperado       | `500 Internal Server Error` | `"Erro desconhecido"`                               |

> [!TIP]
> As mensagens de erro são internacionalizadas. Envie o header `Accept-Language` com `pt-BR`, `pt-PT`, `fr` ou `en` para receber a mensagem no idioma desejado. O idioma padrão (quando o header está ausente ou inválido) é `en`.

---

## 🔭 Ideias de Próximas Implementações

- [ ] Autenticação e autorização de usuários (JWT)
- [ ] Categorização de despesas
- [ ] Paginação na listagem de despesas
- [ ] Testes de integração e de camada de aplicação
- [ ] Suporte a Docker e Docker Compose

---

## 🤝 Como Contribuir

1. Faça um **fork** do repositório.
2. Crie uma branch para a sua feature:
   ```bash
   git checkout -b feature/minha-feature
   ```
3. Faça o **commit** das suas alterações:
   ```bash
   git commit -m "feat: adiciona minha feature"
   ```
4. Faça o **push** para a sua branch:
   ```bash
   git push origin feature/minha-feature
   ```
5. Abra um **Pull Request** explicando o que foi alterado e por quê.

> Certifique-se de que todos os testes unitários existentes continuam passando antes de abrir o PR:
>
> ```bash
> dotnet test
> ```