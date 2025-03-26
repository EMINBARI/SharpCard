namespace Core.Models;

class Review 
{
    public int Id { get; set; }
    public int CardId { get; set; }
    public DateTimeOffset ReviewDate { get; set; }
    public DateTimeOffset NextReviewDate { get; set; }
    public int Rate { get; set; }

    public Review(int cardId)
    {
        CardId = cardId;
        ReviewDate = DateTimeOffset.UtcNow;
    }
}