using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WpfApplicationEntity.API
{
    public class WorkingOff
    {
        public int ID_Practice_Working_Off { get; set; }
        public DateTime Date { get; set; }
        public int Count_Working_Off_Hours { get; set; }
        public string Note { get; set; }
        public int cn_S { get; set; }
        public string Student { get; set; }
    }
}
