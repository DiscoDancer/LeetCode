using System.Linq;
using System.Collections.Generic;

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (s.Length < 2) {
            return s.Length;
        }
        
        
        var a = s.ToCharArray();
        var dic = new Dictionary<char, int>();
        
        int max = 0;
        int currentLength = 0;
        
        for (int i = 0; i < a.Length; i++) {
            var lastIndex = dic.ContainsKey(a[i]) ? dic[a[i]] : -1;
            
            if (lastIndex == -1) {
                currentLength++;
                

            }
            else {
                currentLength = System.Math.Min(i - lastIndex, currentLength + 1);
            }
            dic[a[i]] = i;
            if (currentLength > max) {
                max = currentLength;
            }
        }
        
        return max;
    }
}