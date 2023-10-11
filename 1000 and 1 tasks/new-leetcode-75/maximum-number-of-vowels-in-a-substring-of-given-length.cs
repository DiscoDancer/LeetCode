public class Solution {
    private bool IsVowel(char c) {
        c = char.ToUpper(c);

        return c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U';
    }

    public int MaxVowels(string s, int k) {
        var cur = 0;
        for (int i = 0; i < k; i++) {
            if (IsVowel(s[i])) {
                cur++;
            }
        }

        var max = cur;

        for (int i = k; i < s.Length; i++) {
            var toRemove = s[i-k];
            var toAdd = s[i];

            var iterationSum = 0;
            if (IsVowel(toRemove)) {
                iterationSum--;
            }
            if (IsVowel(toAdd)) {
                iterationSum++;
            }

            cur += iterationSum;
            max = Math.Max(cur, max);
        }

        return max;
    }
}