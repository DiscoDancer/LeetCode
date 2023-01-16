public class Solution {
    public int CoinChange(int[] coins, int amount) {
        var table = new int[amount + 1];
        Array.Fill(table, -1);
        table[0] = 0;

        foreach (var coin in coins) {
            if (coin <= amount)
            {
                table[coin] = 1;
            }
        }

        var min = Math.Min(coins.Min(), amount);

        for (int i = min + 1; i <= amount; i++) {
            if (table[i] != -1) {
                continue;
            }
            var minChild = int.MaxValue;
            foreach (var coin in coins) {
                var diff = i - coin;
                if (diff >= 0 && table[diff] != -1) {
                    minChild = Math.Min(minChild, table[diff]);
                }
            }
            if (minChild < int.MaxValue) {
                table[i] = minChild + 1;
            }
        }

        return table[amount];
    }
}