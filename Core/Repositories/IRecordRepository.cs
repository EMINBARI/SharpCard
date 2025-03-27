using Core.Models;


namespace Core.Repositories;
public interface IRecordRepository 
{
    public Task CreateAsync(Record record);
    public Task UpdateAsync(Record record);
    public Task DeleteAsync(Guid id);
    public Task<Card> GetAsync(Guid id);
   public Task<IEnumerable<Record>> GetAllAsync();
}