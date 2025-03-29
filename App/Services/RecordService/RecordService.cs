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

    public async Task<RecordResponse> AddRecordAsync(AddRecordRequest request)
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

    public async Task<RecordResponse> UpdateRecordAsync(UpdateRecordRequest request)
    {
        var record = await _recordRepository.GetAsync(request.Id);

        if (record == null)
            throw new Exception($"Could not find record with id {request.Id}");

        record.Side1 = request.Side1;
        record.Side2 = request.Side2;
        record.DeckId = request.DeckId;
        record.Hint = request.Hint;
        record.ImageUrl = request.ImageUrl;
        record.Tags = request.Tags;
        record.ModifiedAt = DateTime.UtcNow;       

        await _recordRepository.UpdateAsync(record);
        return new RecordResponse(record);
    }

    public async Task DeleteRecordAsync(Guid id)
    {
        await _recordRepository.DeleteAsync(id);
    }

    public async Task<RecordResponse> GetRecordAsync(Guid id)
    {
        var record = await _recordRepository.GetAsync(id);

        if (record == null)
            throw new Exception($"Could not find a Card with given id = {id}");

        return new RecordResponse(record);
    }

    public async Task<IEnumerable<RecordResponse>> GetRecordsAsync()
    {
        var record = await _recordRepository.GetAllAsync();
        return record.Select(record => new RecordResponse(record));
    }

    
} 