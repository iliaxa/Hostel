using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
//using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
namespace WpfApplicationEntity.API
{
    public static class Reports
    {
        private static string IsDepartured(bool? isDep)
        {
            if (!isDep.HasValue)
            {
                return "Не отмечен";

            }
            else if (!isDep.Value)
            {
                return "Приехал";
            }
            else
            {
                return "Выехал";
            }
        }
        public static void ReportWeekendOuts(DateTime firstDate, DateTime secondDate)
        {
            Excel.Application exApp = new Excel.Application();
            exApp.Workbooks.Add();
            Excel._Worksheet workSheet = (Excel.Worksheet)exApp.ActiveSheet;
            workSheet.Cells[1].EntireRow.Font.Bold = true;
            workSheet.Cells.EntireRow.Font.Size = 14;
            workSheet.Cells.EntireRow.Font.Name = "Times New Roman";
            workSheet.Cells[1, 1] = "Комната";
            workSheet.Cells[1, 2] = "Студент";
            workSheet.Cells[1, 3] = "Группа";
            workSheet.Cells[1, 4] = "Куратор";
            workSheet.Cells[1, 5] = "Дата отъезда";
            workSheet.Cells[1, 6] = "Время отъезда";
            workSheet.Cells[1, 7] = "Дата приезда";
            workSheet.Cells[1, 8] = "Время отъезда";
            workSheet.Columns.ColumnWidth = 18;
            var list = DataService.WeekendOutReports(firstDate, secondDate);
            int i = 2;
            foreach (var item in list)
            {
                var DT = Convert.ToString(item.Departure_Time);
                var AT = Convert.ToString(item.Arrival_Time);

                workSheet.Cells[i, 1] = item.id_Room;
                workSheet.Cells[i, 2] = item.Student;
                workSheet.Cells[i, 3] = GridsInfo.GetGroupRus(item.cn_G);
                workSheet.Cells[i, 4] = item.Curator;
                workSheet.Cells[i, 5] = item.Departure_Date;
                workSheet.Cells[i, 6] = DT;
                workSheet.Cells[i, 7] = item.Arrival_Date;
                workSheet.Cells[i, 8] = AT;
                i++;
            }
            string path = Environment.CurrentDirectory + "\\Weekend_OutsReport.xlsx";
            workSheet.SaveAs(path);
            exApp.Quit();
            Process.Start(path);
        }
        public static void ReportInhabitated()
        {
            Excel.Application exApp = new Excel.Application();
            exApp.Workbooks.Add();
            Excel._Worksheet workSheet = (Excel.Worksheet)exApp.ActiveSheet;
            workSheet.Cells[1].EntireRow.Font.Bold = true;
            workSheet.Cells.EntireRow.Font.Size = 14;
            workSheet.Cells.EntireRow.Font.Name = "Times New Roman";
            workSheet.Cells[1, 1] = "Комната";
            workSheet.Cells[1, 2] = "Студент";
            workSheet.Cells[1, 3] = "Группа";
            workSheet.Cells[1, 4] = "Куратор";
            workSheet.Columns[1].ColumnWidth = 11;
            workSheet.Columns[2].ColumnWidth = 30;
            workSheet.Columns[3].ColumnWidth = 9;
            workSheet.Columns[4].ColumnWidth = 15;

            var list = DataService.InhabitatedReports();
            int i = 2;
            foreach (var item in list)
            {
                workSheet.Cells[i, 1] = item.id_Room;
                workSheet.Cells[i, 2] = $"{item.SurName} {item.Name}";
                workSheet.Cells[i, 3] = GridsInfo.GetGroupRus(item.cn_G);
                workSheet.Cells[i, 4] = item.Curator;
                i++;
            }
            string path = Environment.CurrentDirectory + "\\InhabitatedReport.xlsx";
            workSheet.SaveAs(path);
            exApp.Quit();
            Process.Start(path);
        }
    }
}
