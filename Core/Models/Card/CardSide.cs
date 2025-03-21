namespace Core.Models;
public class CardSide {
    public string Text { get; set; }
    public string? ImageUrl { get; set; }

    public CardSide(string text, string? imageUrl)
    {
        Text = text;
        ImageUrl = imageUrl;
    }
    
}