using Core.Models;

namespace App.Services.DeckService.Contracts;


public class DeckResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public List<Card>? Cards { get; set; }

    public DeckResponse(Deck deck)
    {
        Id = deck.Id;
        Name = deck.Name;
        Description = deck.Description;
        CreatedAt = deck.CreatedAt;
    }
}