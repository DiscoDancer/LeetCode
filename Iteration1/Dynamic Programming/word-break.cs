public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        var res = new bool[s.Length + 1];
        res[0] = true;
        
        for (int i = 1; i <= s.Length; i++) {
            for (int j = 0; j < i; j++) {
                if (res[j] && wordDict.Contains(s.Substring(j, i - j))) {
                    res[i] = true;
                    break;
                }
            }
        }
        
        return res[s.Length];
    }
}