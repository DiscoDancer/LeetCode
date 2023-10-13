public class Solution {
    // просто идти с конца?
    public string RemoveStars(string s) {
        var sb = new StringBuilder();
        var starsBalance = 0;

        // TODO досрочно можно прервать, если звезд слишком много
        for (int i = s.Length - 1; i - starsBalance >= 0; i--) {
            if (s[i] == '*') {
                starsBalance++;
            }
            else if (starsBalance > 0) {
                starsBalance--;
            }
            else {
                sb.Insert(0, s[i]);
            }
        }

        return sb.ToString();
    }
}