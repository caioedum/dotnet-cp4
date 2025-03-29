# **Web API - Gerenciamento de Brinquedos**

Esta é uma Web API desenvolvida em .NET 8 para gerenciar brinquedos. A API permite realizar operações CRUD (Create, Read, Update, Delete) em uma tabela de brinquedos.

---

## **Endpoints**

### **1. Listar todos os brinquedos**

- **Método:** `GET`
- **Endpoint:** `/api/brinquedos`
- **Descrição:** Retorna todos os brinquedos cadastrados.
- **Exemplo de Resposta:**

```json
[
    {
        "id_brinquedo": 1,
        "nome_brinquedo": "Carrinho de Controle Remoto",
        "tipo_brinquedo": "Eletrônico",
        "classificacao": "6+",
        "tamanho": "Médio",
        "preco": 149.90
    },
    {
        "id_brinquedo": 2,
        "nome_brinquedo": "Boneca Princesa",
        "tipo_brinquedo": "Boneca",
        "classificacao": "3+",
        "tamanho": "Pequeno",
        "preco": 89.90
    }
]
```


---

### **2. Buscar um brinquedo por ID**

- **Método:** `GET`
- **Endpoint:** `/api/brinquedos/{id}`
- **Descrição:** Retorna um brinquedo específico pelo ID.
- **Parâmetro:**
    - `id` (obrigatório): O ID do brinquedo.
- **Exemplo de Resposta (Sucesso):**

```json
{
    "id_brinquedo": 1,
    "nome_brinquedo": "Carrinho de Controle Remoto",
    "tipo_brinquedo": "Eletrônico",
    "classificacao": "6+",
    "tamanho": "Médio",
    "preco": 149.90
}
```

- **Exemplo de Resposta (Erro - Não Encontrado):**

```json
{
    "mensagem": "Brinquedo não encontrado."
}
```


---

### **3. Criar um novo brinquedo**

- **Método:** `POST`
- **Endpoint:** `/api/brinquedos`
- **Descrição:** Cria um novo brinquedo. O ID será gerado automaticamente.
- **Corpo da Requisição:**

```json
{
    "nome_brinquedo": "Pista de Carrinhos Looping",
    "tipo_brinquedo": "Eletrônico",
    "classificacao": "7+",
    "tamanho": "Grande",
    "preco": 249.90
}
```

- **Exemplo de Resposta (Sucesso):**

```json
{
    "id_brinquedo": 3,
    "nome_brinquedo": "Pista de Carrinhos Looping",
    "tipo_brinquedo": "Eletrônico",
    "classificacao": "7+",
    "tamanho": "Grande",
    "preco": 249.90
}
```

- **Validações:**
    - `nome_brinquedo`: Obrigatório, máximo de 100 caracteres.
    - `tipo_brinquedo`: Obrigatório, máximo de 50 caracteres.
    - `preco`: Obrigatório, deve ser maior que zero.

---

### **4. Atualizar um brinquedo existente**

- **Método:** `PUT`
- **Endpoint:** `/api/brinquedos/{id}`
- **Descrição:** Atualiza os dados de um brinquedo existente.
- **Parâmetro:**
    - `id` (obrigatório): O ID do brinquedo a ser atualizado.
- **Corpo da Requisição:**

```json
{
    "id_brinquedo": 3,
    "nome_brinquedo": "Pista de Carrinhos com Looping Atualizada",
    "tipo_brinquedo": "Eletrônico",
    "classificacao": "7+",
    "tamanho": "Grande",
    "preco": 299.90
}
```

- **Exemplo de Resposta (Sucesso):** Código HTTP `204 No Content`.
- **Exemplo de Resposta (Erro - Não Encontrado):**

```json
{
    "mensagem": "Brinquedo não encontrado."
}
```


---

### **5. Excluir um brinquedo**

- **Método:** `DELETE`
- **Endpoint:** `/api/brinquedos/{id}`
- **Descrição:** Exclui um brinquedo pelo ID.
- **Parâmetro:**
    - `id` (obrigatório): O ID do brinquedo a ser excluído.
- **Exemplo de Resposta (Sucesso):** Código HTTP `204 No Content`.
- **Exemplo de Resposta (Erro - Não Encontrado):**

```json
{
    "mensagem": "Brinquedo não encontrado."
}
```


---

## **Exemplo de JSON para POST**

Aqui está um exemplo completo para criar um novo brinquedo:

```json
{
    "nome_brinquedo": "Kit de Pintura Infantil",
    "tipo_brinquedo": "Arte e Artesanato",
    "classificacao": null,
    "tamanho": null,
    "preco": 79.99
}
```

---

## **Como Executar o Projeto**

1. Clone o repositório:

```bash
git clone https://github.com/dotnet-cp4.git
cd dotnet-cp4
```

2. Configure a *connection string* no arquivo `appsettings.json`:

```json
{
    "ConnectionStrings": {
        "OracleConnection": "Data Source=oracle.fiap.com.br:1521/ORCL;User Id=rm554025;Password=010204;"
    }
}
```

3. Execute o projeto:

```bash
dotnet run
```

4. Acesse o Swagger UI para testar os endpoints:

```
https://localhost:7221/swagger/index.html
```


---

## **Integrantes do Grupo**

| Nome Completo | RM |
| :-- | :-- |
| Caio Eduardo Nascimento Martins | RM554025 |
| Julia Mariano Barsotti Ferreira | RM552713 |
| Leonardo Gaspar Saheb | RM553383 |
| Thiago Melo Carrillo | RM553565 |
