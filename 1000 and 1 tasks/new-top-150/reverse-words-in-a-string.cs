public class Solution {
    // todo reduce spaces
    public string ReverseWords(string s) {
        var sb = new StringBuilder();
        for (int i = s.Length - 1; i >= 0; i--) {
            if (s[i] != ' ') {
                var r = i;
                var l = r;
                while (l - 1 >= 0 && s[l - 1] != ' ') {
                    l--;
                }
                i = l;

                var j = l;
                while (j <= r) {
                    sb.Append(s[j]);
                    j++;
                }

                sb.Append(' ');
            }
        }

        if (sb[sb.Length - 1] == ' ') {
            sb.Remove(sb.Length - 1, 1);
        }

        return sb.ToString();
    }
}