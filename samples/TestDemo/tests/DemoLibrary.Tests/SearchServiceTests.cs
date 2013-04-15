using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using DemoLibrary.Mocks;

namespace DemoLibrary.Tests
{
    [TestFixture]
    public class SearchServiceTests
    {
        [Test]
        public void Search_EmptyQuery_ReturnsNoResults()
        {
            var client = new MockBeerSearchClient();
            var service = new SearchService(client);

            var results = service.Search("").Test();

            Assert.AreEqual(0, results.Count());
        }

        [Test]
        public void Search_NonEmptyQuery_ReturnsResultsFromClient()
        {
            var beer = new Beer(42, "Duff Dark");
            IEnumerable<Beer> beerResults = new List<Beer>() { beer };

            var client = new MockBeerSearchClient();
            client.SearchBody = _ => Task.FromResult(beerResults);
            var service = new SearchService(client);

            var results = service.Search("duff").Test();

            Assert.AreEqual(1, results.Count());
            Assert.AreEqual(beer.Id, results.First().Id);
            Assert.AreEqual(beer.Name, results.First().Name);
        }

        [Test]
        public void Search_TwoSearchesForSameQuery_UsesCacheForSecondSearch()
        {
            var query = "duff";
            var beer = new Beer(42, "Duff Dark");
            IEnumerable<Beer> beerResults = new List<Beer>() { beer };
            
            var client = new MockBeerSearchClient();
            client.SearchBody = _ => Task.FromResult(beerResults);
            var service = new SearchService(client);
            
            var results = service.Search(query).Test();
            
            Assert.AreEqual(1, results.Count());

            client.SearchBody = delegate { throw new Exception("this should not be called"); };

            results = service.Search(query).Test();

            Assert.AreEqual(1, results.Count());
        }
    }
}