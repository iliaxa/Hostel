using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace WpfApplicationEntity.API
{
    public class StudentsView
    {
        public int cn_S { get; set; }
        public string Student { get; set; }
        public string FIO { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string cn_G { get; set; }
        public bool Budget { get; set; }
        public bool Gender { get; set; }
        public DateTime DateBirth { get; set; }
        public string Telephone_Home { get; set; }
        public string Telephone_Mob { get; set; }
        public string Adress { get; set; }
        public string Room { get; set; }
        public string Gend { get; set; }
        public string PassportSeries { get; set; }
        public int PassportNumber { get; set; }
        public string PasportID { get; set; }
        public DateTime DateIssuePasport { get; set; }
        public string PasportData { get; set; }
        public bool RB { get; set; }
        public int ID_MG { get; set; }
        public bool BRSM { get; set; }
        public bool TradeUnion { get; set; }
        public string PreviousPlaceOfStudy { get; set; }
        public DateTime StateDateOfStudy { get; set; }
        public bool FamilyState { get; set; }
        public DateTime DateStartStudingLastCollege { get; set; }
        public DateTime DateEndStudingLastCollege { get; set; }
    }
}
