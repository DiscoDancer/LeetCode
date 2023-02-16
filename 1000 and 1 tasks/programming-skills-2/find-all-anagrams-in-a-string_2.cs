public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
        var result = new List<int>();

        if (p.Length > s.Length) {
            return result;
        }

        var table = new int[26];
        foreach (var c in p) {
            table[c-'a']++;
        }

        var timesCount = s.Length - p.Length + 1;
        for (int i = 0; i < timesCount; i++) {
            if (i == 0) {
                for (int j = 0; j < p.Length; j++)
                {
                    table[s[j]-'a']--;
                }
            }
            else {
                // удалить предыдущую
                table[s[i-1]-'a']++;

                // добавить следующую
                table[s[i + p.Length - 1]-'a']--;
            }
            if (table.All(x => x == 0)) {
                result.Add(i);
            }
        }

        return result;
    }
}