import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;

// see perfect squares

class Solution {
    public int coinChange(int[] coins, int amount) {
        var table = new int[amount + 1];
        for (int i = 1; i <= amount; i++) {
            table[i] = Integer.MAX_VALUE;
        }

        Arrays.sort(coins);

        for (int coin : coins) {
            if (coin > amount) {
                break;
            }
            table[coin] = 1;
        }

        for (var ni = 1; ni <= amount; ni++) {
            var min = Integer.MAX_VALUE;
            for (int coin : coins) {
                if (coin > ni) {
                    break;
                }
                min = Math.min(min, table[ni - coin]);
            }
            if (min != Integer.MAX_VALUE) {
                table[ni] = min + 1;
            }
        }

        return table[amount] == Integer.MAX_VALUE ? -1 : table[amount];
    }
}
