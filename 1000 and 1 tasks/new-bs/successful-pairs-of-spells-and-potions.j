import java.util.*;

// TL

class Solution {

    public int[] successfulPairs(int[] spells, int[] potions, long success) {
        var result = new int[spells.length];

        for (var i = 0; i < spells.length; i++) {
            int count = 0;
            for (var potion : potions) {
                if ((long) spells[i] * potion >= success) {
                    count++;
                }
            }
            result[i] = count;
        }

        return result;
    }
}
