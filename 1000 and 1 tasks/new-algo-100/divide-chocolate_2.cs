public class Solution {
    // k friends, k cuts, k + 1 pieces
    // видимо я и k друзей, поэтому k+1

    // допустим у меня есть все возможные k + 1 разбиения
    // как найти ответ? берем min sum кучки и максимизируем этот min
    // звучит как dp

    private int _result = int.MinValue;
    private int[] _sweetness;

    private void F(int sweetIndex, int[] shares) {
        if (sweetIndex == _sweetness.Length) {
            var min = shares.Min();
            if (min != 0) {
                _result = Math.Max(_result, min);
            }

            return;
        }

        for (int i = 0; i < shares.Length; i++) {
            var gain = _sweetness[sweetIndex];
            shares[i] += gain;
            F(sweetIndex + 1, shares);
            shares[i] -= gain;
        }
    }

    public int MaximizeSweetness(int[] sweetness, int k) {
        _sweetness = sweetness;
        F(0, new int[k+1]);

        return _result;
    }
}