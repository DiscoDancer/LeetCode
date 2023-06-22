public class Solution {
    
    private string Encode (string s) {
        var table = new char[26];
        foreach (var c in s) {
            table[c-'a']++;
        }
        var sb = new StringBuilder();
        for (int i = 0; i < 26; i++) {
            if (table[i] > 0) {
                sb.Append($"{i}-{table[i]};");
            }
        }

        return sb.ToString();
    }

    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var table = new Dictionary<string, IList<string>>();
        foreach (var s in strs) {
            var encoded = Encode(s);
            if (!table.ContainsKey(encoded)) {
                table[encoded] = new List<string>();
            }
            table[encoded].Add(s);
        }

        return table.Values.ToList();
    }
}