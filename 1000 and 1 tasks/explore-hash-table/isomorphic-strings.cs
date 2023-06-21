public class Solution {
    // закодировать; сравнить

    public string Encode(string s) {
        var dictionary = new Dictionary<char, int>();
        var i = 1;
        var sb = new StringBuilder();

        foreach (var c in s) {
            if (!dictionary.ContainsKey(c)) {
                dictionary[c] = i++;
            }
            sb.Append(dictionary[c]);
        }

        return sb.ToString();
    }

    public bool IsIsomorphic(string s, string t) {
        return Encode(s) == Encode(t);
    }
}