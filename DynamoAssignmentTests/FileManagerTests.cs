using DynamoAssignment.Services;
using DynamoAssignment.Shared;
using Moq;

namespace DynamoAssignmentTests
{
    [TestFixture]
    public class FileManagerTests
    {
        private readonly string fileName = "test.xml";
        private readonly string validXmlFileContents = "<root><data>test</data></root>";
        private readonly string corruptedXmlFileContents = "corrupted xml content";

        private Mock<IUploadService> uploadServiceMock;
        private FileManager fileManager;

        [SetUp]
        public void SetUp()
        {
            uploadServiceMock = new Mock<IUploadService>();
            fileManager = new FileManager(uploadServiceMock.Object);
        }

        [Test]
        public async Task HandleFile_ValidXmlFile_ReturnsSuccess()
        {
            // Arrange

            // Act
            var result = await fileManager.HandleFile(validXmlFileContents, fileName);

            // Assert
            uploadServiceMock.Verify(
                service => service.UploadFile(It.IsAny<string>(), It.Is<string>(name => name.EndsWith(Constants.JsonExtension))),
                Times.Once);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.IsSuccess, Is.True);
        }

        [Test]
        public async Task HandleFile_CorruptedXmlFile_ReturnsCorruptedFileError()
        {
            // Arrange

            // Act
            var result = await fileManager.HandleFile(corruptedXmlFileContents, fileName);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.False);
                Assert.That(result.ErrorMessage, Is.EqualTo(Constants.CorruptedFileErrorMessage));
            });
        }

        [Test]
        public async Task HandleFile_IOException_ReturnsUploadFolderError()
        {
            // Arrange
            uploadServiceMock.Setup(service => service.UploadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<IOException>();

            // Act
            var result = await fileManager.HandleFile(validXmlFileContents, fileName);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.False);
                Assert.That(result.ErrorMessage, Is.EqualTo(Constants.UploadFolderErrorMessage));
            });
        }

        [Test]
        public async Task HandleFile_GenericException_ReturnsInternalServerError()
        {
            // Arrange
            uploadServiceMock.Setup(service => service.UploadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<Exception>();

            // Act
            var result = await fileManager.HandleFile(validXmlFileContents, fileName);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.False);
                Assert.That(result.ErrorMessage, Is.EqualTo(Constants.InternalServerErrorMessage));
            });
        }
    }
}