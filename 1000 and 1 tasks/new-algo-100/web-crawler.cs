/**
 * // This is the HtmlParser's API interface.
 * // You should not implement it, or speculate about its implementation
 * class HtmlParser {
 *     public List<String> GetUrls(String url) {}
 * }
 */

class Solution {
    private string GetHost(string startUrl) {
        var sb = new StringBuilder();
        var i = 7;
        while ( i < startUrl.Length && startUrl[i] != '/' ) {
            sb.Append(startUrl[i]);
            i++;
        }
        var host = sb.ToString();

        return host;
    }

    public IList<string> Crawl(string startUrl, HtmlParser htmlParser) {
        var host = GetHost(startUrl);
        var prefix = "http://" + host;
        var result = new HashSet<string>();
        var queue = new Queue<string>();
        queue.Enqueue(startUrl);
        result.Add(startUrl);

        while (queue.Any()) {
            var cur = queue.Dequeue();
            foreach (var option in htmlParser.GetUrls(cur)) {
                if (option.StartsWith(prefix)) {
                    if (result.Add(option)) {
                        queue.Enqueue(option);
                    }
                }
            }
        }


        return result.ToList();
    }
}