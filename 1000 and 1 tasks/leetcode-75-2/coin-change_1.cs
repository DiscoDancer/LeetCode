public class Solution {
    private int[] _coins;
    private Dictionary<int, int> _table = new ();

    private int F(int amount) {
        if (amount == 0) {
            return 0;
        }
        if (amount < 0) {
            return -1;
        }
        if (_table.ContainsKey(amount)) {
            return _table[amount];
        }

        var optionList = new List<int>();

        foreach (var coin in _coins) {
            var subResult = F(amount - coin);
            if (subResult != -1) {
                optionList.Add(subResult);
            }
        }

        var result = optionList.Any() ? optionList.Min() + 1 : -1;
        _table[amount] = result;
        return _table[amount];
    }

    public int CoinChange(int[] coins, int amount) {
        if (amount == 0) {
            return 0;
        }
        
        _coins = coins;

        foreach (var coin in coins) {
            _table[coin] = 1;
        }

        F(amount);

        return _table[amount];
    }
}