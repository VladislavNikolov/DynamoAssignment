namespace DynamoAssignment.Shared
{
    public class ServiceResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }

        public ServiceResponse()
        {
            IsSuccess = true;
            ErrorMessage = string.Empty;
        }

        public ServiceResponse(string message)
        {
            IsSuccess = false;
            ErrorMessage = message;
        }
    }
}
