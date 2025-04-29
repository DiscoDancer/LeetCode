// мое старое решение

public class Solution {
    private int _n;

    private int Func(int i, bool filledTop, bool filledBottom) {
        if (i == _n) {
            if (filledTop && filledBottom) {
                return 1;
            }
            return 0;
        }

        var result = 0;

        if (filledTop && filledBottom) {
            // ставлю :
            result += Func(i+1, true, true);
            // ничего не ставлю
            result += Func(i+1, false, false);
        }
        else if (!filledTop && !filledBottom) {
            // ставлю ::
            result += Func(i+1, true, true);
            // ставлю :.
            result += Func(i+1, false, true);
            // ставлю :'
            result += Func(i+1, true, false);
        }
        else if (filledTop && !filledBottom) {
            // ставлю .:
            result += Func(i+1, true, true);
            // ставлю ..
            result += Func(i+1, false, true);
        }
        else if (!filledTop && filledBottom) {
            // ставлю ':
            result += Func(i+1, true, true);
            // ставлю ..
            result += Func(i+1, true, false);
        }

        return result;
    } 

    public int NumTilings(int n) {
        _n = n;

        return Func(0, true, true);
    }
}