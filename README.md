---

# 🛒 **Cadastro de Produtos - API com MVC**

## 🎯 **Objetivo do Projeto**
A **API de Cadastro de Produtos** foi desenvolvida para permitir a **criação**, **listagem**, **atualização** e **exclusão** de produtos, com dados armazenados no **Banco de Dados SQL Server** utilizando o **Entity Framework** para interação com a base de dados. Este projeto visa fornecer uma solução simples e eficiente para o gerenciamento de produtos em um sistema.

## 🏷️ **Entidade Produto**
A **Entidade Produto** foi criada com os seguintes atributos:

- **Nome**: string 🏷️
- **Descrição**: string 📝
- **ValorProduto**: float 💰
- **DisponivelVenda**: bool 🛒

## ⚙️ **Arquitetura e Organização**
O projeto segue a **arquitetura MVC (Model-View-Controller)** e é estruturado em **3 camadas** para melhorar a manutenção e escalabilidade:

1. **Model**: Representa os dados do sistema, como a **Entidade Produto**.
2. **View**: Responsável pela interface com o usuário, exibindo as informações de maneira amigável.
3. **Controller**: Gerencia as interações entre o **Model** e a **View**, realizando as operações de CRUD (Criar, Ler, Atualizar e Deletar) no banco de dados.

### **ProdutoController**
A **ProdutoController** gerencia as ações de CRUD para os produtos. Utilizando **injeção de dependência**, ela delega as operações para serviços específicos:

- **Cadastrar Produto** ✍️
- **Atualizar Produto** 🔄
- **Listar Produtos** 📜
- **Excluir Produto** ❌

Cada serviço é responsável por uma função, mantendo o código organizado e modular. A **validação de modelo** (ModelState) é feita para garantir que os dados inseridos sejam válidos antes de realizar qualquer operação.

## 🛠️ **Serviços da API**
A API oferece as seguintes funcionalidades para gerenciar os produtos:

- **Adicionar Produtos** ➕
- **Listagem de Produtos** 📜
- **Atualizar Produtos** 🔄
- **Deletar Produto** ❌

## ⚙️ **Tecnologias Utilizadas**
- **ASP.NET Core** 🖥️
- **C#** 💻
- **SQL Server** 🗃️
- **Entity Framework** 🔧
- **MVC (Model-View-Controller)** 🎨

---
