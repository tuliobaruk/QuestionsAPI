using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace PBIC_CloudNative.Models;

public class CorrectAnswers
{
    [SwaggerSchema(Description = "Resposta da alternativa A")]
    [DefaultValue(false)]
    [BsonElement("answer_a_correct")]
    public bool AnswerACorrect { get; set; }

    [SwaggerSchema(Description = "Resposta da alternativa B")]
    [DefaultValue(false)]
    [BsonElement("answer_b_correct")]
    public bool AnswerBCorrect { get; set; }

    [SwaggerSchema(Description = "Resposta da alternativa C")]
    [DefaultValue(false)]
    [BsonElement("answer_c_correct")]
    public bool AnswerCCorrect { get; set; }

    [SwaggerSchema(Description = "Resposta da alternativa D")]
    [DefaultValue(false)]
    [BsonElement("answer_d_correct")]
    public bool AnswerDCorrect { get; set; }

    [SwaggerSchema(Description = "Resposta da alternativa E")]
    [DefaultValue(false)]
    [BsonElement("answer_e_correct")]
    public bool AnswerECorrect { get; set; }

    [SwaggerSchema(Description = "Resposta da alternativa F")]
    [DefaultValue(false)]
    [BsonElement("answer_f_correct")]
    public bool AnswerFCorrect { get; set; }
}
