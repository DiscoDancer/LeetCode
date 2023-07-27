public class Solution {
    public int CoinChange(int[] coins, int amount) {
        var _mem = new int?[amount + 1];

        _mem[0] = 0;
        for (int i = 1; i <= amount; i++)
        {
            var min = int.MaxValue;
            foreach (var c in coins)
            {
                if (c == i)
                {
                    min = 0;
                }
                else if (c < i)
                {
                    if (_mem[i - c] != -1)
                    {
                        min = Math.Min(min, _mem[i - c].Value);
                    }
                }
            }

            _mem[i] = min == int.MaxValue ? -1 : min + 1;
        }

        return _mem[amount].Value;
    }
}