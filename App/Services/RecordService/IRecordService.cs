using App.Services.RecordServices.Contracts;

namespace App.Services.RecordService;

public interface IRecordService
{
    public Task<RecordResponse> AddRecordAsync(AddRecordRequest request);
    public Task<RecordResponse> UpdateRecordAsync(UpdateRecordRequest request);
    public Task DeleteRecordAsync(Guid id);
    public Task<RecordResponse> GetRecordAsync(Guid id);
    public Task<IEnumerable<RecordResponse>> GetRecordsAsync();
}