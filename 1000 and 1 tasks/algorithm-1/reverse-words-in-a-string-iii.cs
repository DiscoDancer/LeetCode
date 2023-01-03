public class Solution {

    private void Reverse(char[] s, int l, int r) {
        // var l = 0;
        // var r = s.Length - 1;

        while (l < r) {
            var tmp = s[l];
            s[l] = s[r];
            s[r] = tmp;
            l++;
            r--;
        }
    }

    public string ReverseWords(string s) {
        var ss = s.ToCharArray();

        var beginIndex = -1;
        var length = 0;
        for (int i = 0; i < ss.Length; i++) {
            if (beginIndex < 0 && ss[i] == ' ') {
                continue;
            }
            if (ss[i] != ' ') {
                if (beginIndex < 0) {
                    beginIndex = i;
                    length = 1;
                }
                else {
                    length++;
                }
            }

            if (s[i] == ' ' || i == ss.Length - 1) { // space
                Reverse(ss, beginIndex, beginIndex + length - 1);
                beginIndex = -1;
                length = 0;
            }
        }

        return new string(ss);
    }
}