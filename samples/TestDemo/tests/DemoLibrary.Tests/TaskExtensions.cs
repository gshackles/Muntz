using System.Threading.Tasks;

namespace DemoLibrary.Tests
{
    public static class TaskExtensions
    {
        public static T Test<T>(this Task<T> task)
        {
            task.Wait();

            return task.Result;
        }
    }
}