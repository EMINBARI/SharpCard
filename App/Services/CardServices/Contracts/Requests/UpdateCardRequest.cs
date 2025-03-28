namespace App.Services.CardServices.Contracts;

public class UpdateCardRequest
{    
    public Guid Id { get; set; }
    public string? FrontText { get; set; }
    public string? BackText { get; set; }
    public string? ImgLink { get; set; }
}