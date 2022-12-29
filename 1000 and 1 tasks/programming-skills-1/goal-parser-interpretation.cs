public class Solution {
    public string Interpret(string command) {
        var sb = new StringBuilder();

        char prev = '0';
        foreach (var c in command) {
            if (c == 'G') {
                sb.Append('G');
            }
            else if (c == '(') {
                // nothing
            }
            else if (c == ')') {
                if (prev == '(') {
                    sb.Append('o');
                }
                else {
                    sb.Append("al");
                }
            }
            prev = c;
        }

        return sb.ToString();
    }
}