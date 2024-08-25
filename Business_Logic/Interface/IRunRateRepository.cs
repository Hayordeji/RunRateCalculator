

using DataAccess.Entity;

namespace Business_Logic.Interface
{
    public interface IRunRateRepository
    {
        Task<List<Record>> GetRecordsAsync();
        Task<Record> GetRecordAsync(int id);
        Task<Record> DeleteRecordAsync(int id);
        Task<Record> CreateRecordAsync(Record record);
    }
}
