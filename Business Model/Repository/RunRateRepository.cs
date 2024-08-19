using Business_Model.Dto;
using Business_Model.Interface;
using DataAccess.Data;
using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace Business_Model.Repository
{
    public class RunRateRepository : IRunRateRepository
    {
        private readonly ApplicationDbContext _context;
        public RunRateRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Value> CreateRecord(CreateRecordDto inputModel)
        {
            int monthRemaining = 12 - inputModel.MonthsCompleted;
            decimal monthlyBudget = inputModel.AnnualBudget / 12;
            decimal yearTillDateBudget = monthlyBudget * inputModel.MonthsCompleted;
            decimal yearTillDateVariance = yearTillDateBudget - inputModel.YearTillDateAchieved;
            decimal remainingBudget = yearTillDateVariance + (inputModel.AnnualBudget - yearTillDateBudget);
            decimal runRate = ((yearTillDateVariance / monthRemaining) + monthlyBudget);

            var newRecord = new Value
            {
                MonthsCompleted = inputModel.MonthsCompleted,
                MonthRemaining = monthRemaining,
                AnnualBudget = inputModel.AnnualBudget,
                MonthlyBudget = monthlyBudget,
                YearTillDateAchieved = inputModel.YearTillDateAchieved,
                YearTillDateBudget = yearTillDateBudget,
                YearTillDateVariance = yearTillDateVariance,
                RemainingBudget = remainingBudget,
                RunRate = runRate
            };

            await _context.AddAsync(newRecord);
            await _context.SaveChangesAsync();
            return newRecord;

        }

        public async Task<List<Value>> GetRecords()
        {
            return await _context.Values.ToListAsync();
            
        }
    }
}
