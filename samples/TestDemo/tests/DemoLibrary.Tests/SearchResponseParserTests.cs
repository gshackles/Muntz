using NUnit.Framework;

namespace DemoLibrary.Tests
{
    [TestFixture]
    public class SearchXmlResponseParserTests
    {
        [Test]
        public void ParseBeer_ValidXml_ReturnsBeer()
        {
            string xml = @"
                <Beer>
                    <Id>42</Id>
                    <Name>Duff Dark</Name>
                </Beer>";
            var parser = new SearchXmlResponseParser();

            var beer = parser.ParseBeer(xml);

            Assert.NotNull(beer);
            Assert.AreEqual(42, beer.Id);
            Assert.AreEqual("Duff Dark", beer.Name);
        }
    }
}