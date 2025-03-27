using Core.Models;
namespace Services.ResponseModels;
public class CardSideResponse 
{
    public string Text { get; }
    public string? ImageUrl { get; }   

    public CardSideResponse(CardSide cardSide)
    {
        Text = cardSide.Text;
        ImageUrl = cardSide.ImageUrl;
    } 
}