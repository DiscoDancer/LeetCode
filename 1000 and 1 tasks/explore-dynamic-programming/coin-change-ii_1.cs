public class Solution {
    // editorial, но я сам переписал в bottom down
    public int Change(int amount, int[] coins) {
        var table = new int[amount+1, coins.Length + 1];
        for (int i = 0; i < coins.Length + 1; i++) {
            table[0, i] = 1;
        }

        for (int i = coins.Length - 1; i >= 0; i--) {
            for (int a = 0; a <= amount; a++) {
                if (coins[i] > a) {
                    table[a,i] = table[a, i + 1];
                }
                else {
                    table[a,i] = table[a-coins[i],i] + table[a, i + 1];
                }
            }
        }

        return table[amount, 0];
    }
}