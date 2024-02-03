using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    internal class CalendarDateArray
    {
        static Random Random = new Random();

        CalendarDate[] dates;
        public static int count = 0;

        public int Length
        {
            get => dates.Length;
        }

        public CalendarDateArray()
        {
            dates = new CalendarDate[1];
            dates[0] = new CalendarDate(1, 1, 2024);
            count++;
        }

        public CalendarDateArray(int length)
        {
            dates = new CalendarDate[length];
            for (int i = 0; i < length; i++)
            {
                dates[i] = new CalendarDate(Random.Next(1, 32), Random.Next(1, 13), Random.Next(1, 2100));
            }
            count++;
        }

        public CalendarDateArray(int length, bool check)
        {
            dates = new CalendarDate[length];
            int day;
            int month;
            int year;
            bool isConvert;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("Введите день");
                do
                {
                    isConvert = int.TryParse(Console.ReadLine(), out day);
                } while (!isConvert);
                Console.WriteLine("Введите месяц");
                do
                {
                    isConvert = int.TryParse(Console.ReadLine(), out month);
                } while (!isConvert);
                Console.WriteLine("Введите год");
                do
                {
                    isConvert = int.TryParse(Console.ReadLine(), out year);
                } while (!isConvert);
                dates[i] = new CalendarDate(day, month, year);
            }
            count++;
        }
        public void Show()
        {
            for (int i = 0;i < dates.Length;i++)
            {
                Console.WriteLine(dates[i]);
            }
        }

        public CalendarDateArray(CalendarDateArray array)
        {
            dates = new CalendarDate[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                dates[i] = new CalendarDate(array.dates[i]);
            }
            count++;
        }

        public CalendarDate this[int index]
        {
            get
            {
                if (index >= 0 && index < dates.Length)
                {
                    return dates[index];
                }
                else
                {
                    throw new Exception("Индекс выходит за пределы коллекции");
                }
            }
            set 
            {
                if (index >= 0 && index < dates.Length)
                {
                    dates[index] = value;
                }
                else
                {
                    throw new Exception("Индекс выходит за пределы коллекции");
                }
            }
        }
    }
}
