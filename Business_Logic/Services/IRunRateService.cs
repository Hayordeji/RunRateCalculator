using Business_Logic.Dto;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services
{
    public interface IRunRateService
    {
        Task<Record> CreateRecordAsync(Record record);
    }
}
