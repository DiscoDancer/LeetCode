// TL
public class Solution {
    public bool CanReach(string s, int minJump, int maxJump) {
        var table = new bool[s.Length];
        table[0] = true;

        for (int index = 1; index < s.Length; index++) {
            if (s[index] == '1') continue;
            for (int i = minJump; i <= maxJump && index - i >= 0; i++) {
                if (s[index - i ] == '1') continue;
                table[index] |= table[index - i];
            }
        }

        return table[s.Length - 1];
    }
}