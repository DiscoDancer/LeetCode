public class Solution {
    private int _n;
    private int _result = 0;

    private void Func(int i, bool filledTop, bool filledBottom) {
        if (i == _n) {
            if (filledTop && filledBottom) {
                _result++;
            }
            return;
        }

        if (filledTop && filledBottom) {
            // ставлю :
            Func(i+1, true, true);
            // ничего не ставлю
            Func(i+1, false, false);
        }
        else if (!filledTop && !filledBottom) {
            // ставлю ::
            Func(i+1, true, true);
            // ставлю :.
            Func(i+1, false, true);
            // ставлю :'
            Func(i+1, true, false);
        }
        else if (filledTop && !filledBottom) {
            // ставлю .:
            Func(i+1, true, true);
            // ставлю ..
            Func(i+1, false, true);
        }
        else if (!filledTop && filledBottom) {
            // ставлю ':
            Func(i+1, true, true);
            // ставлю ..
            Func(i+1, true, false);
        }
    } 

    // TL
    public int NumTilings(int n) {
        _n = n;

        Func(0, true, true);

        return _result;
    }
}