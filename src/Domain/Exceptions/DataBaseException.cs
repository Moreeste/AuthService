using Newtonsoft.Json;

namespace Domain.Exceptions
{
    public class DataBaseException : Exception
    {
        public readonly string query;
        public readonly string parameters;

        public DataBaseException(string query, object? parameters, string? error) : base(error)
        {
            this.query = query;
            this.parameters = JsonConvert.SerializeObject(parameters);
        }

        public DataBaseException(string query, object parameters) : base("Null Response")
        {
            this.query = query;
            this.parameters = JsonConvert.SerializeObject(parameters);
        }
    }
}
