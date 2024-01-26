using DynamoAssignment.Shared;

namespace DynamoAssignment.Services
{
    public class UploadService : IUploadService
    {
        private readonly string baseUploadPath =
            Path.Combine(Directory.GetCurrentDirectory(), Constants.UploadsFolder);

        public async Task UploadFile(string fileContents, string fileName)
        {
            Directory.CreateDirectory(baseUploadPath);

            var uploadPath = Path.Combine(baseUploadPath, fileName);

            await File.WriteAllTextAsync(uploadPath, fileContents);
        }
    }
}
