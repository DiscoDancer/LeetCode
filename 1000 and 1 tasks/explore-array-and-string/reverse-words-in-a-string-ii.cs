public class Solution {
    // перевернуть слова; перевернуть строку

    // "the sky is blue"
    // "eht yks si eulb"
    // "blue is sky the"

    public void ReverseWords(char[] s) {
        var curWordLength = 0;
        for (int i = 0; i < s.Length; i++) {
            if (s[i] != ' ') {
                curWordLength++;
            }
            if ( (s[i] == ' ' || i == s.Length - 1) && curWordLength > 0) {
                var r = s[i] == ' ' ? i - 1 : i;
                var l = (r - curWordLength + 1);

                while (l < r) {
                    var tmp = s[l];
                    s[l] = s[r];
                    s[r] = tmp;
                    l++;
                    r--;
                }

                curWordLength = 0;
            }
        }

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