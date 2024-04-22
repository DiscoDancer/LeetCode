// TL
public class Solution {
    public bool CanReach(string s, int minJump, int maxJump) {
        var table = new bool[s.Length];
        table[s.Length - 1] = true;

        for (int index = s.Length - 2; index >= 0; index--) {
            var result = false;
            for (int i = _minJump; i <= _maxJump && index + i < _s.Length; i++) {
                if (_s[index + i ] != '0') continue;
                result |= table[index + i];
            }
            table[index] = result;
        }

        return table[0];
    }
}