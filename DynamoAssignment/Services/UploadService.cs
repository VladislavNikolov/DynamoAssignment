using DynamoAssignment.Shared;

namespace DynamoAssignment.Services
{
    public class UploadService : IUploadService
    {
        private readonly string baseUploadPath;

        public UploadService() {
            baseUploadPath = Path.Combine(Directory.GetCurrentDirectory(), Constants.UploadsFolder);
        }

        public UploadService(string baseUploadPath)
        {
            this.baseUploadPath = baseUploadPath;
        }

        public async Task UploadFile(string fileContents, string fileName)
        {
            Directory.CreateDirectory(baseUploadPath);

            var uploadPath = Path.Combine(baseUploadPath, fileName);

            await File.WriteAllTextAsync(uploadPath, fileContents);
        }
    }
}
