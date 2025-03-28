namespace Core.Models;

public class Review 
{
    public Guid Id { get; set; }
    public Guid CardId { get; set; }
    public DateTimeOffset LastReviewDate { get; set; }
    public DateTimeOffset NextReviewDate { get; set; }
    public int Rate { get; set; }
    public Review(Guid id, Guid cardId)
    {
        Id = id;
        CardId = cardId;
        LastReviewDate = DateTimeOffset.UtcNow;
    }
}