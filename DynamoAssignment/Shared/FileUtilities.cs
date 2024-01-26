using Newtonsoft.Json;
using System.Xml.Linq;

namespace DynamoAssignment.Shared
{
    public static class FileUtilities
    {
        public static string ConvertXmlToJson(string xml)
        {
            var doc = XDocument.Parse(xml);

            return JsonConvert.SerializeXNode(doc, Formatting.Indented);
        }
    }
}
