public class Solution {
    private int _result = 0;
    private int _n;

    // имеет смысл выполнять команды подряд

    // оптимизация: предполагаем, что изначально можем сделать cntrl-v 'A'

    private void F(int i, int length, int maxBufferLength) {
        if (i == _n) {
            _result = Math.Max(length, _result);
            return;
        }

        // i < n = last
        // i < n - 2) = есть еще 3
        if (i < _n - 2) {
            // применяем cntrl-a и cntrl-с
            F(i+2, length, Math.Max(maxBufferLength, length));
        }

        // применяем cntrl-v
        F(i+1, length + maxBufferLength, maxBufferLength);
    }

    public int MaxA(int n) {
        _n = n;
        F(0, 0, 1);
        return _result;
    }
}