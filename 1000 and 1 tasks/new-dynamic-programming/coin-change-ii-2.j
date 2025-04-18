import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;

// see perfect squares
// see coin change

class Solution {
    public int change(int amount, int[] coins) {
        Arrays.sort(coins);

        var table = new int[amount+1][coins.length];

        for (var ai = 0; ai <= amount; ai++) {
            for (var i0 = coins.length - 1; i0 >= 0; i0--) {
                if (ai == 0) {
                    table[ai][i0] = 1;
                    continue;
                }

                var score = 0;
                for (var i = i0; i < coins.length; i++) {
                    var coin = coins[i];
                    if (ai >= coin) {
                        score += table[ai - coin][i];
                    }
                    else {
                        break;
                    }
                }

                table[ai][i0] = score;
            }
        }

        return table[amount][0];
    }
}
