public class Solution {
    // (мое решение было совсем не оч)

    private string _s;
    public const int NotUsePrev = 0;
    public const int UsePrev = 1;

    // может взять букву, может пропустить
    private int F(int i, int state) {
        if (i == _s.Length)
        {
            return 1;
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

            return a + b;
        }
        // state == UsePrev
        else {
            var prev = _s[i-1];
            var c = _s[i];
            if (prev == '1' && c >= '0' && c <= '9') {
                return F(i+1, NotUsePrev);
            }
            else if (prev == '2' && c >= '0' && c <= '6') {
                return F(i+1, NotUsePrev);
            }

            return 0;
        }
    }

    // still TL
    public int NumDecodings(string s) {
        _s = s;
        return F(0, NotUsePrev);
    }
}