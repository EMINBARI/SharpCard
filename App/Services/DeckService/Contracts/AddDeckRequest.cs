namespace App.Services.DeckService.Contracts;

public class AddDeckRequest
{
    public string Name { get; set; }
    public string? Description { get; set; }

    public AddDeckRequest(string name)
    {
        Name = name;
    }
}