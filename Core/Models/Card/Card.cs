namespace Core.Models;

public class Card 
{
    public Guid Id { get; set; }
    public CardSide Front { get; set; }
    public CardSide Back { get; set; }
    public CardStatus Status { get; set; }
    public string? Hint { get; set; }
    public List<string>? Tags { get; set; }
    public string? CreatedBy { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }

    public Card(Guid id, CardSide front, CardSide back)
    {
        Id = id;
        Front = front;
        Back = back;
        
        Status = CardStatus.Active;
        CreatedAt = DateTimeOffset.UtcNow;
    }
    
}