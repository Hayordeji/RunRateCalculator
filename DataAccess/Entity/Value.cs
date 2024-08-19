namespace DataAccess.Entity
{
    public class Value
    {
        public int Id { get; set; }
        public int MonthsCompleted { get; set; }
        public int MonthRemaining { get; set; }
        public decimal AnnualBudget { get; set; }
        public decimal MonthlyBudget { get; set; }
        public decimal YearTillDateAchieved { get; set; }
        public decimal YearTillDateBudget { get; set; }
        public decimal YearTillDateVariance { get; set; }
        public decimal RemainingBudget { get; set; }
        public decimal RunRate { get; set; }
    }
}
