using Core.Models;
using Services.ResponseModels;
namespace App.Services.ResponseModels;


public class CardResponse
{
    public int Id { get; }
    public CardSideResponse Front { get; }
    public CardSideResponse Back { get; }
    public CardStatus Status { get; }
    public string? Hint { get; }
    public List<string>? Tags { get; }
    public string? CreatedBy { get; }
    public DateTimeOffset CreatedAt { get;}
    public string? ModifiedBy { get; }
    public DateTime? ModifiedAt { get; }

    public CardResponse(Card card)
    {
        Id = card.Id;
        Front = new CardSideResponse(card.Front);
        Back = new CardSideResponse(card.Back);
        Status = card.Status;
        Hint = card.Hint;
        Tags = card.Tags;
        CreatedBy = card.CreatedBy;
        CreatedAt = card.CreatedAt;
        ModifiedBy = card.ModifiedBy;
        ModifiedAt = card.ModifiedAt;
    }

}
