public class Solution {
    // (мое решение было совсем не оч)

    private int _result = 0;
    private string _s;

    public const int NotUsePrev = 0;
    public const int UsePrev = 1;


    // может взять букву, может пропустить
    private void F(int i, int state) {
        if (i == _s.Length)
        {
            _result++;
            return;
        }

        if (state == NotUsePrev) {
            var c = _s[i];
            if (c >= '1' && c <= '9') {
                F(i+1, NotUsePrev);
            }
            if (c >= '1' && c <= '2' && i < _s.Length - 1) {
                F(i+1, UsePrev);
            }
        }
        else if (state == UsePrev) {
            var prev = _s[i-1];
            var c = _s[i];
            if (prev == '1' && c >= '0' && c <= '9') {
                F(i+1, NotUsePrev);
            }
            else if (prev == '2' && c >= '0' && c <= '6') {
                F(i+1, NotUsePrev);
            }
        }
    }

    // TL
    public int NumDecodings(string s) {
        if (s.Length == 1) {
            if (s[0] == '0') {
                return 0;
            }
            return 1;
        }

        _s = s;
        F(0, NotUsePrev);

        return _result;
    }
}