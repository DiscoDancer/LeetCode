public class Solution {
    public int StrStr(string haystack, string needle) {
        var diff = haystack.Length - needle.Length;
         for (int i = 0; i <= diff; i++) {
             for (int j = 0; j < needle.Length; j++) {
                 if (haystack[i+j] != needle[j]) {
                     break;
                 }
                 if (j == needle.Length - 1) {
                     return i;
                 }
             }
         }

         return -1;
    }
}