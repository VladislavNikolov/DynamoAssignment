namespace DynamoAssignment.Shared
{
    public static class Constants
    {
        public static readonly string UploadsFolder = "Uploads*-_`";

        public static readonly string XmlExtension = ".xml";
        public static readonly string JsonExtension = ".json";

        public static readonly string InvalidFileFormatErrorMessage = "Invalid file format! Only XML files are allowed.";
        public static readonly string CorruptedFileErrorMessage = "Corrupted file! Please verify its integrity.";
        public static readonly string UploadFolderErrorMessage = "Upload server is down! Please try again later.";
        public static readonly string InternalServerErrorMessage = "Something unexpected happened! Please contact support.";
    }
}
