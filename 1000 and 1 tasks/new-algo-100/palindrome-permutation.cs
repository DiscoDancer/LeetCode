public class Solution {
    public bool CanPermutePalindrome(string s) {
       var tableCount = new int[26];
       foreach (var c in s) {
           tableCount[c-'a']++;
       }

       var oddCount = 0;
       for (int i = 0; i < 26; i++) {
           if (tableCount[i] % 2 ==1) {
               oddCount++;
           }
       }

       return oddCount <= 1;
    }
}