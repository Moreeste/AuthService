namespace Application.Validations
{
    public interface ICommonValidations
    {
        bool BeValidId(string id);
        bool BeRequiredName(string name);
        bool BeValidBirthDate(string birthDate);
        bool BeValidPhoneNumber(string phone);
        Task <bool> BeValidGenderId(int gender, CancellationToken cancellationToken);
        bool BeOnlyLettersAndNumbers(string text);
        bool BePositiveInteger(string text);
        bool BeTextNumberWithinRange(string text, int minValue, int maxValue);
        Task<bool> BeValidStatusId(int status, CancellationToken cancellationToken);
        bool BeValidBase64String(string text);
        bool BeValidJwt(string jwt);
        bool BeTextAndSlash(string text);
        bool BeValidEndpoint(string path);
        bool BeValidHttpMethod(string method);
        bool BeZeroOrOneString(string text);
    }
}
