
using Business_Logic.Dto;
using Business_Logic.Interface;
using DataAccess.Data;
using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace Business_Logic.Repository
{
    public class RunRateRepository : IRunRateRepository
    {
        private readonly ApplicationDbContext _context;
        public RunRateRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Record> CreateRecord(Record record)
        {
            int monthRemaining = 12 - record.MonthsCompleted;
            decimal monthlyBudget = record.AnnualBudget / 12;
            decimal yearTillDateBudget = monthlyBudget * record.MonthsCompleted;
            decimal yearTillDateVariance = yearTillDateBudget - record.YearTillDateAchieved;
            decimal remainingBudget = yearTillDateVariance + (record.AnnualBudget - yearTillDateBudget);
            decimal runRate = ((yearTillDateVariance / monthRemaining) + monthlyBudget);

            var newRecord = new Record
            {
                MonthsCompleted = record.MonthsCompleted,
                MonthRemaining = monthRemaining,
                AnnualBudget = record.AnnualBudget,
                MonthlyBudget = monthlyBudget,
                YearTillDateAchieved = record.YearTillDateAchieved,
                YearTillDateBudget = yearTillDateBudget,
                YearTillDateVariance = yearTillDateVariance,
                RemainingBudget = remainingBudget,
                RunRate = runRate
            };

            await _context.AddAsync(newRecord);
            await _context.SaveChangesAsync();
            return newRecord;

        }

        public async Task<List<Record>> GetRecords()
        {
            return await _context.Records.ToListAsync();  
        }
    }
}
