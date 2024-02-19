namespace Domain.Utilities
{
    public interface IUtilities
    {
        string GenerateId();
        DateTime GetDateTime();
        DateTimeOffset GetDateTimeOffset();
    }
}
