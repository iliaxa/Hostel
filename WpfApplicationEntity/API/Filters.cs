using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
namespace WpfApplicationEntity.API
{
    public static class Filters
    {
        public static List<WeekendOut> OutSurnameSearch(string surname)
        {
            var list = DataService.GetWeekendOut();
            return list.Select(c => c).Where(c => c.Student.StartsWith(surname)).ToList();
        }
        public static List<LongOut> LongSurnameSearch(string surname)
        {
            var list = DataService.GetLongOuts();
            return list.Select(c => c).Where(c => c.Student.StartsWith(surname)).ToList();
        }

        public static List<WeekendOut> OutDepSearch()
        {
            var list = DataService.GetWeekendOut();
            return list.Select(c => c).Where(c => c.IsDepartured == false).ToList();
        }
        public static List<WeekendOut> OutArrSearch()
        {
            var list = DataService.GetWeekendOut();
            return list.Select(c => c).Where(c => c.IsDepartured == true).ToList();
        }
        public static List<WeekendOut> OutNullDepSearch()
        {
            var list = DataService.GetWeekendOut();
            return list.Select(c => c).Where(c => c.IsDepartured == null).ToList();
        }
        //public static List<GridsInfo.newLongOut> Reason1Filter()
        //{
        //    using (MyDBContext db = new MyDBContext())
        //    {
        //        var reasons = db.Reasons.ToList();
        //        var list = GridsInfo.GetNewLongOuts(db);
        //        return list.Select(c => c).Where(c => c.Reason == reasons[1].Reason).ToList();
        //    };
        //}
        //public static List<GridsInfo.newLongOut> Reason2Filter()
        //{
        //    using (MyDBContext db = new MyDBContext())
        //    {
        //        var reasons = db.Reasons.ToList();

        //        var list = GridsInfo.GetNewLongOuts(db);
        //        return list.Select(c => c).Where(c => c.Reason == reasons[0].Reason).ToList();
        //    };
        //}
        //public static List<GridsInfo.newLongOut> Reason3Filter()
        //{
        //    using (MyDBContext db = new MyDBContext())
        //    {
        //        var reasons = db.Reasons.ToList();

        //        var list = GridsInfo.GetNewLongOuts(db);
        //        return list.Select(c => c).Where(c => c.Reason == reasons[2].Reason).ToList();
        //    };
        //}
        //public static List<GridsInfo.newLongOut> Reason4Filter()
        //{
        //    using (MyDBContext db = new MyDBContext())
        //    {
        //        var reasons = db.Reasons.ToList();

        //        var list = GridsInfo.GetNewLongOuts(db);
        //        return list.Select(c => c).Where(c => c.Reason == reasons[3].Reason).ToList();
        //    };
        //}
        //public static List<GridsInfo.newOut> OutRoomSearch(string room)
        //{
        //    using (MyDBContext db = new MyDBContext())
        //    {
        //        var outs = GridsInfo.GetNewOuts(db);
        //        var list = GridsInfo.GetNewHostelStudents(db);
        //        var students = list.Select(c => c).Where(c => c.Room.StartsWith(room)).ToList();
        //        var s = outs.Select(c => c).Where(c => c.Student.StartsWith(students.Select(s=>s.SurName))).ToList();
        //        return students.Select(c=>c).Where(c=>c.)
        //    };
        //}
        public static List<StudentsView> InSurnameSearch(string surname)
        {
            var list = DataService.GetInhabitedStudents();
            return list.Select(c => c).Where(c => c.SurName.StartsWith(surname)).ToList();
        }
        public static List<WorkingOff> WorkingOffSurnameSearch(string surname)
        {
            var list = DataService.GetWorkingOff();
            return list.Select(c => c).Where(c => c.Student.StartsWith(surname)).ToList();
        }
        public static List<StudentsView> UnSurnameSearch(string surname)
        {
            var list = DataService.GetUninhabitedStudents();
            return list.Select(c => c).Where(c => c.SurName.StartsWith(surname)).ToList();
        }
        public static List<StudentsView> InGroupSearch(string group)
        {
            var list = DataService.GetInhabitedStudents();
            return list.Select(c => c).Where(c => c.cn_G.StartsWith(group)).ToList();
        }
        public static List<StudentsView> UnGroupSearch(string group)
        {
            var list = DataService.GetUninhabitedStudents();
            return list.Select(c => c).Where(c => c.cn_G.StartsWith(group)).ToList();
        }
        public static List<StudentsView> RoomSearch(string room)
        {
            var list = DataService.GetInhabitedStudents();
            return list.Select(c => c).Where(c => c.Room.StartsWith(room)).ToList();
        }
        public static List<StudentsView> OldFilter(bool isOlder)
        {
            var list = DataService.GetInhabitedStudents();
            if (isOlder) return list.Select(c => c).Where(c => (DateTime.Now - c.DateBirth).Days >= 6570).ToList();
            else return list.Select(c => c).Where(c => (DateTime.Now - c.DateBirth).Days < 6570).ToList();
        }
        public static List<StudentsView> WYoungFilter()
        {
            var list = DataService.GetInhabitedStudents();
            return list.Select(c => c).Where(c => (DateTime.Now - c.DateBirth).Days < 5840 && c.Gend == "Женский").ToList();
        }
        //public static List<GridsInfo.newWorkingOff> WorkingOffSurnameSearch(string surname)
        //{
        //    using (MyDBContext db = new MyDBContext())
        //    {
        //        var list = GridsInfo.GetNewWorkingOffs(db);
        //        return list.Select(c => c).Where(c => c.Student.StartsWith(surname)).ToList();
        //    };
        //}
        public static List<Relative> FIORelativeSearch(string FIO)
        {
            var list = DataService.GetRelatives();
            return list.Select(c => c).Where(c => c.FIO.StartsWith(FIO)).ToList();
        }
        public static List<Relative> RelativeStudentSurNameSearch(string surname)
        {
            var relatives = DataService.GetRelatives();
            var students = DataService.GetInhabitedStudents();
            var list = from rel in relatives
                       from stud in students
                       where stud.cn_S == rel.cn_S && stud.SurName.StartsWith(surname)
                       select rel;
            return list.ToList();
        }
        public static List<Room> RoomNumberSearch(string room)
        {
            var list = DataService.GetRooms();
            return list.Select(c => c).Where(c => c.Room_number.ToString().StartsWith(room)).ToList();
        }
        public static List<Room> RoomSurnameSearch(string surname)
        {
            var rooms = DataService.GetRooms();
            var students = DataService.GetInhabitedStudents();
            var hostels = DataService.GetHostels();
            var list = from room in rooms
                       from stud in students
                       from host in hostels
                       where stud.cn_S == host.cn_S && room.id_Room == host.id_Room && stud.SurName.StartsWith(surname)
                       select room;
            return list.ToList();
        }
        public static List<Room> RoomGroupSearch(string group)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                return db.Query<Room>($"select distinct Room.id_Room, Room.People_amount, Room.Room_number from Room, Student, Hostel where Room.id_Room = Hostel.id_Room and Student.cn_S = Hostel.cn_S and Student.cn_G like '{group}%'").ToList();
            }
        }


        //public static List<GridsInfo.newRelative> StudentRoomSearch(string room)
        //{
        //    using (MyDBContext db = new MyDBContext())
        //    {
        //        var list = GridsInfo.GetNewRelatives(db).Select(c => c).Where(c => c.FIO.StartsWith(FIO)).ToList();
        //        return ;
        //    };
        //}
        //public static List<GridsInfo.newWorkingOff> WorkingOffDateSearch(DateTime date)
        //{
        //    using (MyDBContext db = new MyDBContext())
        //    {
        //        var list = GridsInfo.GetNewWorkingOffs(db);
        //        return list.Select(c => c).Where(c => c.Date.StartsWith(date)).ToList();
        //    };
        //}
    }
}
