public class Solution {
    public string MergeAlternately(string word1, string word2) {
        var p1 = 0;
        var p2 = 0;

        var sb = new StringBuilder();

        while (p1 < word1.Length && p2 < word2.Length) {
            sb.Append(word1[p1]);
            sb.Append(word2[p2]);
            p1++;
            p2++;
        }

        while (p1 < word1.Length) {
            sb.Append(word1[p1]);
            p1++;
        }

        while (p2 < word2.Length) {
            sb.Append(word2[p2]);
            p2++;
        }

        return sb.ToString();
    }
}