namespace Domain.Utilities
{
    public interface IValidations
    {
        bool BeValidId(string id);
        bool BeValidPhoneNumber(string phone);
        bool BeValidName(string name);
    }
}
