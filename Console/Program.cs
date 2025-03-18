using System;
using System.Collections.Generic;
using System.Text.Json;
using Core.Models;

namespace ConsoleApp;
class Program
{
    static List<Card> cards = new List<Card>();
    static int nextId = 0;

    const string filePath = "cards.json";

    static void Main()
    {
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
                    AddCard();
                    break;
                case "show":
                    ShowCards();
                    break;
                case "save":
                    SaveCards(cards, filePath);
                    break;
                case "load":
                    cards = LoadCards(filePath);
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("Unknown command. Type 'help' for options.");
                    break;
            }
        }
    }

    static void SaveCards(List<Card> cards, string filePath)
    {
        if (cards.Count == 0)
        {
            Console.WriteLine("No cards to save.");
            return;
        }

        var options = new JsonSerializerOptions { WriteIndented = true };   
        string jsonString = JsonSerializer.Serialize(cards, options);
        File.WriteAllText(filePath, jsonString);
        Console.WriteLine("Cards successfully saved to file.");
    }

    static List<Card> LoadCards(string filePath){

        if(File.Exists(filePath)){
            string jsonString = File.ReadAllText(filePath);
            cards = JsonSerializer.Deserialize<List<Card>>(jsonString) ?? new List<Card>();

            nextId = cards.Count > 0 ? cards.Max(c => c.Id) + 1 : 1; // Обновляем nextId

            Console.WriteLine("Cards were successfully loaded.");
            
            return cards;
        }

        Console.WriteLine("Cannot find file. Starting with empty cards.");
        return new List<Card>();

    }
    

    static void AddCard()
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


        if(!string.IsNullOrEmpty(frontText) && !string.IsNullOrEmpty(backText))
        {
            cards.Add(new Card(nextId++ , new CardSide {Text = frontText, ImageUrl = imgLink}, new CardSide {Text = backText}));
            Console.WriteLine("Card was added!");
        }
        else
        {
            Console.WriteLine("Question and answer cannot be empty.");
        }

    }

    static void ShowCards()
    {
        if (cards.Count == 0)
        {
            Console.WriteLine("No cards yet.");
            return;
        }

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
        Console.WriteLine("  show - Show all cards");
        Console.WriteLine("  save - Save cards to file");
        Console.WriteLine("  load - Load cards from file");
        Console.WriteLine("  exit - Exit the app");
    }

}