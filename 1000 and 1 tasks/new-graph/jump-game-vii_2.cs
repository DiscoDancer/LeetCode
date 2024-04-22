// TL
public class Solution {
    public bool CanReach(string s, int minJump, int maxJump) {
        var table = new bool[s.Length];
        table[s.Length - 1] = true;

        for (int index = s.Length - 2; index >= 0; index--) {
            for (int i = minJump; i <= maxJump && index + i < s.Length; i++) {
                if (s[index + i ] != '0') continue;
                table[index] |= table[index + i];
            }
        }

        return table[0];
    }
}