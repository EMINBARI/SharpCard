using App.Services.Contracts.Requests;
using App.Services.ResponseModels;

namespace App.Services;

public interface ICardService
{
    public Task<CardResponse> AddCardAsync(AddCardRequest request);
    public Task<CardResponse> UpdateCardAsync(UpdateCardRequest request);
    public Task DeleteCardAsync(int id);
    public Task<CardResponse> GetCardAsync(int id);
    public Task<IEnumerable<CardResponse>> GetCardsAsync();
}


