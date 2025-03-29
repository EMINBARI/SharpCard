
using Core.Repositories;
using Core.Models;

namespace Infrastructure;

class DataBaseDeckRepository: IDeckRepository 
{
    public Task CreateAsync(Deck deck)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Deck> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Deck>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Deck deck)
    {
        throw new NotImplementedException();
    }
}