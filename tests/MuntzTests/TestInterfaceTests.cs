using MuntzDefinitions.Mocks;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MuntzTests
{
    [TestFixture]
    public class TestInterfaceTests
    {
        private MockTestInterface _testInterface;

        [SetUp]
        public void SetUp()
        {
            _testInterface = new MockTestInterface();
        }

        [Test]
        public void ReturnsVoidNoParameters()
        {
            bool success = false;
            _testInterface.ReturnsVoidNoParametersBody = () => success = true;

            _testInterface.ReturnsVoidNoParameters();

            Assert.IsTrue(success);
        }

        [Test]
        public void ReturnsStringNoParameters() 
        {
            _testInterface.ReturnsStringNoParametersBody = () => "foo";

            var result = _testInterface.ReturnsStringNoParameters();

            Assert.AreEqual("foo", result);
        }

        [Test]
        public void ReturnsStringWithParameters()
        {
            _testInterface.ReturnsStringWithParametersBody = _ => "foo";

            var result = _testInterface.ReturnsStringWithParameters(0);

            Assert.AreEqual("foo", result);
        }

        [Test]
        public void ReturnsTaskNoParameters()
        {
            _testInterface.ReturnsTaskNoParametersBody = () => Task.FromResult<object>("foo");

            var result = _testInterface.ReturnsTaskNoParameters();

            Assert.AreEqual("foo", result.Result);
        }

        [Test]
        public void ReturnsTaskWithParameters()
        {
            _testInterface.ReturnsTaskWithParametersBody = (i, o) => Task.FromResult<object>("foo");

            var result = _testInterface.ReturnsTaskWithParameters(0, null);

            Assert.AreEqual("foo", result.Result);
        }
    }
}