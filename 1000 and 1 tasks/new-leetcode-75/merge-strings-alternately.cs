public class Solution {
    public string MergeAlternately(string word1, string word2) {
        var p1 = word1.Length;
        var p2 = word2.Length;

        var i = 0;
        var sb = new StringBuilder();

        while (i < Math.Min(word1.Length, word2.Length)) {
            sb.Append(word1[i]);
            sb.Append(word2[i]);
            i++;
        }

        while (i < word1.Length) {
            sb.Append(word1[i]);
            i++;
        }
        while (i < word2.Length) {
            sb.Append(word2[i]);
            i++;
        }

        return sb.ToString();
    }
}