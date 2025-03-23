using Core.Models;
using Core.Repositories;
using System.Text.Json;

namespace Infrastructure;

public class JsonFileCardRepository : ICardRepository
{
    private readonly JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

    string FilePath { get; set; }

    int MaxId { get; set; } = 1;

    List<Card> cards = [];

    public JsonFileCardRepository(string path)
    {
        FilePath = path;

        if(!File.Exists(FilePath))
        {
            File.Create(FilePath);
        }

        string jsonStr = File.ReadAllText(FilePath);
        cards = JsonSerializer.Deserialize<List<Card>>(jsonStr) ?? [];
        MaxId = cards.Max(c => c.Id);
    }

    public Task AddAsync(Card card)
    {
        MaxId++;
        card.Id = MaxId;
        cards.Add(card);
       
        string jsonString = JsonSerializer.Serialize(cards, options);
        File.WriteAllText(FilePath, jsonString);
        
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        cards.RemoveAt(id);

        string jsonString = JsonSerializer.Serialize(cards, options);
        File.WriteAllText(FilePath, jsonString);

        return Task.CompletedTask;
    }

    public Task<IEnumerable<Card>> GetAllAsync()
    {
        return Task.FromResult(cards.AsEnumerable());
    }

    public Task<Card> GetAsync(int id)
    {
        var card = cards.Find(c => c.Id == id);

        if (card == null)
            throw new Exception($"Could not find card with id {id}");
        
        return Task.FromResult(card);
    }

    public Task UpdateAsync(Card card)
    {
        cards[cards.FindIndex(card => card?.Id == card?.Id)] = card;

        string jsonString = JsonSerializer.Serialize(cards, options);
        File.WriteAllText(FilePath, jsonString);

        return Task.CompletedTask;
    }
}