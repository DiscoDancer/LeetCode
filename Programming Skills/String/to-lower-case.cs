public class Solution {
    public string ToLowerCase(string s) {
        var diff = 'a' - 'A'; // > 0
        
        var sb = new StringBuilder();
        
        foreach (var c in s) {
            if ('A' <= c && c <= 'Z') {
                sb.Append((char) (c + diff));
            }
            else {
                sb.Append(c);
            }
        }
        
        return sb.ToString();
    }
}