using System.Xml.Serialization;
using System.IO;

namespace DemoLibrary
{
    public class SearchXmlResponseParser
    {
        public Beer ParseBeer(string response)
        {
            var serializer = new XmlSerializer(typeof(Beer));

            using (var reader = new StringReader(response))
            {
                return serializer.Deserialize(reader) as Beer;
            }
        }
    }
}