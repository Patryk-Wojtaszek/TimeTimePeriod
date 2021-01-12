using System;

namespace TimeTimePeriod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Time time1 = new Time("12:00:50");
            Time time2= new Time("14:00:50");

            Console.WriteLine((time1 - time2));
            TimePeriod tp = new TimePeriod(time1, time2);
            TimePeriod tp1 = new TimePeriod("20:00:00");
            TimePeriod tp2 = new TimePeriod("21:11:11");

            Console.WriteLine(tp1-tp2);
           
          
        }
    }
}
