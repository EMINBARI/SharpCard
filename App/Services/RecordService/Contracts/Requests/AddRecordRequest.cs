public class AddRecordRequest 
{
    public string Side1 { get; set; }
    public string Side2 { get; set; }
    public Guid? DeckId { get; set; }
    public string? Hint { get; set; }
    public string? ImageUrl { get; set; }
    public List<string>? Tags { get; set; }

    public AddRecordRequest(string side1, string side2)
    {
        Side1 = side1;
        Side2 = side2;
    }
}