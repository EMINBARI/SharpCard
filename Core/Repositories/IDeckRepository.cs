using Core.Models;


namespace Core.Repositories;
public interface IDeckRepository 
{
    public Task CreateAsync(Deck deck);
    public Task UpdateAsync(Deck deck);
    public Task DeleteAsync(Guid id);
    public Task<Card> GetAsync(Guid id);
   public Task<IEnumerable<Deck>> GetAllAsync();
}