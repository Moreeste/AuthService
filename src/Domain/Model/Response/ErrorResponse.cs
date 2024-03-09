namespace Domain.Model.Response
{
    public class ErrorResponse
    {
        public string? ErrorId { get; set; }
        public string? ErrorMessage { get; set; }

        public ErrorResponse(string errorId, string errorMessage)
        {
            ErrorId = errorId;
            ErrorMessage = errorMessage;
        }
    }
}
