using System.Collections.Generic;

public class Solution {
    public int FirstUniqChar(string s) {
        
        if (s == null || s.Length == 0) {
            return -1;
        }
        
        var dic = new Dictionary<char, int>();
        
        for (int i = 0; i < s.Length; i++) {
            if (!dic.ContainsKey(s[i])) {
                dic[s[i]] = i;
            }
            else {
                dic[s[i]] = int.MaxValue;
            }
        }
        
        var min = dic.Values.Min();
        
        return min < int.MaxValue ? min : -1;
    }
}