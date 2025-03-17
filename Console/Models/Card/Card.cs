public class Card 
{
    public required int Id { get; set; }
    public required CardSide Front { get; set; }
    public required CardSide Back { get; set; }
    public required CardStatus Status { get; set; }
    public string? Hint { get; set; }
    public List<string>? Tags { get; set; }
    public string? CreatedBy { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }

    public Card(int id, CardSide front, CardSide back)
    {
        Id = id;
        Front = front;
        Back = back;
        
        Status = CardStatus.Active;
        CreatedAt = DateTimeOffset.UtcNow;
    }
    
}