namespace Core.Models;

public class Record
{
    public Guid Id { get; set; }
    public Guid DeckId { get; set; }
    public string Side1 { get; set; }
    public string Side2 { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public RecordStatus Status { get; set; }
    public string? Hint { get; set; }
    public string? ImageUrl { get; set; }
    public List<Guid>? CardIds { get; set; }

    public Record(Guid id, Guid deckId, string side1, string side2)
    {
        Id = id;
        DeckId = deckId;
        Side1 = side1;
        Side2 = side2;
        CreatedDate = DateTimeOffset.UtcNow;
        Status = RecordStatus.Active;
    }
}