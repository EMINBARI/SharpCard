using Core.Models;
using Core.Repositories;
using System.Text.Json;

namespace Infrastructure;

public class JsonFileCardRepository : ICardRepository
{
    private readonly JsonSerializerOptions _options = new JsonSerializerOptions { WriteIndented = true };
    private readonly string _filePath;
    private List<Card> _cards = [];

    public JsonFileCardRepository(string path)
    {
        _filePath = path;

        if(!File.Exists(_filePath))
        {
            try
            {
                File.Create(_filePath).Dispose();
            }
            catch (Exception ex)
            {
                throw new IOException($"Failed to create the file at {_filePath}.", ex);
            }
        }

        string jsonStr = File.ReadAllText(_filePath);
        _cards = JsonSerializer.Deserialize<List<Card>>(jsonStr) ?? [];
    }

    public async Task AddAsync(Card card)
    {
        _cards.Add(card);
       
        string jsonString = JsonSerializer.Serialize(_cards, _options);
        await File.WriteAllTextAsync(_filePath, jsonString);
    }

    public async Task DeleteAsync(Guid id)
    {
        var delId = _cards.FindIndex(c => c.Id == id);
        _cards.RemoveAt(delId);

        string jsonString = JsonSerializer.Serialize(_cards, _options);
        await File.WriteAllTextAsync(_filePath, jsonString);
    }

    public Task<IEnumerable<Card>> GetAllAsync()
    {
        return Task.FromResult(_cards.AsEnumerable());
    }

    public Task<Card> GetAsync(Guid id)
    {
        var card = _cards.Find(c => c.Id == id);

        if (card == null)
            throw new Exception($"Could not find card with id {id}");
        
        return Task.FromResult(card);
    }

    public async Task UpdateAsync(Card card)
    {
        _cards[_cards.FindIndex(card => card?.Id == card?.Id)] = card;

        string jsonString = JsonSerializer.Serialize(_cards, _options);
        await File.WriteAllTextAsync(_filePath, jsonString);
    }
}