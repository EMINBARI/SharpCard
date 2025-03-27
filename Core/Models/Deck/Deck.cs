namespace Core.Models;

public class Deck
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public List<Card> Cards { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

    public Deck(Guid id, string name)
    {
        Id = id;
        Name = name;
        Cards = new List<Card>();
        CreatedAt = DateTimeOffset.UtcNow;
    }
}