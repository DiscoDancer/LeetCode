public class Solution {

    private bool IsValid(string s) {
        var table = new HashSet<char>();

        foreach (var c in s) {
            if (table.Contains(c)) {
                return false;
            }
            table.Add(c);
        }

        return true;
    }

    

    // сначала перебор
    public int LengthOfLongestSubstring(string s) {
        var max = 0;

        for (int i = 0; i < s.Length - 1; i++) {
            for (int l = 1; (i + l) <= s.Length ; l++) {
                var sub = s.Substring(i, l);
                if (IsValid(sub)) {
                    max = Math.Max(max, l);
                }
            }
        }

        return max;
    }
}