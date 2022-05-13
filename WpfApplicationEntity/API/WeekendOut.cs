using System;

namespace WpfApplicationEntity.API
{
    public class WeekendOut
    {
        public int ID_Weekend_Out { get; set; }
        public int cn_S { get; set; }
        public DateTime Departure_Date { get; set; }
        public TimeSpan Departure_Time { get; set; }
        public DateTime Arrival_Date { get; set; }
        public TimeSpan Arrival_Time { get; set; }
        public string Adress { get; set; }
        public string Note { get; set; }
        public bool? IsDepartured { get; set; }
        public string StringIsDepartured { get; set; }

        public string Student { get; set; }

    }
}
