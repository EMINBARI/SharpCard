public class UpdateRecordRequest 
{
    public Guid Id { get; set; }
    public Guid? DeckId { get; set; }
    public string Side1 { get; set; }
    public string Side2 { get; set; }
    public string? Hint { get; set; }
    public string? ImageUrl { get; set; }
    public List<string>? Tags { get; set; }

    public UpdateRecordRequest(Guid id, string side1, string side2)
    {
        Id = id;
        Side1 = side1;
        Side2 = side2;
    }
}