using App.Services.Contracts.Requests;
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
        if (string.IsNullOrEmpty( request.FrontSide.Text) || string.IsNullOrEmpty(request.BackSide.Text))
        {
            throw new Exception("Front and back side text must be provided");
        }

        var card = new Card (
            front: new CardSide(request.FrontSide.Text) { ImageUrl = request.FrontSide.ImgUrl }, 
            back: new CardSide (request.BackSide.Text) { ImageUrl = request.BackSide.ImgUrl }
        );

        await _cardRepository.AddAsync(card);

        return new CardResponse(card);
    }

    public async Task<CardResponse> UpdateCardAsync(UpdateCardRequest request)
    {
        var card = await _cardRepository.GetAsync(request.Id);

        if (card == null)
            throw new Exception($"Could not find card with id {request.Id}");

        if (string.IsNullOrWhiteSpace(request.FrontText) || string.IsNullOrWhiteSpace(request.BackText)){
            throw new Exception("Front and Back text must be provided");
        }

        card.Front = new CardSide(request.FrontText) 
        { 
            ImageUrl = request.ImgLink
        };

        card.Back = new CardSide(request.BackText)
        {
            ImageUrl = request.ImgLink
        }; 

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

        return cards.Select(card => new CardResponse(card));
    }
}