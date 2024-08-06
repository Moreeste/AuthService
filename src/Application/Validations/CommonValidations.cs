using Domain.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
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

        public bool BeValidRequiredName(string name)
        {
            string regexPattern = @"^[a-zA-Z]+$";
            return Regex.IsMatch(name, regexPattern);
        }

        public bool BeValidOptionalName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return true;
            }

            string regexPattern = @"^[a-zA-Z]+$";
            return Regex.IsMatch(name, regexPattern);
        }

        public bool BeValidBirthDate(DateTime birthDate)
        {
            DateTime minDate = new DateTime(1900, 1, 1);
            DateTime maxDate = DateTime.Now;
            return birthDate >= minDate && birthDate <= maxDate;
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

        public bool BeValidPositiveInteger(string text)
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

        public bool BeAValidBase64String(string text)
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

        public bool BeAValidJwt(string jwt)
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

        public bool BeAValidHttpMethod(string method)
        {
            if (string.IsNullOrEmpty(method))
            {
                return true;
            }

            string[] ValidHttpMethods = { "GET", "POST", "PUT", "DELETE" };
            return ValidHttpMethods.Contains(method.ToUpper());
        }
    }
}
