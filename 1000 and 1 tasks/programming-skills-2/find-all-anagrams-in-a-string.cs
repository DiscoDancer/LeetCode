public class Solution {
    // очевидно не хочется заново считать
    public bool AreAnagrams(string a, string b) {
        if (a.Length != b.Length) {
            return false;
        }

        var table = new int[26];
        foreach (var c in a) table[c-'a']++;
        foreach (var c in b) table[c-'a']--;

        return table.All(x => x == 0);
    }

    public IList<int> FindAnagrams(string s, string p) {
        var result = new List<int>();

        if (p.Length > s.Length) {
            return result;
        }

        var timesCount = s.Length - p.Length + 1;
        for (int i = 0; i < timesCount; i++) {
            var sub = s.Substring(i, p.Length);
            if (AreAnagrams(sub, p)) {
                result.Add(i);
            }
        }

        return result;
    }
}