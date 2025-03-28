using Core.Models;

namespace App.Services.RecordServices.Contracts;
public class RecordResponse 
{
    public Guid Id { get; set; }
    public Guid? DeckId { get; set; }
    public string Side1 { get; set; }
    public string Side2 { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public string? Hint { get; set; }
    public string? ImageUrl { get; set; }
    public List<string>? Tags { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public List<Guid>? CardIds { get; set; }

    public RecordResponse(Record record)
    {
        Id = record.Id;
        DeckId = record.DeckId;
        Side1 = record.Side1;
        Side2 = record.Side2;
        CreatedDate = record.CreatedDate;
        Hint = record.Hint;
        ImageUrl = record.ImageUrl;
        Tags = record.Tags;
        ModifiedBy = record.ModifiedBy;
        ModifiedAt = record.ModifiedAt;
        CardIds = record.CardIds;
    }
}