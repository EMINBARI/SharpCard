namespace App.Services.Contracts.Requests;

public class UpdateCardRequest
{    
    public int Id;
    public string? FrontText;
    public string? BackText;
    public string? ImgLink;
}