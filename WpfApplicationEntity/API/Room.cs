using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace WpfApplicationEntity.API
{
    public class Room
    {
        public int id_Room { get; set; }
        public int Room_number { get; set; }
        public int People_amount { get; set; }
        public int FreeSeats { get; set; }
        //[Key] public int ID { get; set; }
        //[Required] public int Number { get; set; }
        //[Required] public int Residing_Count { get; set; }
        //public virtual ICollection<Student> Students { get; set; }
    }
}
