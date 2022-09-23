public class Solution {
    public string MergeAlternately(string word1, string word2) {
        var min = Math.Min(word1.Length, word2.Length);
        
        var sb = new StringBuilder();
        
        for (int i = 0; i < min; i++) {
            sb.Append(word1[i]);
            sb.Append(word2[i]);
        }
        
        var maxString = word1.Length > word2.Length ? word1 : word2;
        
        for (int i = min; i < maxString.Length; i++) {
            sb.Append(maxString[i]);
        }
        
        return sb.ToString();
    }
}