using App.Services.Contracts.Requests;
using App.Services.ResponseModels;

namespace App.Services;

public interface ICardService
{
    public Task<CardResponse> AddCardAsync(AddCardRequest request);
    public Task<CardResponse> UpdateCardAsync(UpdateCardRequest request);
    public Task DeleteCardAsync(Guid id);
    public Task<CardResponse> GetCardAsync(Guid id);
    public Task<IEnumerable<CardResponse>> GetCardsAsync();
}


