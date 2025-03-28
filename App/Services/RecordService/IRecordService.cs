using App.Services.RecordServices.Contracts;

namespace App.Services.RecordService;

public interface IRecordService
{
    public Task<RecordResponse> AddCardAsync(AddRecordRequest request);
    public Task<RecordResponse> UpdateCardAsync(UpdateRecordRequest request);
    public Task DeleteCardAsync(Guid id);
    public Task<RecordResponse> GetCardAsync(Guid id);
    public Task<IEnumerable<RecordResponse>> GetCardsAsync();
}