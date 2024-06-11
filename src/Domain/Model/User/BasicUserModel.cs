namespace Domain.Model.User
{
    public class BasicUserModel
    {
        public string? IdUser { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? SecondLastName { get; set; }
        public int? Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Profile { get; set; }
    }
}
