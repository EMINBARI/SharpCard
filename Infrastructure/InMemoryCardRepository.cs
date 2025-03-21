using Core.Models;
using Core.Repositories;

namespace Infrastructure;

public class InMemoryCardRepository : ICardRepository
{
    static List<Card?> cards = new List<Card?>();

    public Task AddAsync(Card card)
    {
        cards.Add(card);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        cards.RemoveAt(id);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Card?>> GetAllAsync()
    {
        return Task.FromResult(cards.AsEnumerable());
    }

    public Task<Card?> GetAsync(int id)
    {
        return Task.FromResult(cards[id]);
    }

    public Task UpdateAsync(Card card)
    {
        cards[card.Id] = card;
        return Task.CompletedTask;
    }
}