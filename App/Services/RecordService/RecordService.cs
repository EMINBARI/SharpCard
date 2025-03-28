using App.Services.RecordServices.Contracts;
using Core.Models;
using Core.Repositories;

namespace App.Services.RecordService;

public class RecordService : IRecordService
{
    
    private readonly IRecordRepository _recordRepository;
    

    public RecordService(IRecordRepository recordRepository)
    {
        _recordRepository = recordRepository;
    }

    public async Task<RecordResponse> AddCardAsync(AddRecordRequest request)
    {
        if (string.IsNullOrEmpty( request.Side1) || string.IsNullOrEmpty(request.Side2))
        {
            throw new Exception("Front and back side text must be provided");
        }

        var record = new Record (
            id: Guid.NewGuid(),
            side1: request.Side1, 
            side2: request.Side2) 
            {
                DeckId = request.DeckId, 
                Hint = request.Hint, 
                ImageUrl = request.ImageUrl, 
                Tags = request.Tags
            };

        await _recordRepository.CreateAsync(record);
        return new RecordResponse(record); 

    }

    public Task<RecordResponse> UpdateCardAsync(UpdateRecordRequest request)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCardAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<RecordResponse> GetCardAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<RecordResponse>> GetCardsAsync()
    {
        throw new NotImplementedException();
    }

    
} 