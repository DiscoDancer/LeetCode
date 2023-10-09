public class Solution {
    public int Compress(char[] chars) {
        char? prev = null;
        var count = 0;
        var sb = new StringBuilder();

        foreach (var c in chars) {
            if (c == prev) {
                count++;
            }
            else {
                if (prev == null) {
                    count = 1;
                }
                else {
                    sb.Append(prev);
                    if (count > 1) {
                        sb.Append(count + "");
                    }
                    count = 1;
                }
            }
            prev = c;
        }

        if (count > 0) {
            sb.Append(prev);
            if (count > 1) {
                sb.Append(count + "");
            }
        }

        var s = sb.ToString();
        for (int i = 0; i < s.Length; i++) {
            chars[i] = s[i];
        }

        // chars = sb.ToString().ToCharArray();

        return s.Length;
    }
}