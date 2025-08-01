﻿namespace Domain.Model.User
{
    public class UserModel
    {
        public string? IdUser { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string? RegistrationUser { get; set; }
        public DateTime UpdateDate { get; set; }
        public string? UpdateUser { get; set; }
        public string? IdProfile { get; set; }
    }
}
