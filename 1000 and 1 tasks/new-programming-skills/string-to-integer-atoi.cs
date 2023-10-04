public class Solution {
    // use long for checking
    public int MyAtoi(string s) {
        var i = 0;
        while (i < s.Length && s[i] == ' ') {
            i++;
        }

        var minus = false;
        if (i < s.Length && s[i] == '+') {
            i++;
        }
        else if (i < s.Length && s[i] == '-') {
            minus = true;
            i++;
        }

        var list = new List<int>();
        while (i < s.Length && s[i] >= '0' && s[i] <= '9') {
            if (!list.Any() && s[i] == '0') {
                // ignore leading 0
            }
            else {
                list.Add(s[i]-'0');
            }

            i++;
        }

        if (list.Count() == 0) {
            return 0;
        }

        var maxLength = (int.MaxValue + "").Length;
        if (!minus && list.Count() > maxLength) {
            return int.MaxValue;
        }
        if (minus && list.Count() > maxLength) {
            return int.MinValue;
        }

        long result = 0;
        for (i = list.Count()-1; i >= 0; i--) {
            long n = (long)Math.Pow(10, list.Count()-1 - i);
            result += list[i] * n;
        }

        if (!minus) {
            return result < (long)int.MaxValue ? (int)result : int.MaxValue;
        }

        return -result < (long)int.MinValue ? int.MinValue : (int)-result;
    }
}