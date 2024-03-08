public class Solution {

    // уже проходит

    
    private int _n;

    private Dictionary<(int, int, int), int> _mem = new ();

    // оптимизация: предполагаем, что изначально можем сделать cntrl-v 'A'
    private int F(int i, int length, int maxBufferLength) {
        if (i == _n) {
            return length;
        }

        if (_mem.ContainsKey((i,length,  maxBufferLength))) {
            return _mem[(i,length,  maxBufferLength)];
        }


        var cntrlVorInsertA = F(i+1, length + maxBufferLength, maxBufferLength);
        var result = cntrlVorInsertA;

        if (i < _n - 2 && length > maxBufferLength) {
            var cntrlCA = F(i+2, length, length);
            result = Math.Max(cntrlCA, result);
        }

        _mem[(i,length,  maxBufferLength)] = result;

        return result;
    }

    public int MaxA(int n) {
        _n = n;
        return F(0, 0, 1);
    }
}