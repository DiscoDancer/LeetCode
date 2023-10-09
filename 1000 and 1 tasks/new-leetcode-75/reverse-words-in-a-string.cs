public class Solution {
    public string ReverseWords(string s) {
    

        var result = new StringBuilder();

        var startIndexIncluding = -1;

        for (int i = s.Length - 1; i >= 0; i--) {
            if (s[i] != ' ') {
                var sb = new StringBuilder();
                while (i >= 0 && s[i] != ' ') {
                    sb.Insert(0, s[i]);
                    i--;
                }
                result.Append(sb.ToString());
                result.Append(' ');
            }
        }

        if (result[result.Length - 1] == ' ') {
            result.Remove(result.Length - 1, 1);
        }

        return result.ToString();
    }
}