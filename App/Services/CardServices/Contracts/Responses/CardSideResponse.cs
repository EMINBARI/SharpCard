using Core.Models;

namespace App.Services.CardServices.Contracts;
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