using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace QuestionsAPI.Models;

public class Question
{
    [SwaggerSchema(Description = "String de 24 caracteres gerado automaticamente", ReadOnly = true)]
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [SwaggerSchema(Description ="Pergunta")]
    [BsonElement("question")]
    public string? question { get; set; }

    [SwaggerSchema(Description = "Descrição da pergunta")]
    [BsonElement("description")]
    public string? Description { get; set; }

    [SwaggerSchema(Description = "Categoria da pergunta")]
    [BsonElement("category")]
    public string? Category { get; set; }

    [SwaggerSchema(Description = "Dificuldade da pergunta")]
    [BsonElement("difficulty")]
    public string? Difficulty { get; set; }

    [SwaggerSchema(Description = "Alternativas da pergunta")]
    [BsonElement("answers")]
    public Answers? Answers { get; set; }

    [SwaggerSchema(Description = "Alternativa correta")]
    [BsonElement("correct_answer")]
    public string? CorrectAnswer { get; set; }

    [DefaultValue(false)]
    [SwaggerSchema(Description = "Se a pergunta é multipla escolha")]
    [BsonElement("multiple_correct_answers")]
    public bool MultipleCorrectAnswers { get; set; }

    [SwaggerSchema(Description = "Respostas Corretas se for Multipla Escolha")]
    [BsonElement("correct_answers")]
    public CorrectAnswers? CorrectAnswers { get; set; }

    [SwaggerSchema(Description = "Explicação da resposta correta")]
    [BsonElement("explanation")]
    public string? Explanation { get; set; }

    [SwaggerSchema(Description = "Dica sobre a resposta")]
    [BsonElement("tip")]
    public string? Tip { get; set; }

}
