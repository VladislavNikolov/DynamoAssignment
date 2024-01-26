namespace DynamoAssignment.Shared
{
    public class ServiceResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public ServiceResponse()
        {
            Success = true;
            Message = string.Empty;
        }

        public ServiceResponse(string message)
        {
            Success = false;
            Message = message;
        }
    }
}
