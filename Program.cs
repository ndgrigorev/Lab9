namespace Lab9
{
    internal class Program
    {
        static int SameYear(CalendarDateArray array)
        {
            int[] allYears = new int[array.Length];
            int j = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (!allYears.Contains(array[i].year))
                {
                    allYears[j] = array[i].year;
                    j++;
                }
            }
            int max = 0;
            for (int i = 0; i < allYears.Length; i++)
            {
                int count = 0;
                for(int k = 0; k < array.Length; k++)
                {
                    if (array[k].year == allYears[i])
                    {
                        count++;
                    }
                }
                if (count > max)
                {
                    max = count;
                }
            }
            return max;
        }
        static void Main(string[] args)
        {
            CalendarDate date1 = new CalendarDate(4, 1, 2024);
            CalendarDate date2 = new CalendarDate(date1);
            Console.WriteLine(date1);
            Console.WriteLine(date2);
            Console.WriteLine($"Создано {CalendarDate.count} объектов");
            Console.WriteLine(date1.IsLeapYear());
            Console.WriteLine(CalendarDate.IsLeapYear(date1));
            if (date1)
            {
                Console.WriteLine("Это дата = текущей или в будущем");
            }
            else
            {
                Console.WriteLine("Это прошлая дата");
            }
            string s = date1;
            int x = (int)date1;
            Console.WriteLine(s);
            Console.WriteLine(x);
            date1 = date1 + (-2);
            date1 = date1 >> -3;
            Console.WriteLine($"Первая дата: {date1}");
            Console.WriteLine($"Вторая дата: {date2}");
            CalendarDateArray array1 = new CalendarDateArray(5);
            CalendarDateArray array2 = new CalendarDateArray(3, true);
            CalendarDateArray array3 = new CalendarDateArray(array1);
            Console.WriteLine("array 1");
            array1.Show();
            Console.WriteLine("array 2");
            array2.Show();
            Console.WriteLine("array 3");
            array3.Show();
            array1[0] = new CalendarDate(3, 5, 2021);
            Console.WriteLine("array 1");
            array1.Show();
            Console.WriteLine("array 3");
            array3.Show();
            Console.WriteLine(array3[0]);
            try
            {
                Console.WriteLine(array1[30]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                array1[30] = new CalendarDate(1, 2, 3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(SameYear(array2));
            Console.WriteLine($"Создано {CalendarDateArray.count} коллекций");
            Console.WriteLine($"Создано {CalendarDate.count} объектов");
        }
    }
}