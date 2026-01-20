# 🚢 Desafio Técnico Backend – Diagnóstico do Submarino

## 📌 Objetivo

Calcular o consumo de energia de um submarino a partir de um relatório de diagnóstico contendo números binários, conforme especificação do desafio.

A solução foi desenvolvida com foco em **clareza**, **organização arquitetural**, **boas práticas** e **testabilidade**, simulando um ambiente real de desenvolvimento profissional.

---

## 🛠 Tecnologias Utilizadas

* **.NET 8 (LTS)**
* **C#**
* **ASP.NET Core Web API**
* **xUnit** (testes unitários)
* **FluentAssertions**
* **Swagger / OpenAPI**

---

## 🏗 Arquitetura

A aplicação segue uma **Clean Architecture simplificada**, com separação clara de responsabilidades:

```
/src
 ├── Submarine.Diagnostics.Api          # Camada de apresentação (API REST)
 ├── Submarine.Diagnostics.Application  # Casos de uso / regras de negócio
 ├── Submarine.Diagnostics.Domain       # Domínio puro
 └── Submarine.Diagnostics.Tests        # Testes unitários
```

### Motivações

* Facilita manutenção e evolução
* Permite fácil adaptação para outros tipos de interface (Console, API, Worker)
* Código altamente testável

---

## 📐 Padrões e Princípios Utilizados

* **Clean Architecture (adaptada)**
* **Use Case / Application Service**
* **SOLID (SRP, DIP)**
* **DTO para entrada de dados (API Boundary)**
* **FluentValidation para validações de entrada**
* **Imutabilidade com records**
* **Testes unitários focados em regras de negócio**

---

## ⚙️ Algoritmo Utilizado

1. A API recebe um **DTO (`DiagnosticReportRequest`)** contendo o relatório binário
2. As validações são executadas automaticamente via **FluentValidation**
3. O Controller delega o processamento ao **Use Case**
4. Para cada posição do bit:

   * Conta a ocorrência de `0` e `1`
   * O bit mais comum compõe a **taxa Gama**
   * O bit menos comum compõe a **taxa Épsilon**
5. Os valores binários são convertidos para decimal
6. O consumo de energia é calculado multiplicando Gama × Épsilon

---

## 🧪 Testes

Os testes unitários validam:

* Cálculo correto da taxa Gama
* Cálculo correto da taxa Épsilon
* Resultado final conforme exemplo oficial do desafio

---

## ▶️ Como Executar

### API

````bash
dotnet run --project src/Submarine.Diagnostics.Api
```bash
dotnet run --project src/Submarine.Diagnostics.Api
````

Acesse:

```
https://localhost:5001/swagger
```

---

## 📥 Exemplo de Requisição

````json
POST /api/diagnostics/power-consumption
{
  "report": [
    "00100",
    "11110",
    "10110",
    "10111",
    "10101",
    "01111",
    "00111",
    "11100",
    "10000",
    "11001",
    "00010",
    "01010"
  ]
}
```json
POST /api/diagnostics/power-consumption
[
  "00100",
  "11110",
  "10110",
  "10111",
  "10101",
  "01111",
  "00111",
  "11100",
  "10000",
  "11001",
  "00010",
  "01010"
]
````

---

## 📤 Exemplo de Resposta

````json
{
  "gammaRate": 22,
  "epsilonRate": 9,
  "consumption": 198
}
```json
{
  "gammaRate": 22,
  "epsilonRate": 9,
  "consumption": 198
}
````

---

## 👨‍💻 Autor

Desafio desenvolvido com foco em boas práticas de engenharia de software.