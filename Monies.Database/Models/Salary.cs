using System;
using Monies.Database.Enums;

namespace Monies.Database.Models
{
    public class Salary 
    {
        public int SalaryId { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public decimal Value { get; set; }
        public SalaryPeriodType PeriodType { get; set; }
        public SalaryValueType ValueType { get; set; }
    }
}