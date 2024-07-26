namespace Application.Validations
{
    public interface ICommonValidations
    {
        bool BeValidId(string id);
        bool BeValidRequiredName(string name);
        bool BeValidOptionalName(string name);
        bool BeValidBirthDate(DateTime birthDate);
        bool BeValidPhoneNumber(string phone);
        Task <bool> BeValidGenderId(int gender, CancellationToken cancellationToken);
        bool BeOnlyLettersAndNumbers(string text);
        bool BeValidPositiveInteger(string text);
        bool BeTextNumberWithinRange(string text, int minValue, int maxValue);
        Task<bool> BeValidStatusId(int status, CancellationToken cancellationToken);
        bool BeAValidBase64String(string text);
        bool BeAValidJwt(string jwt);
        bool BeValidEndpoint(string path);
        bool BeAValidHttpMethod(string method);
    }
}
