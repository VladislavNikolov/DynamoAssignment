using DynamoAssignment.Shared;

namespace DynamoAssignment.Services
{
    public interface IFileManager
    {
        public Task<ServiceResponse> HandleFile(string fileContents, string fileName);
    }
}
