public class Solution {

    // todo убрать acc
    // todo добавить mem

    private int[] Coins;
    private const int BigNum = 1000000;
    private Dictionary<int, int> Mem = new ();

    private int CoinChangeInner2(int amount) {
        if (amount == 0) {
            return 0;
        }
        if (Mem.ContainsKey(amount)) {
            return Mem[amount];
        }

        var results = Coins
            .Where(coin => amount >= coin)
            .Select(coin => CoinChangeInner2(amount - coin))
            .ToArray();

        if (!results.Any()) {
            Mem[amount] = BigNum;
            return Mem[amount];
        }

        Mem[amount] = 1 + results.Min();

        return Mem[amount];
    }

    // No TL
    public int CoinChange(int[] coins, int amount) {
        Coins = coins;
        var res = CoinChangeInner2(amount);
        if (res < BigNum) {
            return res;
        }
        return -1;
    }
}