using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using DynamoAssignment.Services;
using DynamoAssignment.Shared;

namespace DynamoAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadsController : ControllerBase
    {
        private readonly IFileManager _fileManager;

        public UploadsController(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest();
            }

            if (Path.GetExtension(file.FileName) != Constants.XmlExtension)
            {
                return BadRequest(Constants.InvalidFileFormatErrorMessage);
            }

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                stream.Position = 0;
                var fileContent = new StreamReader(stream).ReadToEnd();

                var result = _fileManager.HandleFile(fileContent, Path.GetFileNameWithoutExtension(file.FileName));

                if (!result.Result.Success)
                {
                    return BadRequest(result.Result.Message);
                }

                return Ok();
            }
        }
    }
}
