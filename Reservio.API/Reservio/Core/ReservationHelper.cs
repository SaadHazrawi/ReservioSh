﻿namespace Reservio.Core
{
    public class ReservationHelper
    {

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



    }
}