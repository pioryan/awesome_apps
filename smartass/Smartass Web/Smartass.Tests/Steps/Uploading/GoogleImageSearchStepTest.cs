using System.Linq;
using Smartass.Models.Uploading;
using Smartass.Steps.Uploading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Smartass.Tests.Steps.Uploading
{
    [TestClass]
    public class GoogleImageSearchStepTest
    {
        private GoogleImageSearchStep fixture;

        [TestInitialize]
        public void SetUp()
        {
            this.fixture = new GoogleImageSearchStep();
        }

        [TestCleanup]
        public void TearDown()
        {
            this.fixture = null;
        }

        [TestMethod]
        public void TestMethod1()
        {
            var container = new Smartass.Models.Fakes.StubPlan(new Smartass.Models.Fakes.StubIPlanRequest());
            this.fixture.RunAsync(container).Wait();
            Assert.IsInstanceOfType(container.Dockets.Single(), typeof(GoogleImageSearchDocket));
        }
    }
}
