using Core.Models;


namespace Core.Repositories;
public interface ICardRepository 
{
    public Task AddAsync(Card card);
    public Task UpdateAsync(Card card);
    public Task DeleteAsync(int id);
    public Task<Card?> GetAsync(int id);
   public Task<IEnumerable<Card?>> GetAllAsync();
}