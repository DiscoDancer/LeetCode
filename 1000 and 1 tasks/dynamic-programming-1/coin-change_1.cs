public class Solution {

    // todo убрать acc
    // todo добавить mem

    private int[] Coins;
    private const int BigNum = 1000000;

    private int CoinChangeInner2(int amount) {
        if (amount == 0) {
            return 0;
        }

        var results = Coins
            .Where(coin => amount >= coin)
            .Select(coin => CoinChangeInner2(amount - coin))
            .ToArray();

        if (!results.Any()) {
            return BigNum;
        }

        return 1 + results.Min();
    }

    public int CoinChange(int[] coins, int amount) {
        Coins = coins;
        var res = CoinChangeInner2(amount);
        if (res < BigNum) {
            return res;
        }
        return -1;
    }
}