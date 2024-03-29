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
    }
}
