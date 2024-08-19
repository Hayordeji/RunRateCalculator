using Business_Model.Dto;
using DataAccess.Entity;

namespace Business_Model.Interface
{
    public interface IRunRateRepository
    {
        Task<List<Value>> GetRecords();
        Task<Value> CreateRecord(CreateRecordDto inputModel);
    }
}
