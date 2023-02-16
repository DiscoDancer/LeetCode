public class Solution {
    // длина + сумма = анаграмма
    // сортировка еще нужна
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var sortTable = new Dictionary<string, List<string>>();
        foreach (var s in strs) {
            var table = new int[26];
            foreach (var c in s) {
                table[c-'a']++;
            }
            var sb = new StringBuilder();
            for (int i = 0; i < 26; i++) {
                sb.Append('$');
                sb.Append(table[i]);
            }
            var key = sb.ToString();
            if (!sortTable.ContainsKey(key)) {
                sortTable[key] = new ();
            }
            sortTable[key].Add(s);
        }

        var result = new List<IList<string>>();
        foreach (var k in sortTable.Keys) {
            result.Add(sortTable[k]);
        }

        return result;
    }
}