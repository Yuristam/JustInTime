using JustInTime.DAL.Domain.Enums;

namespace JustInTime.DAL.Domain.Entities
{
    public class SleepTracker
    {
        public DaysOfWeek DayOfWeek { get; set; }
        public DateTime GetUpTime { get; set; }
        public DateTime GoSleepTime { get; set;}
    }
}
