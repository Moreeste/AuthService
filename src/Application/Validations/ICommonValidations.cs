namespace Application.Validations
{
    public interface ICommonValidations
    {
        bool BeValidId(string id);
        bool BeValidPhoneNumber(string phone);
        bool BeValidName(string name);
        bool BeValidBirthDate(DateTime birthDate);
        Task <bool> BeValidGenderId(int gender, CancellationToken cancellationToken);
    }
}
