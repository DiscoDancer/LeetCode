public class Solution {
    public char FindTheDifference(string s, string t) {
        char res = (char)0;
        
        foreach (var c in t) {
            res ^= c;
        }
        foreach (var c in s) {
            res ^= c;
        }
        
        return res;
    }
}