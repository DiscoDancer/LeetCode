public class Solution {
    // длина + сумма = анаграмма
    // сортировка еще нужна
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var n = strs.Length;
        var lenTable = new Dictionary<int, List<string>>();

        foreach (var s in strs) {
            if (!lenTable.ContainsKey(s.Length)) {
                lenTable[s.Length] = new ();
            }
            lenTable[s.Length].Add(s);
        }

        var result = new List<IList<string>>();

        foreach (var l in lenTable.Keys) {
            var sortTable = new Dictionary<string, List<string>>();
            foreach (var s in lenTable[l]) {
                var chr = s.ToCharArray().OrderBy(x => x);
                var sorted = string.Join("", chr);
                if (!sortTable.ContainsKey(sorted)) {
                    sortTable[sorted] = new ();
                }
                sortTable[sorted].Add(s);
            }

            foreach (var sum in sortTable.Keys) {
                result.Add(sortTable[sum]);
            }
        }

        return result;
    }
}