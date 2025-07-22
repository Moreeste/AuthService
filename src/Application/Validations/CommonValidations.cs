using Domain.Repository;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Text.RegularExpressions;

namespace Application.Validations
{
    public class CommonValidations : ICommonValidations
    {
        private readonly ICatalogueRepository _catalogueRepository;

        public CommonValidations(ICatalogueRepository catalogueRepository)
        {
            _catalogueRepository = catalogueRepository;
        }

        public bool BeValidId(string id)
        {
            return Guid.TryParse(id, out _);
        }

        public bool BeRequiredName(string name)
        {
            string regexPattern = @"^[a-zA-Z\s]+$";
            return Regex.IsMatch(name, regexPattern);
        }

        public bool BeValidBirthDate(string birthDate)
        {
            DateTime minDate = new DateTime(1900, 1, 1);
            DateTime maxDate = DateTime.Now;

            if (DateTime.TryParseExact(birthDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                return parsedDate >= minDate && parsedDate <= maxDate;
            }

            return false;
        }

        public bool BeValidPhoneNumber(string phone)
        {
            string regexPattern = @"^\d{10}$";
            return Regex.IsMatch(phone, regexPattern);
        }
        
        public async Task<bool> BeValidGenderId(int gender, CancellationToken cancellationToken)
        {
            var genders = await _catalogueRepository.GetGenders();
            return genders.Any(x => x.IdGender == gender);
        }

        public bool BeOnlyLettersAndNumbers(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            string regexPattern = @"^[a-zA-Z0-9]*$";
            return Regex.IsMatch(text, regexPattern);
        }

        public bool BePositiveInteger(string text)
        {
            if (!int.TryParse(text, out int number))
                return false;

            return number > 0;
        }

        public bool BeTextNumberWithinRange(string text, int minValue, int maxValue)
        {
            if (!int.TryParse(text, out int number))
                return false;

            return number >= minValue && number <= maxValue;
        }

        public async Task<bool> BeValidStatusId(int status, CancellationToken cancellationToken)
        {
            var catStatus = await _catalogueRepository.GetUserStatus();
            return catStatus.Any(x => x.IdStatus == status);
        }

        public bool BeValidBase64String(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            if (text.Length % 4 != 0)
            {
                return false;
            }

            var base64Regex = new Regex(@"^[a-zA-Z0-9\+/]*={0,2}$", RegexOptions.None);
            return base64Regex.IsMatch(text);
        }

        public bool BeValidJwt(string jwt)
        {
            if (string.IsNullOrWhiteSpace(jwt))
            {
                return false;
            }

            var parts = jwt.Split('.');
            if (parts.Length != 3)
            {
                return false;
            }

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(jwt);
                return token != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool BeTextAndSlash(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return true;
            }

            string regexPattern = @"^[a-zA-Z0-9/-]*$";
            return Regex.IsMatch(text, regexPattern);
        }

        public bool BeValidEndpoint(string path)
        {
            string regexPattern = @"^\/[a-zA-Z0-9\/]*[a-zA-Z0-9]$";
            return Regex.IsMatch(path, regexPattern);
        }

        public bool BeValidHttpMethod(string method)
        {
            if (string.IsNullOrEmpty(method))
            {
                return true;
            }

            string[] ValidHttpMethods = { "GET", "POST", "PUT", "DELETE" };
            return ValidHttpMethods.Contains(method.ToUpper());
        }

        public bool BeZeroOrOneString(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return true;
            }

            if (text == "0" || text == "1")
            {
                return true;
            }

            return false;
        }
    }
}
