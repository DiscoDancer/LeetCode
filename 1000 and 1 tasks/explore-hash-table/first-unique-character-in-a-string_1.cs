public class Solution {
    // объединить списочком
    public int FirstUniqChar(string s) {
        // find first positions
        var positions = new Dictionary<char, List<int>>();
        for (int i = 0; i < s.Length; i++) {
            var c = s[i];
            if (!positions.ContainsKey(c)) {
                positions[c] = new ();
            }
            if (positions[c].Count() < 2) {
                positions[c].Add(i);
            }
        }



        var min = int.MaxValue;
        foreach (var k in positions.Keys) {
            if (positions[k].Count() == 1) {
                min = Math.Min(min, positions[k].First());
            }
        }

        return min == int.MaxValue ? -1 : min;
    }
}