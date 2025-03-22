namespace App.Services.RequestModels;

public class AddCardRequest
{

    public AddCardSideRequest FrontSide { get; set; }
    public AddCardSideRequest BackSide { get; set; }

    public AddCardRequest(AddCardSideRequest frontSide, AddCardSideRequest backSide)
    {
        FrontSide = frontSide;
        BackSide = backSide;
    }

    public class AddCardSideRequest
    {
        public string? Text { get; set; }
        public string? ImgUrl { get; set; }

    }

}