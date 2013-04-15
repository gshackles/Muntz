using System;

namespace DemoLibrary.Mocks
{
	using DemoLibrary;
	
	public partial class MockBeerSearchClient : IBeerSearchClient
	{
		public Func<string, System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<DemoLibrary.Beer>>> SearchBody { get; set; }
		public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<DemoLibrary.Beer>> Search(string query)
		{
			return SearchBody(query);
		}
	}
}
