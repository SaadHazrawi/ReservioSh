namespace Reservio.Core
{
    public static class DateTimeLocal
    {
       
        public static DateTime GetDateTime()
        {
            return DateTime.UtcNow.AddHours(3);
        }
        public static DateTime GetDate()
        {
            return DateTime.UtcNow.AddHours(3).Date;
        }
    }
}