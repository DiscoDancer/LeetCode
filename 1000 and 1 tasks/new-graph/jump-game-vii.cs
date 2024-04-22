// TL
public class Solution {
    private string _s;
    private int _minJump;
    private int _maxJump;

    private bool F(int index) {
        if (index == _s.Length - 1) {
            return true;
        }

        var result = false;

        for (int i = _minJump; i <= _maxJump && index + i < _s.Length; i++) {
            if (_s[index + i ] != '0') continue;
            result |= F(index + i);
        }

        return result;
    }

    public bool CanReach(string s, int minJump, int maxJump) {
        _s = s;
        _minJump = minJump;
        _maxJump = maxJump;

        return F(0);
    }
}