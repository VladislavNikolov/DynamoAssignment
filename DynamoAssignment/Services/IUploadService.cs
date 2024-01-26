namespace DynamoAssignment.Services
{
    public interface IUploadService
    {
        public Task UploadFile(string fileContents, string fileName);
    }
}
