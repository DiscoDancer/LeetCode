using System.Collections.Generic;

public class Solution {
    public bool IsAnagram(string s, string t) {
        var dic = new Dictionary<char, int>();
        
        foreach (var c in s) {
            if (!dic.ContainsKey(c)) {
                dic[c] = 0;
            }
            dic[c]++;
        }
        
        foreach (var c in t) {
            if (!dic.ContainsKey(c)) {
                dic[c] = 0;
            }
            dic[c]--;
        }
        
        for (int i = (int)'a' ; i <= (int) 'z'; i++) {
            if (dic.ContainsKey((char)i) && dic[(char)i] != 0) {
                return false;
            }
        }
        
        return true;
    }
}