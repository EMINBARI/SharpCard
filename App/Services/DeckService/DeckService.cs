using App.Services.DeckService.Contracts;
using Core.Repositories;
using Core.Models;
namespace App.Services.DeckService;

public class DeckService : IDeckService
{
    private readonly IDeckRepository _deckRepository;

    public DeckService(IDeckRepository deckRepository)
    {
        _deckRepository = deckRepository;
    }

    public async Task<DeckResponse> AddDeckAsync(AddDeckRequest request)
    {
        var deck = new Deck(id: Guid.NewGuid(), name: request.Name)
        {
            Description = request.Description,
            Name = request.Name,
        };

        await _deckRepository.CreateAsync(deck);

        return new DeckResponse(deck);
    }

    public async Task<DeckResponse> UpdateDeckAsync(UpdateDeckRequest request)
    {
        Deck deck = await _deckRepository.GetAsync(request.Id);

        deck.Description = request.Description;
        deck.Name = request.Name;
        deck.ModifiedAt = DateTimeOffset.UtcNow;

        await _deckRepository.UpdateAsync(deck);

        return new DeckResponse(deck);    
    }

    public async Task DeleteDeckAsync(Guid id)
    {
        await _deckRepository.DeleteAsync(id);
    }

    public async Task<DeckResponse> GetDeckAsync(Guid id)
    {
        var deck = await _deckRepository.GetAsync(id);
        if (deck == null)
            throw new Exception("Deck not found");
        
        return new DeckResponse(deck);
    }

    public async Task<IEnumerable<DeckResponse>> GetDecksAsync()
    {
        var decks = await _deckRepository.GetAllAsync();

        return decks.Select(deck => new DeckResponse(deck));

    }

}
