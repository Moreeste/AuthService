namespace Domain.Utilities
{
    public class Utilities : IUtilities
    {
        public string GenerateId()
        {
            return Guid.NewGuid().ToString().ToUpper();
        }

        public DateTime GetDateTime()
        {
            string timeZone = "Central America Standard Time";
            return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, timeZone);
        }
    }
}
