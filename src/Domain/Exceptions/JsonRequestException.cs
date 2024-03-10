namespace Domain.Exceptions
{
    public class JsonRequestException : Exception
    {
        public JsonRequestException() : base("Invalid JSON structure")
        {

        }
    }
}
