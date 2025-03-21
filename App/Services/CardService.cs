using App.Services.RequestModels;
using App.Services.ResponseModels;
using Core.Repositories;


namespace App.Services;

public class CardService: ICardService
{
    private readonly ICardRepository _cardRepository;
    public CardService(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    public Task<CardResponse> AddCardAsync(AddCardRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<CardResponse> UpdateCardAsync(UpdateCardRequest request)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCardAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<CardResponse> GetCardAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CardResponse>> GetCardsAsync()
    {
        throw new NotImplementedException();
    }
}