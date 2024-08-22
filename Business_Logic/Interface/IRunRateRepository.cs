

using DataAccess.Entity;

namespace Business_Logic.Interface
{
    public interface IRunRateRepository
    {
        Task<List<Record>> GetRecords();
        Task<Record> CreateRecord(Record record);
    }
}
