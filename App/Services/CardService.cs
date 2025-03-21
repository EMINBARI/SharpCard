using App.Services.RequestModels;
using App.Services.ResponseModels;
using Core.Models;
using Core.Repositories;


namespace App.Services;

public class CardService: ICardService
{
    private readonly ICardRepository _cardRepository;
    public CardService(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    public async Task<CardResponse> AddCardAsync(AddCardRequest request)
    {
        var card = new Card (
            front: new CardSide(request.FrontText, request.ImgLink), 
            back: new CardSide (request.BackText, request.ImgLink)
        );
        await _cardRepository.AddAsync(card);

        return new CardResponse(card);
    }

    public async Task<CardResponse> UpdateCardAsync(UpdateCardRequest request)
    {
        var card = await _cardRepository.GetAsync(request.Id);

        if (card == null)
            throw new Exception($"Could not find card with id {request.Id}");
        
        card.Front = new CardSide(
            request.FrontText ?? card.Front.Text, 
            request.ImgLink ?? card.Front.ImageUrl
        );

        card.Back = new CardSide(
            request.BackText ?? card.Back.Text, 
            request.ImgLink ?? card.Back.ImageUrl
        ); 

        await _cardRepository.UpdateAsync(card);

        return new CardResponse(card);
    }

    public async Task DeleteCardAsync(int id)
    {
        await _cardRepository.DeleteAsync(id);
    }

    public async Task<CardResponse> GetCardAsync(int id)
    {
        var card = await _cardRepository.GetAsync(id);

        if (card == null)
            throw new Exception($"Could not find a Card with given id = {id}");

        return new CardResponse(card);
    }

    public async Task<IEnumerable<CardResponse>> GetCardsAsync()
    {
        var cards = await _cardRepository.GetAllAsync();
        return cards.Select(card => new CardResponse(card ?? throw new Exception("No cards found")));
    }
}