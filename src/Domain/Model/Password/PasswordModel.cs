namespace Domain.Model.Password
{
    public class PasswordModel
    {
        public string? Password { get; set; }
        public string? Salt { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int FailedAttempts { get; set; }
        public DateTime LastAttemptDate { get; set; }
    }
}
