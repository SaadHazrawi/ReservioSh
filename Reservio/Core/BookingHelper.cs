namespace Reservio.Core
{
    public class BookingHelper
    {

        public static DateTime BookFor(DateTime dateTime)
        {
            DateTime now = dateTime;
            DateTime yesterdayAt8PM = DateTimeLocal.GetDate().AddDays(-1).AddHours(8);
            DateTime todayAt8AM = DateTimeLocal.GetDate().AddHours(8);
            if (now > yesterdayAt8PM && now < todayAt8AM)
            {
                return DateTimeLocal.GetDate().Date;
            }
            else
            {
                return DateTimeLocal.GetDate().AddDays(1).Date;
            }
        }

        public static DayOfWeek GetDayForBooking()
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
    }
}