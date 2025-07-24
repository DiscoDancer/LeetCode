import java.math.BigInteger;
import java.util.*;

class Solution {

    public int findMaxConsecutiveOnes(int[] nums) {
        // на случай если в массиве нет единиц
        var max = nums.length > 0 ? 1 : 0;

        var prevCount1 = 0;

        for (var i = 0; i < nums.length; i++) {
            if (nums[i] == 1) {
                var curCount1 = 1;
                var j = i + 1;
                while (j < nums.length && nums[j] == 1) {
                    curCount1++;
                    j++;
                }
                // 0 может быть впереди или сзади
                // тогда мы его допишем к максимуму
                var isThereZeroAround = i > 0 || j < nums.length;
                max = Math.max(curCount1 + (isThereZeroAround ? 1 : 0), max);
                // пробуем соединить островки
                if (prevCount1 > 0) {
                    max = Math.max(curCount1 + prevCount1 + 1, max);
                }
                i = j - 1;
                prevCount1 = curCount1;
            }
            // reset prev, is the gap is bigger than 1
            else if (nums[i] == 0) {
                var curCount0 = 1;
                var j = i + 1;
                while (j < nums.length && nums[j] == 0) {
                    curCount0++;
                    j++;
                }
                i = j - 1;
                if (curCount0 > 1) {
                    prevCount1 = 0;
                }
            }
        }

        return max;
    }
}