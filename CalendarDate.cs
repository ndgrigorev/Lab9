using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public class CalendarDate
    {
        public int day; 
        public int month; 
        public int year;
        public static int count = 0;

        int[] longMonths = { 1, 3, 5, 7, 8, 10, 12 };

        public int Month
        {
            get => month;
            private set
            {
                if (value < 1)
                {
                    Console.WriteLine("Ошибка, месяц не может быть < 1");
                    month = 1;
                }
                else
                {
                    if (value > 12)
                    {
                        Console.WriteLine("Ошибка, месяц не может быть > 12");
                        month = 12;
                    }
                    else
                    {
                        month = value;
                    }
                }
            }
        }

        public int Day
        {
            get => day;
            private set
            {
                if (value < 1)
                {
                    Console.WriteLine("Ошибка, день не может быть < 1");
                    day = 1;
                }
                else
                {
                    if (value > MaxDays())
                    {
                        Console.WriteLine("Ошибка, в данном месяце не может быть столько дней");
                        day = MaxDays();
                    }
                    else
                    {
                        day = value;
                    }
                }
            }
        }

        public int Year
        {
            get => year;
            private set
            {
                if (value < 1)
                {
                    Console.WriteLine("Ошибка, время до нашей эры не поддерживается");
                    year = 1;
                }
                else
                {
                    year = value;
                }
            }
        }

        public CalendarDate() 
        {
            Day = 1;
            Month = 1;
            Year = 2024;
            count++;
        }

        public CalendarDate(int day, int month, int year)
        {
            Year = year;
            Month = month;
            Day = day;
            count++;
        }
        public CalendarDate(CalendarDate date)
        {
            Day = date.Day;
            Month = date.Month;
            Year = date.Year;
            count++;
        }

        public override string ToString()
        {
            return $"Дата: {Day}.{Month}.{Year}";
        }

        public bool IsLeapYear()
        {
            if (Year % 4 == 0 && Year % 100 != 0)
            {
                return true;
            }
            else { return false; }
        }

        public static bool IsLeapYear(CalendarDate date) 
        {
            if (date.Year % 4 == 0 && date.Year % 100 != 0)
            {
                return true;
            }
            else { return false; }
        }

        public static bool operator true(CalendarDate date)
        {
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            return date.Year > year || date.Year == year && (date.Month > month || date.Month == month && date.Day >= day);
        }

        public static bool operator false(CalendarDate date)
        {
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            return !(date.Year > year || date.Year == year && (date.Month > month || date.Month == month && date.Day >= day));
        }

        public static explicit operator int (CalendarDate date)
        {
            if (date.Month < 4)
            {
                return 1;
            }
            if (date.Month < 7)
            {
                return 2;
            }
            if (date.Month < 10)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }

        public static implicit operator string (CalendarDate date)
        {
            string s = "";
            if (date.Day <= 9)
            {
                s += "0";
            }
            s = s + date.Day.ToString() + '.';
            if (date.Month <= 9)
            {
                s += "0";
            }
            s = s + date.Month.ToString() + ".";
            if (date.Year <= 1000)
            {
                s += "0";
                if (date.Year <= 100)
                {
                    s += "0";
                    if (date.Year <= 10)
                    {
                        s += "0";
                    }
                }
            }
            s += date.Year.ToString();
            return s;
        }

        public int MaxDays()
        {
            if (longMonths.Contains(Month))
            {
                return 31;
            }
            else
            {
                if (Month == 2)
                {
                    if (IsLeapYear())
                    {
                        return 29;
                    }
                    else { return 28; }
                }
                else
                {
                    return 30;
                }
            }
        }
        public static CalendarDate operator +(CalendarDate date1, int addDays)
        {
            int maxDay = date1.MaxDays();
            if (addDays >= 0)
            {
                for (int i = 0; i < addDays; i++)
                {
                    if (date1.Day == maxDay)
                    {
                        if (date1.Month == 12)
                        {
                            date1.Month = 1;
                            date1.Year += 1;
                        }
                        else
                        {
                            date1.Month += 1;
                        }
                        date1.Day = 1;
                        maxDay = date1.MaxDays();
                    }
                    else
                    {
                        date1.Day += 1;
                    }
                }
                return date1;
            }
            else
            {
                for (int i = 0; i > addDays; i--)
                {
                    if (date1.Day == 1)
                    {
                        if (date1.Month == 1)
                        {
                            if (date1.Year == 1)
                            {
                                return date1;
                            }
                            date1.Month = 12;
                            date1.Year -= 1;
                        }
                        else
                        {
                            date1.Month -= 1;
                        }
                        date1.Day = date1.MaxDays();
                    }
                    else
                    {
                        date1.Day -= 1;
                    }
                }
                return date1;
            }
        }
        public static CalendarDate operator >>(CalendarDate date, int addMonths)
        {
            if (addMonths >= 0)
            {
                for (int i = 0; i < addMonths; i++)
                {
                    if (date.Month == 12)
                    {
                        date.Year += 1;
                        date.Month = 1;
                    }
                    else
                    {
                        date.Month += 1;
                    }
                }
            }
            else
            {
                for (int i = 0; i > addMonths; i--)
                {
                    if (date.Month == 1)
                    {
                        if (date.Year == 1)
                        {
                            Console.WriteLine("Ошибка, время до нашей эры не поддерживается");
                            return date;
                        }
                        date.Year -= 1;
                        date.Month = 12;
                    }
                    else
                    {
                        date.Month -= 1;
                    }
                }
            }
            return date;
        }
        public override bool Equals(Object obj)
        {
            if (obj is CalendarDate date)
            {
                return date.Year == Year && date.Month == Month && date.Day == Day;
            }
            return false;
        }
    }
}
