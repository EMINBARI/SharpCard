using Core.Models;
using Core.Repositories;

namespace Infrastructure;

public class InMemoryCardRepository : ICardRepository
{
    List<Card?> cards = new List<Card?>();
    int MaxId { get; set; } = 1;

    public Task AddAsync(Card card)
    {
        card.Id = MaxId;
        cards.Add(card);
        MaxId++;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        cards.RemoveAt(id);
        MaxId--;
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Card?>> GetAllAsync()
    {
        return Task.FromResult(cards.AsEnumerable());
    }

    public Task<Card?> GetAsync(int id)
    {
        return Task.FromResult(cards.Find(c => c?.Id == id));
    }

    public Task UpdateAsync(Card card)
    {
        cards[cards.FindIndex(card => card?.Id == card?.Id)] = card;

        return Task.CompletedTask;
    }
}