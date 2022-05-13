using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Dynamic;
using WpfApplicationEntity.API;

namespace WpfApplicationEntity.API
{
    public class DataService
    {
        #region Students
        public static List<StudentsView> GetUninhabitedStudents()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                List<StudentsView> students = db.Query<StudentsView>("select * from Student, Hostel where  Student.cn_S = Hostel.cn_S and Hostel.id_Room is NULL order by Student.SurName").ToList();
                foreach (StudentsView item in students)
                {
                    item.Gend = GridsInfo.GetGenderString(item.Gender);
                    item.cn_G = GridsInfo.GetGroupRus(item.cn_G);
                }
                return students;
            }
        }
        public static List<StudentsView> GetInhabitedStudents()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                List<StudentsView> students = db.Query<StudentsView>("select Room.Room_number as [Room], Student.cn_S, SurName, Student.Name, FatherName, cn_G, Gender, Telephone_Mob, DateBirth, Adress from Student, Hostel, Room where Student.cn_S = Hostel.cn_S and Hostel.id_Room = Room.id_Room order by Hostel.id_Room").ToList();
                foreach (StudentsView item in students)
                {
                    item.Gend = GridsInfo.GetGenderString(item.Gender);
                    item.cn_G = GridsInfo.GetGroupRus(item.cn_G);
                }
                return students;
            }
        }
        public static List<StudentsView> GetDopInfo(StudentsView student)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                List<StudentsView> students = db.Query<StudentsView>($"select * from Student where cn_S = {student.cn_S}").ToList();
                foreach (StudentsView item in students)
                {
                    item.Gend = GridsInfo.GetGenderString(item.Gender);
                    item.cn_G = GridsInfo.GetGroupRus(item.cn_G);
                }
                return students;
            }
        }
        public static List<string> GetGroups()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }
                return db.Query<string>($"select cn_G from Student, Hostel where Student.cn_S = Hostel.cn_S and Hostel.id_Room is not NULL group by cn_G").ToList();
            }
        }

        public static List<Hostel> StudentAdd(Hostel newStud)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                return db.Query<Hostel>($"exec EditHostel {newStud.id_Room},{newStud.cn_S}").ToList();

            }
        }
        public static List<Hostel> StudentDel(Hostel newStud)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                return db.Query<Hostel>($"exec EditHostel NULL,{newStud.cn_S}").ToList();

            }
        }
        public static List<StudentInfo> GetMedGroup()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                return db.Query<StudentInfo>($"select Name from MedicalGroup").ToList();
            }
        }
        public static List<StudentInfo> GetStudMG()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                return db.Query<StudentInfo>($"select MedicalGroup.Name from MedicalGroup, Student where MedicalGroup.ID_MG = Student.ID_MG").ToList();
            }
        }
        public static List<StudentInfo> GetStudOrphan(StudentsView student)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                return db.Query<StudentInfo>($"select * from AnOrphan, Student where AnOrphan.cn_S = {student.cn_S}").ToList();
            }
        }
        public static StudentsView FindStudent(int cn_S)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                return db.Query<StudentsView>($"select * from Student where Student.cn_S =  {cn_S}").First();
            }
        }
        public static void GroupStudentDel(string group)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }
                var list = db.Query<Hostel>($"select * from Hostel, Student where Hostel.cn_S = Student.cn_S AND Student.cn_G = '{group}'");
                foreach (var item in list)
                {
                    StudentDel(item);
                }
            }
        }
        #endregion
        #region Room 
        public static List<Room> GetRooms()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                return db.Query<Room>("select * from Room order by Room_number").ToList();
            }
        }
        public static List<Room> GetFreeRooms()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                var s = db.Query<Room>("select Hostel.id_Room,Count(Hostel.id_Room) As 'FreeSeats' from Hostel Group by Hostel.id_Room").ToList();
                var ss = db.Query<Room>("select * from Room order by Room_number").ToList();
                for (int i = 0; i < ss.Count; i++)
                {
                    for (int j = 0; j < s.Count; j++)
                    {
                        if (ss[i].id_Room == s[j].id_Room)
                        {
                            ss[i].FreeSeats = s[j].FreeSeats;
                            break;
                        }
                    }
                }
                return ss;
            }
        }
        public static List<Hostel> GetHostels()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                return db.Query<Hostel>("select * from Hostel").ToList();
            }
        }
        public static List<StudentsWithRoom> GetStudFromRooms()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                List<StudentsWithRoom> students = db.Query<StudentsWithRoom>("select SurName, Name, FatherName, cn_G, Gender, DateBirth, Telephone_Home, Telephone_Mob, Adress, Room.id_Room from Room, Student, Hostel where Student.cn_S = Hostel.cn_S and Hostel.id_Room = Room.id_Room").ToList();
                foreach (StudentsWithRoom item in students)
                {
                    item.Gend = GridsInfo.GetGenderString(item.Gender);
                    item.cn_G = GridsInfo.GetGroupRus(item.cn_G);
                }
                return students;
            }
        }
        #endregion
        #region User
        public static List<AdminBaseView> GetUser(string login)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                return db.Query<AdminBaseView>($"select * from AdminBaseView WHERE cn_A = '{login}' Order By FIO").ToList();
            }
        }
        #endregion
        #region Relatives
        public static List<Relative> GetRelatives()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                List<Relative> relatives = db.Query<Relative>("select Relative.FIO, Relative.cn_S, Relative.Id_Relative, Relative.ID_RF, Relative.Work_Study_Place, Relative.YearBirth, Student.SurName+' '+Student.Name+' '+Student.FatherName as [StudentFIO] from Relative, Student, Hostel where Relative.cn_S = Student.cn_S and Student.cn_S = Hostel.cn_S").ToList();
                return relatives;
            }
        }
        public static List<Relative> GetStudRelatives(StudentsView student)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                List<Relative> relatives = db.Query<Relative>($"select * from Relative where Relative.cn_S = {student.cn_S}").ToList();
                return relatives;
            }
        }
        public static List<object> GetFamilyState(StudentsView student)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                return db.Query<object>($"select FamilyType.FamilyType_Name from FamilyCharacteristics, FamilyType where {student.cn_S} = FamilyCharacteristics.cn_S and FamilyCharacteristics.id_type = FamilyType.id_type").ToList();
            }
        }
        #endregion
        #region Practice
        public static List<WorkingOff> GetWorkingOff()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                List<WorkingOff> workingOff = db.Query<WorkingOff>("select * from Student, PracticeWorkingOff where Student.cn_S = PracticeWorkingOff.cn_S").ToList();
                foreach (WorkingOff item in workingOff)
                {
                    var student = FindStudent(item.cn_S);
                    item.Student = $"{student.SurName} {student.Name}";
                }
                return workingOff;
            }
        }
        public static List<WorkingOff> PracticeAdd(WorkingOff workingOff)
        {
            if (workingOff.Count_Working_Off_Hours < 0 ||
                workingOff.Date == null)
                return null;
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                return db.Query<WorkingOff>($"exec AddPractice '{workingOff.Date.ToShortDateString()}', {workingOff.Count_Working_Off_Hours}, '{workingOff.Note}', {workingOff.cn_S}").ToList();

            }
        }
        public static List<WorkingOff> PracticeEdit(WorkingOff workingOff)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                return db.Query<WorkingOff>($"exec EditPractice {workingOff.ID_Practice_Working_Off}, '{workingOff.Date}', {workingOff.Count_Working_Off_Hours}, '{workingOff.Note}', {workingOff.cn_S}").ToList();
            }
        }
        public static List<WorkingOff> PracticeDel(WorkingOff workingOff)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                return db.Query<WorkingOff>($"exec DelPractice {workingOff.ID_Practice_Working_Off}").ToList();
            }
        }

        #endregion
        #region WeekendOut
        public static List<WeekendOut> GetWeekendOut()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                List<WeekendOut> weekendOut = db.Query<WeekendOut>("select * from WeekendOut").ToList();
                foreach (WeekendOut item in weekendOut)
                {
                    var student = FindStudent(item.cn_S);
                    item.Student = $"{student.SurName} {student.Name}";
                }
                return weekendOut;
            }
        }
        public static List<WeekendOut> WeekendOutAdd(WeekendOut weekendOut)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                return db.Query<WeekendOut>($"exec AddWeekendOut {weekendOut.cn_S}, '{weekendOut.Departure_Date.ToShortDateString()}'," +
                    $" '{weekendOut.Departure_Time}', '{weekendOut.Arrival_Date.ToShortDateString()}'," +
                    $" '{weekendOut.Arrival_Time}', '{weekendOut.Adress}', '{weekendOut.Note}', '{weekendOut.IsDepartured}'").ToList();
            }
        }
        public static List<WeekendOut> WeekendOutEdit(WeekendOut weekendOut)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                return db.Query<WeekendOut>($"exec EditWeekendOut {weekendOut.ID_Weekend_Out}, {weekendOut.cn_S}, '{weekendOut.Departure_Date.ToShortDateString()}'," +
                    $" '{weekendOut.Departure_Time}', '{weekendOut.Arrival_Date.ToShortDateString()}'," +
                    $" '{weekendOut.Arrival_Time}', '{weekendOut.Adress}', '{weekendOut.Note}', '{weekendOut.IsDepartured}'").ToList();
            }
        }
        public static List<WeekendOut> WeekendOutDel(WeekendOut weekendOut)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                return db.Query<WeekendOut>($"exec DelWeekendOut {weekendOut.ID_Weekend_Out}").ToList();
            }
        }
        #endregion
        #region LongOut
        public static List<LongOut> GetLongOuts()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                List<LongOut> longOut = db.Query<LongOut>("select * from LongOut").ToList();
                foreach (LongOut item in longOut)
                {
                    var student = FindStudent(item.cn_S);
                    item.Student = $"{student.SurName} {student.Name}";
                }
                return longOut;
            }
        }
        public static List<LongOut> LongOutAdd(LongOut longOut)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                return db.Query<LongOut>($"exec AddLongOut {longOut.cn_S}, '{longOut.Departure_Date.ToShortDateString()}'," +
                    $" '{longOut.Departure_Time}', '{longOut.Arrival_Date.ToShortDateString()}'," +
                    $" '{longOut.Arrival_Time}', {longOut.Absence_Reason}").ToList();
            }
        }
        public static List<LongOut> LongOutEdit(LongOut longOut)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                return db.Query<LongOut>($"exec EditLongOut {longOut.cn_S}, '{longOut.Departure_Date.ToShortDateString()}'," +
                    $" '{longOut.Departure_Time}', '{longOut.Arrival_Date.ToShortDateString()}'," +
                    $" '{longOut.Arrival_Time}', {longOut.Absence_Reason}").ToList();
            }
        }
        public static List<LongOut> LongOutDel(LongOut longOut)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                return db.Query<LongOut>($"exec DelLongOut {longOut.cn_S}").ToList();
            }
        }
        public static List<string> GetReasons()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                };
                return db.Query<string>("select * from Absence_Reason").ToList();

            }
        }
        #endregion
        #region Reports
        public static IEnumerable<dynamic> WeekendOutReports(DateTime firstDate, DateTime secondDate)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }
                return db.Query($"select Room.id_Room, Student.SurName as Student, Student.cn_G, Employer.SurName as Curator, WeekendOut.Departure_Date, WeekendOut.Departure_Time, WeekendOut.Arrival_Date, WeekendOut.Arrival_Time from Curator, Employer, Hostel, Room, Student, WeekendOut where Curator.cn_C = Employer.cn_E and Hostel.id_Room = room.id_Room and Student.cn_S = Hostel.cn_S and Curator.cn_G = Student.cn_G and WeekendOut.cn_S = Student.cn_S and WeekendOut.Departure_Date between '{firstDate}' and '{secondDate}' order by WeekendOut.Departure_Date");
            }
        }
        public static IEnumerable<dynamic> InhabitatedReports()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }
                return db.Query($"select Room.id_Room, Student.SurName as SurName,Student.Name as Name, Student.cn_G, Employer.SurName as Curator from Curator, Employer, Hostel, Room, Student where Curator.cn_C = Employer.cn_E and Hostel.id_Room = room.id_Room and Student.cn_S = Hostel.cn_S and Curator.cn_G = Student.cn_G order by Room.Room_number");
            }
        }
        #endregion
    }
}
