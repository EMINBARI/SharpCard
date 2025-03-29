using App.Services.DeckService.Contracts;

namespace App.Services;

public interface IDeckService
{
    public Task<DeckResponse> AddDeckAsync(AddDeckRequest request);
    public Task<DeckResponse> UpdateDeckAsync(UpdateDeckRequest request);
    public Task DeleteDeckAsync(Guid id);
    public Task<DeckResponse> GetDeckAsync(Guid id);
    public Task<IEnumerable<DeckResponse>> GetDecksAsync();
}


