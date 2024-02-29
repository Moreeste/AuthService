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
    }
}
