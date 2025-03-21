namespace App.Services;
using Core.Models;
using App.Services.RequestModels;
using App.Services.ResponseModels;

public interface ICardService
{
    public Task<CardResponse> AddCardAsync(AddCardRequest request);
    public Task<CardResponse> UpdateCardAsync(UpdateCardRequest request);
    public Task DeleteCardAsync(int id);
    public Task<CardResponse> GetCardAsync(int id);
    public Task<IEnumerable<CardResponse>> GetCardsAsync();
}


