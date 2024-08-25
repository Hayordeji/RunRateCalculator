
using Business_Logic.Dto;
using Business_Logic.Interface;
using DataAccess.Data;
using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;

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
            var yearTillDateAchieved = Math.Abs(record.YearTillDateAchieved);
            var annualBudget = Math.Abs(record.AnnualBudget);
            var monthsCompleted = Math.Abs(record.MonthsCompleted);
            int monthRemaining = 12 - monthsCompleted;
            decimal monthlyBudget = annualBudget / 12;
            decimal yearTillDateBudget = monthlyBudget * monthsCompleted;
            decimal yearTillDateVariance = yearTillDateBudget - yearTillDateAchieved;
            decimal remainingBudget = yearTillDateVariance + (annualBudget - yearTillDateBudget);
            decimal runRate = ((yearTillDateVariance / monthRemaining) + monthlyBudget);

            var newRecord = new Record
            {
                MonthsCompleted = monthsCompleted,
                MonthRemaining = monthRemaining,
                AnnualBudget = annualBudget,
                MonthlyBudget = monthlyBudget,
                YearTillDateAchieved = yearTillDateAchieved,
                YearTillDateBudget =  yearTillDateBudget,
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
