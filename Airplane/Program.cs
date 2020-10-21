using System;

namespace Airplane
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static Airplane[] ReadAirplaneArray(int n)
        {
            Date date = new Date();
            Airplane[] airplane = new Airplane[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(i + 1 + "\nВведіть місто відправлення ");
                airplane[i].setStartCity(Convert.ToString(Console.ReadLine()));
                Console.WriteLine("\nВведіть місто прибуття ");
                airplane[i].setFinishCity(Console.ReadLine());
                Console.WriteLine("\nВведіть дату відправлення \nРік ");
                airplane[i].StartDate.setYear(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("\nМісяць ");
                airplane[i].StartDate.setMonth(Int32.Parse(Console.ReadLine()));
                Console.WriteLine("\nДень ");
                airplane[i].StartDate.setDay(Int32.Parse(Console.ReadLine()));
                Console.WriteLine("\nГодина ");
                airplane[i].StartDate.setHours(Int32.Parse(Console.ReadLine()));
                Console.WriteLine("\nХвилина ");
                airplane[i].StartDate.setMinutes(Int32.Parse(Console.ReadLine()));

            }
            return airplane;
        }
        static void PrintAirplane(Airplane airplane)
        {
            Console.WriteLine("Місто відправлення - " + airplane.getStartCity());
            Console.WriteLine("Місто прибуття - " + airplane.getFinishCity());
            Console.WriteLine("Дата відправлення: {airplane.StartDate.getYear()} / {airplane.StartDate.getMonth()} / {airplane.StartDate.getDay()} { airplane.StartDate.getHours()}" +
                " :  { airplane.StartDate.getMinutes()}");
            Console.WriteLine("Дата прибуття - " + airplane.FinishDate.getYear() + "/"
                + airplane.FinishDate.getMonth() + "/" + airplane.FinishDate.getDay() + " "
                + airplane.FinishDate.getHours() + ":" + airplane.FinishDate.getMinutes());
        }
        static void PrintAirplanes(Airplane[] airplanes)
        {
            for (int i = 0; i < airplanes.Length; i++)
            {
                Console.WriteLine("\n");
                PrintAirplane(airplanes[i]);
            }
        }
        static void GetAirplaneInfo(Airplane[] airplanes, out int maxTime, out int minTime)
        {
            int totalTime = maxTime = minTime = airplanes[0].GetTotalTime();
            for (int i = 1; i < airplanes.Length; i++)
            {
                totalTime = airplanes[i].GetTotalTime();
                if (totalTime > maxTime)
                    maxTime = totalTime;

                if (totalTime < minTime)
                    minTime = totalTime;
            }
        }
    }

    class Airplane
    {
        private string StartCity;
        private string FinishCity;
        public Date StartDate { get; set; }
        public Date FinishDate { get; set; }
        public void setStartCity(string val) { StartCity = val; }
        public string getStartCity() { return StartCity; }

        public void setFinishCity(string val) { FinishCity = val; }
        public string getFinishCity() { return FinishCity; }


        public Airplane(string startCity = "unknow", string finishCity = "unknow", Date startDate = null, Date finishDate = null)
        {
            StartCity = startCity;
            FinishCity = finishCity;
            StartDate = startDate;
            FinishDate = finishDate;
        }

        public Airplane(Airplane other)
        {
            StartCity = other.StartCity;
            FinishCity = other.FinishCity;
            StartDate = other.StartDate;
            FinishDate = other.FinishDate;
        }

        public int GetTotalTime()
        {
            int hour, minute;
            hour = FinishDate.getHours() - StartDate.getHours();
            minute = FinishDate.getMinutes() - StartDate.getMinutes();
            return hour * 60 + minute;
        }
        public bool IsArrivingToday()
        {
            if (StartDate.getYear() == FinishDate.getYear() && StartDate.getMonth() == FinishDate.getMonth() && StartDate.getDay() == FinishDate.getDay())
                return true;
            else return false;
        }
    }
    class Date
    {
        private int Year;
        private int Month;
        private int Day;
        private int Hours;
        private int Minutes;

        public void setYear(int val) { Year = val; }
        public int getYear() { return Year; }

        public void setMonth(int val) { Month = val; }
        public int getMonth() { return Month; }

        public void setDay(int val) { Day = val; }
        public int getDay() { return Day; }

        public void setHours(int val) { Hours = val; }
        public int getHours() { return Hours; }

        public void setMinutes(int val) { Minutes = val; }
        public int getMinutes() { return Minutes; }

        public Date(int year= 0, int month=0, int day=0, int hours=0, int minutes=0)
        {
            Year = year;
            Month = month;
            Day = day;
            Hours = hours;
            Minutes = minutes;
        }
    }
}
