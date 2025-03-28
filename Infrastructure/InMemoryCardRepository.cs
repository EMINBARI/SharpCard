using Core.Models;
using Core.Repositories;

namespace Infrastructure;

public class InMemoryCardRepository : ICardRepository
{
    List<Card> cards = new List<Card>();

    public Task AddAsync(Card card)
    {
        cards.Add(card);
        
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        var delId = cards.FindIndex(c => c.Id == id);
        cards.RemoveAt(delId);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Card>> GetAllAsync()
    {
        return Task.FromResult(cards.AsEnumerable());
    }

    public Task<Card> GetAsync(Guid id)
    {
        var card = cards.Find(c => c.Id == id);

        if (card == null)
            throw new Exception($"Could not find card with id {id}");
        
        return Task.FromResult(card);
    }

    public Task UpdateAsync(Card card)
    {
        cards[cards.FindIndex(card => card?.Id == card?.Id)] = card;

        return Task.CompletedTask;
    }
}