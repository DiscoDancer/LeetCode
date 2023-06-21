public class Solution {
    // объединить списочком
    public int FirstUniqChar(string s) {
        // find first positions
        var positions = new int[26];

        for (int i = 0; i < s.Length; i++) {
            var c = s[i] - 'a';
            if (positions[c] == 0) {
                positions[c] = i + 1;
            }
            else {
                positions[c] = -1;
            }
        }



        var min = int.MaxValue;
        for (int i = 0; i < 26; i++) {
            if (positions[i] > 0) {
                min = Math.Min(min, positions[i] - 1);
            }
        }

        // +1 и -1 для того, чтобы 0 был только для не существующей буквы, а индекс 0 стал 1

        return min == int.MaxValue ? -1 : min;
    }
}