public class Solution {

    private bool IsUpper(char c) {
        return c >= 'A' && c <= 'Z';
    }

    private char UpperToLower(char c) {
        if (!IsUpper(c)) {
            return c;
        }

        return (char)( (c - 'A') + (int)'a');
    }

    public string ToLowerCase(string s) {
        return new string (s.ToCharArray().Select(UpperToLower).ToArray());
    }
}