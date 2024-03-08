public class Solution {
    private int _n;

    // оптимизация: предполагаем, что изначально можем сделать cntrl-v 'A'
    private int F(int i, int length, int maxBufferLength) {
        if (i == _n) {
            return length;
        }

        var cntrlVorInsertA = F(i+1, length + maxBufferLength, maxBufferLength);

        if (i < _n - 2) {
            var cntrlCA = F(i+2, length, Math.Max(maxBufferLength, length));

            return Math.Max(cntrlCA, cntrlVorInsertA);
        }

        return cntrlVorInsertA;
    }

    public int MaxA(int n) {
        _n = n;
        return F(0, 0, 1);
    }
}