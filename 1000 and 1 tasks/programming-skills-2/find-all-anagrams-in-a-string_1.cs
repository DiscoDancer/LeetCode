public class Solution {
    // очевидно не хочется заново считать
    private bool AreAnagrams(string s, string p, int start) {
        var table = new int[26];
        for (int i = 0; i < p.Length; i++) {
            table[p[i]-'a']++;
            table[s[i+start]-'a']--;
        }

        return table.All(x => x == 0);
    }

    public IList<int> FindAnagrams(string s, string p) {
        var result = new List<int>();

        if (p.Length > s.Length) {
            return result;
        }

        var timesCount = s.Length - p.Length + 1;
        for (int i = 0; i < timesCount; i++) {
            if (AreAnagrams(s, p, i)) {
                result.Add(i);
            }
        }

        return result;
    }
}