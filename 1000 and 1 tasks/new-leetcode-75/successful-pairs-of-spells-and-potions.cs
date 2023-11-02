public class Solution {
    // в каждом массиве сила
    // TL
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success) {
        var n = spells.Length;
        var m = potions.Length;

        var result = new int[n];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (((long)spells[i])*potions[j] >= success) {
                    result[i]++;
                }
            }
        }

        return result;
    }
}