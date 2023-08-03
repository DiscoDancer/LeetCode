public class Solution {
    public const int NotUsePrev = 0;
    public const int UsePrev = 1;

    public int NumDecodings(string s) {
        var table = new int[s.Length + 1, 2];
        table[s.Length, 0] = 1;
        table[s.Length, 1] = 1;

        for (int i = s.Length - 1; i >= 0; i--) {
            for (var state = 0; state <= 1; state++) {
                if (state == NotUsePrev) {
                    var c = s[i];
                    var a = 0;
                    var b = 0;
                    if (c >= '1' && c <= '9') {
                        a = table[i+1, NotUsePrev];
                    }
                    if (c >= '1' && c <= '2' && i < s.Length - 1) {
                        b = table[i+1, UsePrev];
                    }
                    table[i, state] = a + b;
                }
                else {
                    var prev = i > 0 ? s[i-1] : -1;
                    var c = s[i];

                    if (prev == '1' && c >= '0' && c <= '9') {
                        table[i, state]  = table[i+1, NotUsePrev];
                    }
                    else if (prev == '2' && c >= '0' && c <= '6') {
                        table[i, state] = table[i+1, NotUsePrev];
                    }
                    else {
                        table[i, state] = 0;
                    }
                }
            }
        }

        return table[0,0];
    }
}