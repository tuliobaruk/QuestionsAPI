## QuestionsAPI

A API foi desenvolvida como parte de um projeto de referência para estratégias de Cloud Native. 

Ela permite o gerenciamento de perguntas em várias categorias e níveis de dificuldade.

<br>

## Configuração do Banco de Dados MongoDB

Para configurar o banco de dados MongoDB utilizado pela API, siga os passos abaixo:

1. Abra o arquivo `appsettings.json` no seu projeto.
2. Encontre a seção `"MongoDataBase"` que possui as configurações do banco de dados.
3. Altere as configurações conforme necessário:
   - `"ConnectionString"`: O endereço do servidor MongoDB.
   - `"DatabaseName"`: O nome do banco de dados no servidor MongoDB.
   - `"CollectionName"`: O nome da coleção que armazena as questões.

Exemplo:

```json
  "MongoDataBase": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "QuestionAPI",
    "CollectionName": "Questions"
  }

```

---

</br>

## Docker Hub

A imagem Docker da aplicação está disponível no Docker Hub com as configurações de banco de dados iguais às do repositório. Você pode acessar a imagem através do link [Docker Hub](https://hub.docker.com/r/tuliobaruk/questionsapi).

Para executar a aplicação com Docker, você pode usar o seguinte comando:

**Exemplo de uso caso não deseje especificar portas**

```bash
docker run -d --name QuestionsAPI --network host tuliobaruk/questionsapi:v2.0
```

---

</br>

## Esquema de Dados da Pergunta

[Clique aqui para ver algums exemplos](https://github.com/tuliobaruk/QuestionsExample)

A API utiliza um esquema de dados específico para representar as perguntas.

Abaixo, está o esquema de dados utilizado:


```json
[
    {
        "question": "What is the primary purpose of Amazon S3 in AWS?",
        "description": null,
        "category": "AWS",
        "difficulty": "Easy",
        "answers": {
            "answer_a": "To launch EC2 instances",
            "answer_b": "To store and retrieve data",
            "answer_c": "To manage virtual networks",
            "answer_d": "To create relational databases",
            "answer_e": null,
            "answer_f": null
        },
        "correct_answer": "answer_b",
        "multiple_correct_answers": "false",
        "correct_answers": {
            "answer_a_correct": "false",
            "answer_b_correct": "true",
            "answer_c_correct": "false",
            "answer_d_correct": "false",
            "answer_e_correct": "false",
            "answer_f_correct": "false"
        },
        "explanation": null,
        "tip": null
    }
]
```
</br>

**Descrição dos Campos**:

- **question**: A pergunta em si.
- **description**: (Opcional) Uma descrição opcional para a pergunta (pode ser nulo).
- **category**: A categoria à qual a pergunta pertence (por exemplo, "AWS").
- **difficulty**: A dificuldade da pergunta (por exemplo, "Easy").
- **answers**: Um conjunto de opções de resposta, representadas como um objeto.
- **correct_answer**: A opção de resposta correta.
- **multiple_correct_answers**: Indica se há várias respostas corretas (true/false).
- **correct_answers**: Um conjunto de respostas corretas, representadas como um objeto.
- **explanation**: (Opcional) Uma explicação sobre a resposta correta (pode ser nulo).
- **tip**: (Opcional) Uma dica opcional relacionada à pergunta (pode ser nulo).

</br>

# Endpoints da API

### Recuperar uma pergunta com base no ID fornecido
Este endpoint permite recuperar uma pergunta com base no ID fornecido.


```
  GET /api/question/{id}
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `id` | `string` | **Obrigatório**. O ID da pergunta que você deseja recuperar|

</br>

#### Exemplo de Uso:

```
  GET /api/question/650a5869929a7f635afc5642
```


</br>

---

</br>

### Recuperar todas as perguntas disponíveis
Este endpoint permite recuperar todas as perguntas disponíveis.

```
  GET /api/question/all
```

</br>

#### Exemplo de Uso:

```
  GET /api/question/650a5869929a7f635afc5642
```

</br>

---

</br>

### Recuperar todas as perguntas com base na categoria fornecida
Este endpoint permite recuperar todas as perguntas com base na categoria fornecida.

```
  GET /api/question/all/{category}
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `category ` | `string` | **Obrigatório**. A categoria pela qual você deseja filtrar as perguntas|

</br>

#### Exemplo de Uso:

```
  GET /api/question/all/Linux
```

</br>

---

</br>

### Recuperar uma quantidade especificada de questões de uma categoria específica
Este endpoint permite recuperar uma quantidade especificada de questões de uma categoria específica.

```
  GET /api/question/{category}/{count}
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `category ` | `string` | **Obrigatório**. A categoria pela qual você deseja filtrar as perguntas|
| `count` | `int` | **Obrigatório**. O número de questões que você deseja recuperar

</br>

#### Exemplo de Uso:
```
  GET /api/question/Linux/5
```

</br>

---

</br>

### Criar uma nova pergunta no sistema
Este endpoint permite criar uma nova pergunta no sistema.

```
  POST /api/question
```

#### Exemplo de corpo da solicitação:

```JSON
[
    {
        "question": "What is the primary purpose of Amazon S3 in AWS?",
        "description": null,
        "category": "AWS",
        "difficulty": "Easy",
        "answers": {
            "answer_a": "To launch EC2 instances",
            "answer_b": "To store and retrieve data",
            "answer_c": "To manage virtual networks",
            "answer_d": "To create relational databases",
            "answer_e": null,
            "answer_f": null
        },
        "correct_answer": "answer_b",
        "multiple_correct_answers": "false",
        "correct_answers": {
            "answer_a_correct": "false",
            "answer_b_correct": "true",
            "answer_c_correct": "false",
            "answer_d_correct": "false",
            "answer_e_correct": "false",
            "answer_f_correct": "false"
        },
        "explanation": null,
        "tip": null
    }
]
```
---

</br>

### Atualizar os detalhes de uma pergunta existente com base no ID fornecido
Este endpoint permite atualizar os detalhes de uma pergunta existente com base no ID fornecido.

```
  PUT /api/question/{id}
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `id ` | `string` | **Obrigatório**. O ID da pergunta que você deseja atualizar|

#### Exemplo de corpo da solicitação:

```JSON
[
    {
        "question": "Which of the following is not a valid Python data type?",
        "description": null,
        "category": "Python",
        "difficulty": "Easy",
        "answers": {
            "answer_a": "Integer",
            "answer_b": "String",
            "answer_c": "List",
            "answer_d": "Map",
            "answer_e": null,
            "answer_f": null
        },
        "correct_answer": "answer_d",
        "multiple_correct_answers": "false",
        "correct_answers": {
            "answer_a_correct": "false",
            "answer_b_correct": "false",
            "answer_c_correct": "false",
            "answer_d_correct": "true",
            "answer_e_correct": "false",
            "answer_f_correct": "false"
        },
        "explanation": null,
        "tip": null
    }
]
```

</br>

---

</br>

### Excluir uma pergunta com base no ID fornecido
Este endpoint permite excluir uma pergunta com base no ID fornecido.

```
  DELETE /api/question/{id}
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `id` | `string` | **Obrigatório**. O ID da pergunta que você deseja excluir|

#### Exemplo de Uso:

```
  DELETE /api/question/650a5869929a7f635afc5642
```

---


### Consultar o número de questões/categorias cadastradas
Este endpoint permite consultar o número de questões e categorias cadastradas no sistema.

```
  GET /api/question/statistics
```

</br>

#### Exemplo de Retorno:

```JSON
[
  {
  "totalQuestions": 86,
  "categoryCounts": [
    {
      "category": "Docker",
      "count": 23
    },
    {
      "category": "Java",
      "count": 8
    },
    {
      "category": "AWS",
      "count": 10
    },
    {
      "category": "DevOps",
      "count": 8
    },
    {
      "category": "Linux",
      "count": 20
    },
    {
      "category": "Python",
      "count": 17
    }]
  }
]
```
