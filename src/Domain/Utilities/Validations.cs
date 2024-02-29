using System.Text.RegularExpressions;

namespace Domain.Utilities
{
    public class Validations : IValidations
    {
        public bool BeValidId(string id)
        {
            return Guid.TryParse(id, out _);
        }

        public bool BeValidPhoneNumber(string phone)
        {
            string regexPattern = @"^\d{10}$";
            return Regex.IsMatch(phone, regexPattern);
        }

        public bool BeValidName(string name)
        {
            string regexPattern = @"^[a-zA-Z]+$";
            return Regex.IsMatch(name, regexPattern);
        }

        public bool BeValidBirthDate(DateTime birthDate)
        {
            DateTime minDate = new DateTime(1900, 1, 1);
            DateTime maxDate = DateTime.Now;
            return birthDate >= minDate && birthDate <= maxDate;
        }
    }
}
