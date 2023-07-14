public class Solution {
    public int KthGrammar(int n, int k) {
        var str = "0";

        for (int i = 1; i < n; i++) {
            var sb = new StringBuilder();
            foreach (var c in str) {
                if (c == '0') {
                    sb.Append("01");
                }
                else {
                    sb.Append("10");
                }
            }
            str = sb.ToString();
        }

        return str[k-1]-'0';
    }
}