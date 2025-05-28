import java.util.*;

class Solution {

    private int findFirstIndexGreaterOrEqual(int[] arr, long value) {
        for (var i = 0; i < arr.length; i++) {
            if (arr[i] >= value) {
                return i;
            }
        }
        return -1;
    }

    public int[] successfulPairs(int[] spells, int[] potions, long success) {
        var result = new int[spells.length];

        Arrays.sort(potions);

        for (var i = 0; i < spells.length; i++) {
            int count = 0;
            var minPotionStrength = success / spells[i];
            // если у нас там что-то отвалилось из округления, нам надо взять следующее число
            if ((long)minPotionStrength * spells[i] < success) {
                minPotionStrength++;
            }
            var index = findFirstIndexGreaterOrEqual(potions, minPotionStrength);
            if (index != -1) {
                count = potions.length - index;
            }
            result[i] = count;
        }

        return result;
    }
}
