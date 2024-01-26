using System.Xml;
using DynamoAssignment.Shared;

namespace DynamoAssignment.Services
{
    public class FileManager : IFileManager
    {
        private readonly IUploadService _uploadService;

        public FileManager(IUploadService uploadService)
        {
            _uploadService = uploadService;
        }

        public async Task<ServiceResponse> HandleFile(string fileContents, string fileName)
        {
            try
            {
                var jsonFileContents = FileUtilities.ConvertXmlToJson(fileContents);

                var jsonFileName = fileName + Constants.JsonExtension;

                await _uploadService.UploadFile(jsonFileContents, jsonFileName);

                return new ServiceResponse();

            }
            catch (XmlException)
            {
                return new ServiceResponse(Constants.CorruptedFileErrorMessage);
            }
            catch(IOException)
            {
                return new ServiceResponse(Constants.UploadFolderErrorMessage);
            }
            catch(Exception)
            {
                return new ServiceResponse(Constants.InternalServerErrorMessage);
            }
        }
    }
}
