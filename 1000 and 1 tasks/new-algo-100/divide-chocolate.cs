// TL даже на базовых примерах

public class Solution {
    // k friends, k cuts, k + 1 pieces
    // видимо я и k друзей, поэтому k+1

    // допустим у меня есть все возможные k + 1 разбиения
    // как найти ответ? берем min sum кучки и максимизируем этот min
    // звучит как dp

    private int _result = int.MinValue;
    private int[] _sweetness;

    private void F(bool[] sweetnessMap, List<int>[] shares) {
        if (sweetnessMap.All(x => x)) {
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

        for (int i = 0; i < sweetnessMap.Count(); i++) {
            if (sweetnessMap[i]) {
                continue;
            }

            // use
            sweetnessMap[i] = true;
            var gain = _sweetness[i];

            foreach (var share in shares) {
                // место для оптимизации, чтобы удалить по индексу
                share.Add(gain);
                F(sweetnessMap, shares);
                share.Remove(gain);
            }

            // unuse
            sweetnessMap[i] = false;
        }

        return;
    }

    public int MaximizeSweetness(int[] sweetness, int k) {
        _sweetness = sweetness;
        var share = new List<int>[k+1];
        for (int i = 0; i < k+1; i++) {
            share[i] = new ();
        }

        F(new bool[sweetness.Length], share);

        return _result;
    }
}