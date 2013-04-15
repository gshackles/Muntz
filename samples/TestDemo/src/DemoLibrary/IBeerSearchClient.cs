using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public interface IBeerSearchClient
    {
        Task<IEnumerable<Beer>> Search(string query);
    }
}