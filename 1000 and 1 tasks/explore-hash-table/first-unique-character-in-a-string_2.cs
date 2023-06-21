public class Solution {
    // объединить списочком
    public int FirstUniqChar(string s) {
        // find first positions
        var positions = new Dictionary<char, int?>();
        for (int i = 0; i < s.Length; i++) {
            var c = s[i];
            if (!positions.ContainsKey(c)) {
                positions[c] = i;
            }
            else {
                positions[c] = null;
            }
        }



        var min = int.MaxValue;
        foreach (var k in positions.Keys) {
            if (positions[k] != null) {
                min = Math.Min(min, positions[k].Value);
            }
        }

        return min == int.MaxValue ? -1 : min;
    }
}