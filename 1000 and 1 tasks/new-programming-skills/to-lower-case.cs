public class Solution {
    public string ToLowerCase(string s) {
        var sb = new StringBuilder();

        foreach (var c in s) {
            if (c >= 'A' && c <= 'Z') {
                var diff = c - 'A';
                sb.Append((char) ((int)'a' + diff)  );
            }
            else {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }
}