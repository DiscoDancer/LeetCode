public class Solution {
    public string ReverseWords(string s) {
        var sb = new StringBuilder();
        var curWordLength = 0;
        for (int i = 0; i < s.Length; i++) {
            if (s[i] != ' ') {
                curWordLength++;
            }
            if ( (s[i] == ' ' || i == s.Length - 1) && curWordLength > 0) {
                var r = s[i] == ' ' ? i - 1 : i;
                var l = (r - curWordLength + 1);

                var j = r;
                while (j >= l) {
                    sb.Insert(0, s[j]);
                    j--;
                }

                if (i != s.Length - 1) {
                    sb.Insert(0, ' ');
                }
                
                curWordLength = 0;
            }
        }

        // подезать пробелы
        while (sb.Length > 0 && sb[0] == ' ') {
            sb.Remove(0, 1);
        }

        return sb.ToString();
    }
}