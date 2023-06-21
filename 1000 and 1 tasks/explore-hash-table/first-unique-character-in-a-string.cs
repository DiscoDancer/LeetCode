public class Solution {
    // объединить списочком
    public int FirstUniqChar(string s) {
        // find first positions
        var position = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++) {
            var c = s[i];
            if (!position.ContainsKey(c)) {
                position[c] = i;
            }
        }

        var count = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++) {
            var c = s[i];
            if (!count.ContainsKey(c)) {
                count[c] = 1;
            }
            else {
                count[c]++;
            }
        }

        var min = int.MaxValue;

        foreach (var k in count.Keys) {
            if (count[k] == 1) {
                min = Math.Min(min, position[k]);
            }
        }

        return min == int.MaxValue ? -1 : min;
    }
}