using System.Threading.Tasks;

namespace MuntzDefinitions
{
    public interface ITestInterface
    {
        void ReturnsVoidNoParameters();
        string ReturnsStringNoParameters();
        string ReturnsStringWithParameters(int i);
        Task<object> ReturnsTaskNoParameters();
        Task<object> ReturnsTaskWithParameters(int i, object o);
    }
}