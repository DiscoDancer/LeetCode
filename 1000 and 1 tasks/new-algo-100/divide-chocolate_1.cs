public class Solution {
    // k friends, k cuts, k + 1 pieces
    // видимо я и k друзей, поэтому k+1

    // допустим у меня есть все возможные k + 1 разбиения
    // как найти ответ? берем min sum кучки и максимизируем этот min
    // звучит как dp

    private int _result = int.MinValue;
    private int[] _sweetness;

    private void F(int sweetIndex, List<int>[] shares) {
        if (sweetIndex == _sweetness.Length) {
            var min = int.MaxValue;
            foreach (var s in shares) {
                if (!s.Any()) {
                    return;
                }
                min = Math.Min(min, s.Sum());
            }
            _result = Math.Max(_result, min);
            return;
        }


        foreach (var share in shares) {
            var gain = _sweetness[sweetIndex];
            // место для оптимизации, чтобы удалить по индексу
            share.Add(gain);
            F(sweetIndex + 1, shares);
            share.Remove(gain);
        }

        return;
    }

    public int MaximizeSweetness(int[] sweetness, int k) {
        _sweetness = sweetness;
        var share = new List<int>[k+1];
        for (int i = 0; i < k+1; i++) {
            share[i] = new ();
        }

        F(0, share);

        return _result;
    }
}