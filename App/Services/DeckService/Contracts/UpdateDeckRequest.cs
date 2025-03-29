namespace App.Services.DeckService.Contracts;

public class UpdateDeckRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public UpdateDeckRequest(string name, string description)
    {
        Name = name;
        Description = description;
    }
}