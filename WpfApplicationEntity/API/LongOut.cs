using System;
namespace WpfApplicationEntity.API
{
    public class LongOut
    {
        public DateTime Departure_Date { get; set; }
        public TimeSpan Departure_Time { get; set; }
        public DateTime Arrival_Date { get; set; }
        public TimeSpan Arrival_Time { get; set; }
        public int cn_S { get; set; }
        public string Student { get; set; }
        public string Absence_Reason { get; set; }
    }
}
