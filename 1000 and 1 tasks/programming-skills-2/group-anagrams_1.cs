public class Solution {
    // длина + сумма = анаграмма
    // сортировка еще нужна
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var sortTable = new Dictionary<string, List<string>>();
        foreach (var s in strs) {
            var chr = s.ToCharArray().OrderBy(x => x);
            var sorted = string.Join("", chr);
            if (!sortTable.ContainsKey(sorted)) {
                sortTable[sorted] = new ();
            }
            sortTable[sorted].Add(s);
        }

        var result = new List<IList<string>>();
        foreach (var k in sortTable.Keys) {
            result.Add(sortTable[k]);
        }

        return result;
    }
}