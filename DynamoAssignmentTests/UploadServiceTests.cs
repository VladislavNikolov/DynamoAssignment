using DynamoAssignment.Services;

namespace DynamoAssignmentTests
{
    [TestFixture]
    public class UploadServiceTests
    {
        private const string TestUploadsFolder = "TestUploads";

        [SetUp]
        public void SetUp()
        {
            CleanUpTestUploadsFolder();
        }

        [TearDown]
        public void TearDown()
        {
            CleanUpTestUploadsFolder();
        }

        private void CleanUpTestUploadsFolder()
        {
            if (Directory.Exists(TestUploadsFolder))
            {
                Directory.Delete(TestUploadsFolder, true);
            }
        }

        [Test]
        public async Task UploadFile_ValidFileContents_CreatesFile()
        {
            // Arrange
            var uploadService = new UploadService(TestUploadsFolder);

            var fileContents = "Test file contents";
            var fileName = "test.txt";

            // Act
            await uploadService.UploadFile(fileContents, fileName);

            // Assert
            var filePath = Path.Combine(TestUploadsFolder, fileName);
            Assert.That(File.Exists(filePath), Is.True);
            Assert.That(File.ReadAllText(filePath), Is.EqualTo(fileContents));
        }

        [Test]
        public void UploadFile_NullFileName_ThrowsArgumentNullException()
        {
            // Arrange
            var uploadService = new UploadService(TestUploadsFolder);

            var fileContents = "Test file contents";

            // Act and Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await uploadService.UploadFile(fileContents, null));
        }
    }
}
