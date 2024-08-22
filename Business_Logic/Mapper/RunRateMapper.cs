using Business_Logic.Dto;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Mapper
{
    public static class RunRateMapper
    {
        
        public static Value ToCreateRecordDto(this CreateRecordDto _createRecordDto)
        {
            return new Value
            {
                YearTillDateAchieved = _createRecordDto.YearTillDateAchieved,
                AnnualBudget = _createRecordDto.AnnualBudget,
                MonthsCompleted = _createRecordDto.MonthsCompleted     
            };
        }  

    }
}
