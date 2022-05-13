using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace WpfApplicationEntity.API
{
    public class AdminBaseView
    {
        public string cn_A { get; set; }
        public string Admin { get; set; }
        public string FIO { get; set; }
        public string IF { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
    }
}
