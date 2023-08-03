public class Solution {
    private string _s;
    public const int NotUsePrev = 0;
    public const int UsePrev = 1;
    private int?[,] _mem;

    // может взять букву, может пропустить
    private int F(int i, int state) {
        if (i == _s.Length)
        {
            return 1;
        }

        if (_mem[i, state] != null) {
            return _mem[i, state].Value;
        }

        if (state == NotUsePrev) {
            var c = _s[i];
            var a = 0;
            var b = 0;
            if (c >= '1' && c <= '9') {
                a = F(i+1, NotUsePrev);
            }
            if (c >= '1' && c <= '2' && i < _s.Length - 1) {
                b = F(i+1, UsePrev);
            }

            _mem[i, state] = a + b;
            return a + b;
        }
        // state == UsePrev
        else {
            var prev = _s[i-1];
            var c = _s[i];
            if (prev == '1' && c >= '0' && c <= '9') {
                _mem[i, state]  = F(i+1, NotUsePrev);
                return _mem[i, state].Value;
            }
            else if (prev == '2' && c >= '0' && c <= '6') {
                _mem[i, state]  =  F(i+1, NotUsePrev);
                return _mem[i, state].Value ;
            }

            _mem[i, state]  = 0;
            return _mem[i, state].Value;
        }
    }


    // passes 
    public int NumDecodings(string s) {
        _s = s;
        _mem = new int?[s.Length + 1, 2];

        F(0, 0);

        return _mem[0, 0].Value;
    }
}