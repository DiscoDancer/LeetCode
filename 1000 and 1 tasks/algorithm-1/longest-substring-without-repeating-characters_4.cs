public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (s.Length == 0) {
            return 0;
        }

        var max = 0;
        int left = 0;
        int right = -1;
        var dic = new Dictionary<char, int>();

        while (right < s.Length - 1) {
            // пробуем увеличить окно
            while (right + 1 < s.Length && !dic.ContainsKey(s[right + 1])) {
                right++;
                dic[s[right]] = right;
                max = Math.Max(max, dic.Keys.Count);
            }

            // пробуем сместиться
            var isNextWindowValid = false;
            while (right + 1 < s.Length && !isNextWindowValid) {
                // удалить левое
                if (dic[s[left]] == left) {
                    dic.Remove(s[left]);
                }
                left++;

                // добавить или перетереть правое
                dic[s[right + 1]] = right + 1;
                right++;

                max = Math.Max(max, dic.Keys.Count);
                isNextWindowValid = dic.Keys.Count == max;
            }
        }

        return max;
    }
}