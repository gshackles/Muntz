using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class SearchService
    {
        private readonly IBeerSearchClient _client;
        private readonly IDictionary<string, IEnumerable<Beer>> _searchCache = new Dictionary<string, IEnumerable<Beer>>();

        public SearchService(IBeerSearchClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Beer>> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return new List<Beer>();

            if (_searchCache.ContainsKey(query))
                return _searchCache[query];

            var beers = await _client.Search(query);

            _searchCache[query] = beers;

            return beers;
        }
    }
}