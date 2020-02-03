using System;
using Monies.Database.Enums;

namespace Monies.Database.Models
{
    public class UserSetting
    {
        public int UserSettingId { get; set; }
        public DateTime BirthDate { get; set; }
        public SalaryPeriodType PreferredPeriodType { get; set; }
        public SalaryValueType PreferredValueType { get; set; }
    }
}