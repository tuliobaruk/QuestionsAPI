using Microsoft.AspNetCore.Mvc;
using PBIC_CloudNative.Models;
using PBIC_CloudNative.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace PBIC_CloudNative.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionController : ControllerBase
{
    private readonly QuestionService _questionService;

    public QuestionController(QuestionService questionService) => _questionService = questionService;

    [SwaggerOperation(Summary = "Recupera uma pergunta com base no ID fornecido")]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var existingQuestion = await _questionService.GetAsync(id);
        
        if (existingQuestion is null) 
        {
            return NotFound();
        }

        return Ok(existingQuestion);
    }

    [SwaggerOperation(Summary = "Recupera todas as perguntas disponíveis")]
    [HttpGet("all")]
    public async Task<IActionResult> Get()
    {
        var allQuestions = await _questionService.GetAsync();

        if (allQuestions.Any())
        {
            return Ok(allQuestions);
        }

        return NotFound();
    }

    [SwaggerOperation(Summary = "Recupera todas as perguntas com base na categoria fornecida")]
    [HttpGet("all/{category}")]
    public async Task<IActionResult> GetByCategory(string category)
    {
        var questionsByCategory = await _questionService.GetByCategoryAsync(category);

        if (questionsByCategory.Any())
        {
            return Ok(questionsByCategory);
        }

        return NotFound();
    }

    [SwaggerOperation(Summary = "Recupera uma quantidade especificada de questões de uma categoria específica")]
    [HttpGet("{category}/{count}")]
    public async Task<IActionResult> GetRandomQuestionsByCategory(string category, int count)
    {
        var randomQuestionsByCategory = await _questionService.GetRandomQuestionsByCategoryAsync(category, count);

        if (randomQuestionsByCategory.Any())
        {
            return Ok(randomQuestionsByCategory);
        }

        return NotFound();
    }

    [SwaggerOperation(Summary = "Cria uma nova pergunta no sistema")]
    [HttpPost]
    public async Task<IActionResult> Post(Question question)
    {
        await _questionService.CreateAsync(question);
        return CreatedAtAction(nameof(Get), new {id = question.Id}, question);
    }

    [SwaggerOperation(Summary = "Atualiza os detalhes de uma pergunta existente com base no ID fornecido")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, Question question)
    {
        var existingQuestion = await _questionService.GetAsync(id);

        if (existingQuestion is null)
        {
            return BadRequest();
        }

        question.Id = existingQuestion.Id;
        await _questionService.UpdateAsync(question);

        return NoContent();
    }

    [SwaggerOperation(Summary = "Exclui uma pergunta com base no ID fornecido")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var existingQuestion = await _questionService.GetAsync(id);

        if (existingQuestion is null)
        {
            return BadRequest();
        }

        await _questionService.RemoveAsync(id);

        return NoContent();
    }

    [SwaggerOperation(Summary = "Consulta o número de questões/categorias cadastradas")]
    [HttpGet("statistics")]
    public async Task<IActionResult> GetStatistics()
    {
        var totalQuestions = await _questionService.GetAsync();

        var categoryCounts = totalQuestions
            .GroupBy(q => q.Category)
            .Select(group => new
            {
                Category = group.Key,
                Count = group.Count()
            })
            .ToList();

        var statistics = new
        {
            TotalQuestions = totalQuestions.Count,
            CategoryCounts = categoryCounts
        };

        return Ok(statistics);
    }
}