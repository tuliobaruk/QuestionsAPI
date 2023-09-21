
## Documentação da API
API criada como parte do desenvolvimento de uma aplicação de referência para experimentação de estratégias para Cloud Native.


### Recupera uma pergunta com base no ID fornecido
Este endpoint permite recuperar uma pergunta com base no ID fornecido.


```http
  GET /api/question/{id}
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `id` | `string` | **Obrigatório**. O ID da pergunta que você deseja recuperar|

#### Exemplo de Uso:
```http
  GET /api/question/650a5869929a7f635afc5642
```

---
---
---
---
---
---

### Recupera todas as perguntas disponíveis
Este endpoint permite recuperar todas as perguntas disponíveis.

```http
  GET /api/question/all
```

#### Exemplo de Uso:
```http
  GET /api/question/650a5869929a7f635afc5642
```

---
---
---
---
---
---

### Recupera todas as perguntas com base na categoria fornecida
Este endpoint permite recuperar todas as perguntas com base na categoria fornecida.

```http
  GET /api/question/all/{category}
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `category ` | `string` | **Obrigatório**. A categoria pela qual você deseja filtrar as perguntas|

#### Exemplo de Uso:
```http
  GET /api/question/all/Linux
```

---
---
---
---
---
---

### Recupera uma quantidade especificada de questões de uma categoria específica
Este endpoint permite recuperar uma quantidade especificada de questões de uma categoria específica.

```http
  GET /api/question/{category}/{count}
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `category ` | `string` | **Obrigatório**. A categoria pela qual você deseja filtrar as perguntas|
| `count` | `int` | **Obrigatório**. O número de questões que você deseja recuperar

#### Exemplo de Uso:
```http
  GET /api/question/Linux/5
```

---
---
---
---
---
---

### Cria uma nova pergunta no sistema
Este endpoint permite criar uma nova pergunta no sistema.

```http
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
---
---
---
---
---

### Atualiza os detalhes de uma pergunta existente com base no ID fornecido
Este endpoint permite atualizar os detalhes de uma pergunta existente com base no ID fornecido.

```http
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

---
---
---
---
---
---

### Exclui uma pergunta com base no ID fornecido
Este endpoint permite excluir uma pergunta com base no ID fornecido.

```http
  DELETE /api/question/{id}
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `id` | `string` | **Obrigatório**. O ID da pergunta que você deseja excluir|

#### Exemplo de Uso:
```http
  DELETE /api/question/650a5869929a7f635afc5642
```

---
---
---
---
---
---

### Consulta o número de questões/categorias cadastradas
Este endpoint permite consultar o número de questões e categorias cadastradas no sistema.

```http
  GET /api/question/statistics
```

#### Exemplo de Retorno:

```JSON
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
    }
  ]
}
```