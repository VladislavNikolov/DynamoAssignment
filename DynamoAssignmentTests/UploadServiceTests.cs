using DynamoAssignment.Services;

namespace DynamoAssignmentTests
{
    [TestFixture]
    public class UploadServiceTests
    {
        private const string TestUploadsFolder = "TestUploads";
        private const string fileContents = "Test file contents";
        private const string fileName = "test.txt";

        private UploadService uploadService;

        [SetUp]
        public void SetUp()
        {
            uploadService = new UploadService(TestUploadsFolder);
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

            // Act
            await uploadService.UploadFile(fileContents, fileName);

            // Assert
            var filePath = Path.Combine(TestUploadsFolder, fileName);
            Assert.Multiple(() =>
            {
                Assert.That(File.Exists(filePath), Is.True);
                Assert.That(File.ReadAllText(filePath), Is.EqualTo(fileContents));
            });
        }

        [Test]
        public async Task UploadFile_NullFileContents_CreatesEmptyFile()
        {
            // Arrange

            // Act
            await uploadService.UploadFile(null, fileName);

            // Assert
            var filePath = Path.Combine(TestUploadsFolder, fileName);
            Assert.Multiple(() =>
            {
                Assert.That(File.Exists(filePath), Is.True);
                Assert.That(File.ReadAllText(filePath), Is.EqualTo(""));
            });
        }

        [Test]
        public void UploadFile_NullFileName_ThrowsArgumentNullException()
        {
            // Arrange

            // Act and Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await uploadService.UploadFile(fileContents, null));
        }
    }
}
