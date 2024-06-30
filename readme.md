# Investment Portfolio Management

O Investment Portfolio Management é um sistema dedicado à gestão de produtos financeiros, especializado na compra e venda de fundos imobiliários. Além de facilitar essas transações, o sistema oferece funcionalidades avançadas para os gestores da plataforma. Eles têm a capacidade não apenas de criar novos produtos, mas também de atualizá-los ou remover produtos existentes conforme necessário.

Uma das características distintivas do sistema é a automação no envio de e-mails. Administradores de produtos recebem notificações automáticas sobre produtos adquiridos que estão próximos do vencimento. Isso garante que eles estejam sempre informados e possam agir proativamente, garantindo uma gestão eficiente e oportuna dos investimentos.

# Como rodar o projeto?

## Passo 1: Preparação do Ambiente

### 1. Instalação do Visual Studio

Certifique-se de ter o Visual Studio instalado. Você pode baixá-lo através do [site oficial da Microsoft](https://visualstudio.microsoft.com/).

### 2. Configuração do Projeto

-   Clonar este projeto
-  Abrir o solution do projeto no Visual Studio Intalado

### 3. Aplicação das Migrations

No terminal ou prompt de comando, navegue até o diretório do seu projeto onde está localizado o contexto de dados (`DataBaseContextApplication`). Execute o seguinte comando para aplicar as migrations:

    dotnet ef migrations add NomeDaMigration
    
### Passo 4: Rodando a Aplicação

-   No Visual Studio, pressione `F5` ou clique em "Iniciar" para rodar a aplicação.
-   Utilize ferramentas como Postman, Insomnia ou um navegador(via swagger) para testar os endpoints da sua API.

# Como utilizar?

## MeusInvesitimentos

### Comprar Investimento

**Descrição:** Realiza a compra de um fundo de investimento.

-   **Método HTTP:** POST
-   **URL:** `/api/MeusInvestimentos/comprar`
-   **Corpo da Requisição:**
    
    json
    
    Copiar código
    
    `{
      "Id": 1,
      "Quantidade": 10
    }` 
    
-   **Respostas:**
    -   `200 OK` - Operação realizada com sucesso.
    -   `500 Internal Server Error` - Erro interno ao comprar o investimento.

### Vender Investimento

**Descrição:** Realiza a venda de um fundo de investimento.

-   **Método HTTP:** POST
-   **URL:** `/api/MeusInvestimentos/vender`
-   **Parâmetros da Requisição:**
    -   `id` (int) - ID do investimento a ser vendido.
    -   `quantidadeVenda` (int) - Quantidade a ser vendida.
    -   `precoVenda` (decimal) - Preço unitário de venda.
-   **Respostas:**
    -   `200 OK` - Operação realizada com sucesso.
    -   `500 Internal Server Error` - Erro interno ao vender o investimento.

### Extrato de Investimentos

**Descrição:** Consulta o extrato de investimentos dentro de um intervalo de datas.

-   **Método HTTP:** GET
-   **URL:** `/api/MeusInvestimentos/extrato_investimentos`
-   **Parâmetros da Requisição:**
    -   `dataInicio` (DateTime) - Data de início do período.
    -   `dataFim` (DateTime) - Data de fim do período.
    -   `iniciarDe` (int) - Índice de página inicial para paginação.
    -   `tamanhoPagina` (int) - Tamanho da página para paginação.
-   **Respostas:**
    -   `200 OK` - Retorna uma lista de investimentos no período especificado.
    -   `500 Internal Server Error` - Erro interno ao consultar os investimentos.

### Consultar Investimento por ID

**Descrição:** Consulta detalhes de um investimento específico pelo ID.

-   **Método HTTP:** GET
-   **URL:** `/api/MeusInvestimentos/consultar_investimento/{id}`
-   **Parâmetros da URL:**
    -   `id` (int) - ID do investimento a ser consultado.
-   **Respostas:**
    -   `200 OK` - Retorna detalhes do investimento solicitado.
    -   `500 Internal Server Error` - Erro interno ao consultar o investimento.


## Gestao Produtos

### Criar Produto

**Descrição:** Cria um novo fundo imobiliário.

-   **Método HTTP:** POST
-   **URL:** `/api/GestaoProdutos/criar_produto`
-   **Corpo da Requisição:**
    
    json
    
    Copiar código
    
    `{
      "nome": "Nome do Produto",
      "descricao": "Descrição do Produto",
      "valorInicial": 100000.00,
      "dataInicio": "2024-07-01",
      "dataFim": "2024-12-31"
    }` 
    
-   **Respostas:**
    -   `201 Created` - Produto criado com sucesso. Retorna detalhes do produto criado.
    -   `500 Internal Server Error` - Erro interno ao criar o produto.

### Atualizar Produto por ID

**Descrição:** Atualiza as informações de um produto imobiliário existente.

-   **Método HTTP:** PUT
-   **URL:** `/api/GestaoProdutos/atualizar_produto/{id}`
-   **Parâmetros da URL:**
    -   `id` (int) - ID do produto a ser atualizado.
-   **Corpo da Requisição:**
    
    json
    
    Copiar código
    
    `json
	{
	  "nomeFundo": "string",
	  "codigoNegociacao": 0,
	  "corretoraExcutora": 0,
	  "preco": 0,
	  "quantidade": 0,
	  "descricao": "string"
	}
	` 
    
-   **Respostas:**
    -   `200 OK` - Produto atualizado com sucesso.
    -   `500 Internal Server Error` - Erro interno ao atualizar o produto.

### Excluir Produto por ID

**Descrição:** Remove um produto imobiliário existente.

-   **Método HTTP:** DELETE
-   **URL:** `/api/GestaoProdutos/remover_produto/{id}`
-   **Parâmetros da URL:**
    -   `id` (int) - ID do produto a ser removido.
-   **Respostas:**
    -   `200 OK` - Produto removido com sucesso.
    -   `500 Internal Server Error` - Erro interno ao remover o produto.


### Listar Produtos Disponíveis

**Descrição:** Lista os produtos imobiliários disponíveis com suporte para paginação.

-   **Método HTTP:** GET
-   **URL:** `/api/GestaoProdutos`
-   **Parâmetros da Requisição:**
    -   `iniciarDe` (int) - Índice do primeiro item a ser recuperado na paginação.
    -   `tamanhoPagina` (int) - Número de itens por página.
-   **Respostas:**
    -   `200 OK` - Retorna uma lista paginada de produtos imobiliários disponíveis.
    -   `500 Internal Server Error` - Erro interno ao consultar produtos disponíveis.

