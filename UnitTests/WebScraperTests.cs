using GUI.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class WebScraperTests
    {
        [TestMethod]
        public void GetTextFromHTML()
        {
            var url = "https://adventofcode.com/2018/day/1";
            var title = "Advent of Code";
            string html = WebScraper.GetHTMLString(url);
            var text = WebScraper.RemoveHTMLTagsFromString(html);
            Assert.AreEqual(title, text.Substring(0, title.Length));
        }
    }
}
