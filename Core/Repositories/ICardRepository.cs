using Core.Models;


namespace Core.Repositories;
public interface ICardRepository 
{
    public Task AddAsync(Card card);
    public Task UpdateAsync(Card card);
    public Task DeleteAsync(Guid id);
    public Task<Card> GetAsync(Guid id);
   public Task<IEnumerable<Card>> GetAllAsync();
}