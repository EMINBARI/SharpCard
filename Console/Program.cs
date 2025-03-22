using System;
using System.Text.Json;
using System.Threading.Tasks;
using App.Services;
using App.Services.RequestModels;
using Core.Models;
using Core.Repositories;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp;
class Program
{

    
    static async Task Main()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddSingleton<ICardRepository, InMemoryCardRepository>();
        services.AddScoped<ICardService, CardService>();

        var provider = services.BuildServiceProvider();

        var cardService = provider.GetRequiredService<ICardService>();


        Console.WriteLine("Welcome to SharpCard! Type 'help' for commands.");

        while (true)
        {
            Console.Write(">");

            string? command = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrEmpty(command))
                continue;

            switch (command)
            {
                case "help":
                    ShowHelp();
                    break;
                case "add":
                    await AddCard(cardService);
                    break;
                case "show":
                    await ShowCards(cardService);
                    break;
                case "save":
                    SaveCards();
                    break;
                case "load":
                    LoadCards();
                    break;
                case "edit":
                    await EditCard(cardService);
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("Unknown command. Type 'help' for options.");
                    break;
            }
        }
    }


    static async Task AddCard(ICardService cardService)
    {
        Console.WriteLine("Enter front of card (Question):");
        string? frontText = Console.ReadLine();
        string? imgLink = null;
        Console.WriteLine("Do you want to add image link of this card? (y/n)");
        string? imgAnswer = Console.ReadLine()?.ToLower();
        if(imgAnswer == "y")
        {
            Console.WriteLine("Enter image link:");
            imgLink = Console.ReadLine();
        }
        Console.WriteLine("Enter back of card (Answer):");
        string? backText = Console.ReadLine();


        await cardService.AddCardAsync(
             new AddCardRequest(
                frontSide: new AddCardRequest.AddCardSideRequest { Text = frontText, ImgUrl = imgLink }, 
                backSide: new AddCardRequest.AddCardSideRequest {Text = backText})
        );
    }
    static async Task EditCard(ICardService cardService)
    {
        Console.WriteLine("Enter Id of card you want to edit:");

        string? idInput = Console.ReadLine();
        if (!int.TryParse(idInput, out int id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        var card = await cardService.GetCardAsync(id);

        Console.WriteLine($"ID: {card.Id} | Q: {card.Front.Text} | A: {card.Back.Text}");

        Console.WriteLine("Enter new front of card (Question):");
        string? frontText = Console.ReadLine();
    
        Console.WriteLine("Enter new image link (or just skip):");
        string? imgLink = Console.ReadLine();
        
        Console.WriteLine("Enter new back of card (Answer):");
        string? backText = Console.ReadLine();

        await cardService.UpdateCardAsync(
            new UpdateCardRequest
            {
                Id = id,
                FrontText = frontText,
                BackText = backText,
                ImgLink = imgLink
            }
        );
    }

    static void SaveCards()
    {
        throw new NotImplementedException();
    }

    static List<Card> LoadCards()
    {
        throw new NotImplementedException();
    }
    
    

    static async Task ShowCards(ICardService cardService)
    {
        var cards = await cardService.GetCardsAsync();

        //todo: empty list message

        foreach (var card in cards)
        {
            Console.WriteLine($"ID: {card.Id} | Q: {card.Front.Text} | A: {card.Back.Text}");
        }
    }

    static void ShowHelp()
    {
        Console.WriteLine("Commands:");
        Console.WriteLine("  help - Show this help");
        Console.WriteLine("  add  - Add a new card");
        Console.WriteLine("  edit - Edit a card");
        Console.WriteLine("  show - Show all cards");
        Console.WriteLine("  save - Save cards to file");
        Console.WriteLine("  load - Load cards from file");
        Console.WriteLine("  exit - Exit the app");
    }

}