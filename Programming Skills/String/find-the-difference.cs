public class Solution {
    public char FindTheDifference(string s, string t) {
        var table = new int[26];
        
        foreach (var c in t) {
            table[c - 'a']++;
        }
        
        foreach (var c in s) {
            table[c - 'a']--;
        }
        
        for (var i = 0; i < table.Length; i++) {
            if (table[i] != 0) {
                return (char)(i + ((int)'a'));
            }
        }
        
        return 'a';
    }
}