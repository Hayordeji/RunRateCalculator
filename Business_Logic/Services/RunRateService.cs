using Business_Logic.Dto;
using Business_Logic.Interface;
using Business_Logic.Repository;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services
{
    public class RunRateService : IRunRateService
    {
        private readonly IRunRateRepository _runRateRepo;
        public RunRateService(IRunRateRepository runRateRepo)
        {
            _runRateRepo = runRateRepo;
        }
        public async Task<Record> CreateRecordAsync(Record record)
        {
            return await _runRateRepo.CreateRecordAsync(record);
        }

        public async Task<Record> DeleteRecordAsync(int id)
        {
            if (!await _runRateRepo.RecordExists(id))
            {
                return null;
            }
            return await _runRateRepo.DeleteRecordAsync(id);
        }

        public async Task<Record> GetRecordAsync(int id)
        {
            if (!await _runRateRepo.RecordExists(id))
            {
                return null;
            }
            return await _runRateRepo.GetRecordAsync(id);
        }

        public async Task<List<Record>> GetRecordsAsync()
        {
            return await _runRateRepo.GetRecordsAsync();
        }
    }
}
