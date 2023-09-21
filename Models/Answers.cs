using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Swashbuckle.AspNetCore.Annotations;

namespace PBIC_CloudNative.Models;

public class Answers
{
    [SwaggerSchema(Description ="Sinaliza se a alternativa A é correta")]
    [BsonElement("answer_a")]
    public string? AnswerA { get; set; }

    [SwaggerSchema(Description = "Sinaliza se a alternativa B é correta")]
    [BsonElement("answer_b")]
    public string? AnswerB { get; set; }

    [SwaggerSchema(Description = "Sinaliza se a alternativa C é correta")]
    [BsonElement("answer_c")]
    public string? AnswerC { get; set; }

    [SwaggerSchema(Description = "Sinaliza se a alternativa D é correta")]
    [BsonElement("answer_d")]
    public string? AnswerD { get; set; }

    [SwaggerSchema(Description = "Sinaliza se a alternativa E é correta")]
    [BsonElement("answer_e")]
    public string? AnswerE { get; set; }

    [SwaggerSchema(Description = "Sinaliza se a alternativa F é correta")]
    [BsonElement("answer_f")]
    public string? AnswerF { get; set; }
}
