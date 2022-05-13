using System.Collections.Generic;
using System.Linq;
using System;

namespace WpfApplicationEntity.API
{
    public static class GridsInfo
    {
        public static string IsDepartured(bool? isDep)
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
        public static string GetGenderString(bool gender)
        {
            return gender ? "Женский" : "Мужской";
        }
        public static string GetGroupRus(string group)
        {
            switch (group[0])
            {
                case 'l':
                    group=group.Replace('l', 'Л');
                    break;
                case 'p':
                    group = group.Replace('p', 'П');
                    break;
                case 'b':
                    group = group.Replace('b', 'Б');
                    break;
                case 'u':
                    group = group.Replace('u', 'Ю');
                    break;
            }
            return group;
        }
        public static string GetGroupEng(string group)
        {
            switch (group[0])
            {
                case 'Л':
                    group = group.Replace('Л', 'l');
                    break;
                case 'П':
                    group = group.Replace('П', 'p');
                    break;
                case 'Б':
                    group = group.Replace('Б', 'b');
                    break;
                case 'Ю':
                    group = group.Replace('Ю', 'u');
                    break;
            }
            return group;
        }
    }
}
