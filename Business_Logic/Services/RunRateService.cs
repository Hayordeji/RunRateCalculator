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
            return await _runRateRepo.CreateRecord(record);
        }
    }
}
