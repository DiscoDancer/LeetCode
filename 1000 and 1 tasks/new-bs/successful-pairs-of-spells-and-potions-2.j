import java.util.*;

class Solution {

    private int findFirstIndexGreaterOrEqual(int[] arr, long value) {

        var l = 0;
        var r = arr.length - 1;

        while (l <= r) {
            var m = l + (r - l) / 2;
            if (arr[m] >= value && (m == 0 || arr[m - 1] < value)) {
                return m;
            } else if (arr[m] < value) {
                l = m + 1;
            } else {
                r = m - 1;
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
