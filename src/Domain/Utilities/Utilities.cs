namespace Domain.Utilities
{
    public class Utilities : IUtilities
    {
        public string GenerateId()
        {
            return Guid.NewGuid().ToString();
        }

        public DateTime GetDateTime()
        {
            string timeZone = "Central America Standard Time";
            return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, timeZone);
        }

        public DateTimeOffset GetDateTimeOffset()
        {
            string timeZoneId = "Central America Standard Time";
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            DateTime dateTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, timeZone);
            TimeSpan offset = timeZone.GetUtcOffset(dateTime);
            return new DateTimeOffset(dateTime, offset);
        }
    }
}
