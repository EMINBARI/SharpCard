namespace App.Services.RequestModels;

public class AddCardRequest
{
    public required string FrontText {get; set;}
    public required string BackText {get; set;}
    public string? ImgLink {get; set;}

}