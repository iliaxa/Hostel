using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace WpfApplicationEntity.API
{
    public class Relative
    {
        public int Id_Relative { get; set; }
        public string FIO { get; set; }
        public string Work_Study_Place { get; set; }
        public DateTime YearBirth { get; set; }
        public int cn_S { get; set; }
        public int ID_RF { get; set; }
        public string StudentFIO { get; set; }
    }
}
