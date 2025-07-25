import java.math.BigInteger;
import java.util.*;


class Solution {

    private int mod = 1000000007;

    // issue with overflow


    public int numSubseq(int[] nums, int target) {
        // почему надо сортировать?
        // рандомный хуй объяснил, что так как мы ищем минимум и максимум, то "порядок" не ломается от сортировки
        // на примере всего массива, не важно в каком порядке элементы, максимум и минимум будут одинаковыми
        Arrays.sort(nums);

        var result = BigInteger.valueOf(0);

        for (var left = 0; left < nums.length; left++) {
            var right = left;
            while (right < nums.length - 1 && nums[left] + nums[right + 1] <= target) {
                right++;
            }

            if (nums[left] + nums[right] > target) {
                break;
            }

            var length = right - left + 1;
            result = result.add( BigInteger.valueOf(2).pow(length - 1));
        }

        result = result.mod(BigInteger.valueOf(mod));

        return result.intValue();
    }
}
