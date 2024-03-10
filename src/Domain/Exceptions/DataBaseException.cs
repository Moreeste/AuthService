using Newtonsoft.Json;

namespace Domain.Exceptions
{
    public class DataBaseException : Exception
    {
        public readonly string Query;
        public readonly string Parameters;

        public DataBaseException(string query, object? parameters, string? error) : base(error)
        {
            Query = query;
            Parameters = JsonConvert.SerializeObject(parameters);
        }

        public DataBaseException(string query, object parameters) : base("Null Response")
        {
            Query = query;
            Parameters = JsonConvert.SerializeObject(parameters);
        }
    }
}
