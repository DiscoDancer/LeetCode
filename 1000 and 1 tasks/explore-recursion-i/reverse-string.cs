public class Solution {
    public void ReverseString(char[] s) {
       var L = 0;
       var R = s.Length - 1;
       while (L < R) {
           var tmp = s[L];
           s[L] = s[R];
           s[R] = tmp;

           L++;
           R--;
       } 
    }
}