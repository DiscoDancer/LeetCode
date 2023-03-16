public class Solution {
    // https://leetcode.com/problems/minimum-window-substring/editorial/
    public string MinWindow(string s, string t) {
       var dictT = new Dictionary<char, int>();
       foreach (var c in t) {
           if (!dictT.ContainsKey(c)) {
               dictT[c] = 0;
           }
           dictT[c]++;
       }

       var required = dictT.Keys.Count;
       var l = 0;
       var r = 0;
       var formed = 0;

       var windowCounts = new Dictionary<char, int>();
       var ans = new int[]{ -1, 0, 0 };

       while (r < s.Length) {
           var c = s[r];

           if (!windowCounts.ContainsKey(c)) {
               windowCounts[c] = 0;
           }
           windowCounts[c]++;


           if (dictT.ContainsKey(c) && windowCounts[c] == dictT[c]) {
               formed++;
           }

           while (l <= r && formed == required) {
               c = s[l];
                if (ans[0] == -1 || r - l + 1 < ans[0]) {
                    ans[0] = r - l + 1;
                    ans[1] = l;
                    ans[2] = r;
                }

                windowCounts[c]--;
                if (dictT.ContainsKey(c) && windowCounts[c] < dictT[c]) {
                    formed--;
                }
                l++;
           }

           r++;
       }

       return ans[0] == -1 ? "" : s.Substring(ans[1], ans[2] - ans[1]  + 1);
    }
}