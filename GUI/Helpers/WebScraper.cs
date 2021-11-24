using System.Linq;
using System.Text;
using System.Web;
using HtmlAgilityPack;

namespace GUI.Helpers
{
    public static class WebScraper
    {
        public static string GetHtmlString(string url)
        {
            // Taken from comment on this thread https://stackoverflow.com/questions/4758283/reading-data-from-a-website-using-c-sharp
            System.Net.WebClient wc = new System.Net.WebClient();
            string webData = wc.DownloadString(url);
            return webData;
        }

        public static string RemoveHtmlTagsFromString(string htmlString)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlString);
            var text = doc.DocumentNode.SelectNodes("//body//text()").Select(node => node.InnerText);
            StringBuilder output = new StringBuilder();
            foreach (string line in text)
            {
                output.AppendLine(line);
            }
            string textOnly = HttpUtility.HtmlDecode(output.ToString());
            return textOnly.Replace("\n", "").Trim();
        }

        public static string GetChallengeText(string year, string day)
        {
            var url = $"https://adventofcode.com/{year}/day/{day}";
            var htmlString = GetHtmlString(url);
            var plainText = RemoveHtmlTagsFromString(htmlString);
            // Todo - chop plain text into the two individual challenges and return as string[2]
            return plainText;
        }


    }
}
