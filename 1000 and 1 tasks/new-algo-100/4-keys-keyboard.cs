public class Solution {
    // TL
    private int _result = 0;
    private int _n;

    // имеет смысл выполнять команды подряд

    private void F(int i, int length, int bufferLength) {
        if (i == _n) {
            _result = Math.Max(length, _result);
            return;
        }

        // i < n = last
        // i < n - 2) = есть еще 3
        if (i < _n - 2) {
            // применяем cntrl-a и cntrl-с
            F(i+2, length, Math.Max(bufferLength, length));
        }

        // мб их можно объединить
        if (bufferLength > 1) {
            // применяем cntrl-v
            F(i+1, length + bufferLength, bufferLength);
        }
        else {
             F(i+1, length + 1, bufferLength);
        }
    }

    public int MaxA(int n) {
        _n = n;
        F(0, 0, 0);
        return _result;
    }
}