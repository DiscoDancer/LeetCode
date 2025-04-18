import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;

// see perfect squares
// see coin change

class Solution {

    private int[] coins;

    // не брать монету меньше в последующих вызовах
    // потому что мы ее потом все равно возьмем
    // 1, 2, 5 F(2) не должен считать F(1) это все равно сделает F(3)
    private int F(int amount, int i0) {
        if (amount == 0) {
            return 1;
        }

        var score = 0;
        for (var i = i0; i < coins.length; i++) {
            var coin = coins[i];
            if (amount >= coin) {
                score += F(amount - coin, i);
            }
            else {
                break;
            }
        }

        return score;
    }


    public int change(int amount, int[] coins) {
        Arrays.sort(coins);
        this.coins = coins;

        return F(amount, 0);
    }
}
