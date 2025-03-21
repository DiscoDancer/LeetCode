import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;

class Solution {
    private HashMap<Integer, Integer> tableCount = new HashMap<>();
    private Integer[] sortedKeys;
    private int max = 0;

    private void F(int i, int sum) {
        if (i >= sortedKeys.length) {
            max = Math.max(max, sum);
            return;
        }

        // take
        var noNeedToLockNext = i == sortedKeys.length - 1  || (sortedKeys[i+1] - sortedKeys[i] > 1);
        if (noNeedToLockNext) {
            F(i + 1, sum + sortedKeys[i] * tableCount.get(sortedKeys[i]));
        }
        else {
            F(i + 2, sum + sortedKeys[i] * tableCount.get(sortedKeys[i]));
        }
        // skip
        F(i + 1, sum);
    }

    public int deleteAndEarn(int[] nums) {
        for (var num : nums) {
            tableCount.put(num, tableCount.getOrDefault(num, 0) + 1);
        }

        // Convert the keySet to an int[] array
        Integer[] keys = tableCount.keySet().toArray(new Integer[0]);
        Arrays.sort(keys);

        this.sortedKeys = keys;

        F(0, 0);

        return this.max;
    }
}
