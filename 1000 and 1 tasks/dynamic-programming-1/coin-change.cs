public class Solution {

    private int[] Coins;
    private int? Min = null;

    private void CoinChangeInner(int amount, int acc) {
        if (amount == 0) {
            if (Min == null) {
                Min = acc;
            }
            else {
                Min = Math.Min(Min.Value, acc);
            }
        }
        foreach (var coin in Coins) {
            if (amount >= coin) {
                CoinChangeInner(amount - coin, acc + 1);
            }
        }
    }

    // TL
    public int CoinChange(int[] coins, int amount) {
        Coins = coins;
        CoinChangeInner(amount, 0);
        return Min.HasValue ? Min.Value : -1;
    }
}