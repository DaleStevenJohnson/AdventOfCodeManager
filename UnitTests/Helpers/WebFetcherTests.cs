using GUI.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Helpers
{
    [TestClass]
    public class WebFetcherTests
    {
        [TestMethod]
        public void GetHtml()
        {
            var text = WebFetcher.GetChallengeText("2018", "1");
            Assert.AreEqual(text[0], "-");
        }
    }
}
