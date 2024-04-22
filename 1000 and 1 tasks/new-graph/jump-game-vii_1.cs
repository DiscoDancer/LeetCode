
// still TL
public class Solution {
    private string _s;
    private int _minJump;
    private int _maxJump;

    private bool?[] _mem;

    private bool F(int index) {
        if (index == _s.Length - 1) {
            return true;
        }
        if (_mem[index] != null) {
            return _mem[index].Value;
        }

        var result = false;

        for (int i = _minJump; i <= _maxJump && index + i < _s.Length; i++) {
            if (_s[index + i ] != '0') continue;
            result |= F(index + i);
        }

        _mem[index] = result;
        return result;
    }

    public bool CanReach(string s, int minJump, int maxJump) {
        _s = s;
        _minJump = minJump;
        _maxJump = maxJump;

        _mem = new bool?[s.Length];

        return F(0);
    }
}