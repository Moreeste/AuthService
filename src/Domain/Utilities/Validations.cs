namespace Domain.Utilities
{
    public class Validations : IValidations
    {
        public bool ValidateId(string id)
        {
            return Guid.TryParse(id, out _);
        }
    }
}
