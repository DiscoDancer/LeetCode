public class Solution {
    public void ReverseString(char[] s) {
        var l = 0;
        var r = s.Length - 1;

        while (l < r) {
            var tmp = s[l];
            s[l] = s[r];
            s[r] = tmp;
            l++;
            r--;
        }
    }
}