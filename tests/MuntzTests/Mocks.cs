using System;

namespace MuntzDefinitions.Mocks
{
	using MuntzDefinitions;
	
	public partial class MockTestInterface : ITestInterface
	{
		public Action ReturnsVoidNoParametersBody { get; set; }
		public void ReturnsVoidNoParameters()
		{
			ReturnsVoidNoParametersBody();
		}
		public Func<string> ReturnsStringNoParametersBody { get; set; }
		public string ReturnsStringNoParameters()
		{
			return ReturnsStringNoParametersBody();
		}
		public Func<int, string> ReturnsStringWithParametersBody { get; set; }
		public string ReturnsStringWithParameters(int i)
		{
			return ReturnsStringWithParametersBody(i);
		}
		public Func<System.Threading.Tasks.Task<System.Object>> ReturnsTaskNoParametersBody { get; set; }
		public System.Threading.Tasks.Task<System.Object> ReturnsTaskNoParameters()
		{
			return ReturnsTaskNoParametersBody();
		}
		public Func<int, object, System.Threading.Tasks.Task<System.Object>> ReturnsTaskWithParametersBody { get; set; }
		public System.Threading.Tasks.Task<System.Object> ReturnsTaskWithParameters(int i, object o)
		{
			return ReturnsTaskWithParametersBody(i, o);
		}
	}
}
