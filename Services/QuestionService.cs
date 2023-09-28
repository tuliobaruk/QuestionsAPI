using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using QuestionsAPI.Configurations;
using QuestionsAPI.Models;

namespace QuestionsAPI.Services;

public class QuestionService
{
    private readonly IMongoCollection<Question> _questionCollection;

    public QuestionService(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
        var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
        _questionCollection = mongoDb.GetCollection<Question>(databaseSettings.Value.CollectionName);
    }

    public async Task<List<Question>> GetAsync() => 
        await _questionCollection.Find(_ => true).ToListAsync();

    public async Task<Question> GetAsync(string id) => 
        await _questionCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Question question) => 
        await _questionCollection.InsertOneAsync(question);

    public async Task UpdateAsync(Question question) => 
        await _questionCollection.ReplaceOneAsync(x => x.Id == question.Id, question);

    public async Task RemoveAsync(string id) =>
        await _questionCollection.DeleteOneAsync(x=>x.Id == id);

    public async Task<List<Question>> GetByCategoryAsync(string category) =>
        await _questionCollection.Find(x => x.Category == category).ToListAsync();

    public async Task<List<Question>> GetRandomQuestionsByCategoryAsync(string category, int count)
    {
        var pipeline = new[]
        {
        new BsonDocument("$match", new BsonDocument("category", category)),
        new BsonDocument("$sample", new BsonDocument("size", count))
    };

        var aggregation = _questionCollection.Aggregate<Question>(pipeline);

        var randomQuestionsByCategory = await aggregation.ToListAsync();

        return randomQuestionsByCategory;
    }

}
