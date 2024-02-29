namespace Reservio.Core
{
    public class ReservationHelper
    {

        public static int GetReservationLimitationPerDay()
        {
            // You can modify this logic based on your specific requirements
            // For example, you can retrieve the value from a configuration file or database

            // In this example, we're returning a fixed value of 5 reservations per day
            return 1;
        }

        public static DateTime DetermineBookingDate(DateTime dateTime)
        {
            DateTime now = dateTime;
            DateTime yesterdayAt8AM = DateTimeLocal.GetDate().AddDays(-1).AddHours(8);
            DateTime todayAt8AM = DateTimeLocal.GetDate().AddHours(8);
            if (now > yesterdayAt8AM && now < todayAt8AM)
            {
                return DateTimeLocal.GetDate().Date;
            }
            else
            {
                return DateTimeLocal.GetDate().AddDays(1).Date;
            }
        }

        public static DayOfWeek DetermineBookingDayOfWeek()
        {
            if (DateTimeLocal.GetDateTime().Hour >= 8)
            {
                return DateTimeLocal.GetDateTime().AddDays(1).DayOfWeek;

            }
            else
            {
                return DateTimeLocal.GetDateTime().DayOfWeek;
            }
        }


        public static DateTime DetermineBookingDateTime()
        {
            if (DateTimeLocal.GetDateTime().Hour >= 8)
            {
                return DateTimeLocal.GetDateTime().AddDays(1);

            }
            else
            {
                return DateTimeLocal.GetDateTime();
            }
        }

        public static DateTime GetStartOfWeek()
        {
            DateTime currentDate = DateTime.Now;
            for (int i = 0; i < 7; i++)
            {
                int dayOfWeek = (int)currentDate.AddDays(-i).DayOfWeek;
                if (dayOfWeek == 1)
                {
                    return DateTime.Now.AddDays(-i);
                }
            }

            return DateTime.Now.AddDays(-7);
        }

        public static string[] GetRandomColors(int Length)
        {
            var randomColorArray = new string[Length];
            Random random = new Random();
            for (int i = 0; i < randomColorArray.Length; i++)
            {
                string randomColor = String.Format("#{0:X6}", random.Next(0x1000000));
                randomColorArray[i] = randomColor;

            }

            return randomColorArray;
        }

        public static (DateTime startOfWeek, DateTime endOfWeek) GetStartAndEndOfWeek(DateTime date)
        {
            DayOfWeek currentDayOfWeek = date.DayOfWeek;
            int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)currentDayOfWeek + 7) % 7;
            DateTime startOfWeek = date.AddDays(-daysUntilSunday); // Sunday
            DateTime endOfWeek = startOfWeek.AddDays(6); // Saturday

            return (startOfWeek, endOfWeek);
        }




    }
}