public class Solution {
    public int StrStr(string haystack, string needle) {
        for (int i = 0; i < haystack.Length; i++) {
            int k = 0;
            while (i + k < haystack.Length && k < needle.Length && haystack[i + k] == needle[k]) {
                k++;
            }
            if (k == needle.Length) {
                return i;
            }
        }
        
        return -1;
    }
}