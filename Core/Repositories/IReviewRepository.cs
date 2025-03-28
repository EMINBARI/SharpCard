using Core.Models;

namespace Core.Repositories;

public interface IReviewRepository
{
    public Task CreateAsync(Review review);
    public Task UpdateAsync(Review review);
    public Task DeleteAsync(Guid id);
    public Task<Review> GetAsync(Guid id);
    public Task<IEnumerable<Review>> GetAllAsync();
}