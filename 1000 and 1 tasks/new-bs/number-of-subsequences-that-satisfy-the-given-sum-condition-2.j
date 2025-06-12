import java.math.BigInteger;
import java.util.*;


class Solution {

    private int mod = 1000000007;

    private int[] nums;

    // последнее меньше либо равно
    private int bs(int l0, int target) {
        var l = l0;
        int r = nums.length - 1;
        while (l <= r) {
            var m = l + (r - l) / 2;
            if (nums[m] <= target && (m == nums.length-1 || nums[m + 1] > target)) {
                return m;
            }
            if (nums[m] <= target) {
                l = m + 1;
            } else {
                r = m - 1;
            }
        }
        return -1;
    }


    public int numSubseq(int[] nums, int target) {
        // почему надо сортировать?
        // рандомный хуй объяснил, что так как мы ищем минимум и максимум, то "порядок" не ломается от сортировки
        // на примере всего массива, не важно в каком порядке элементы, максимум и минимум будут одинаковыми
        Arrays.sort(nums);
        this.nums = nums;

        var result = BigInteger.valueOf(0);

        for (var left = 0; left < nums.length && nums[left]*2 <= target; left++) {
            var right = bs(left, target- nums[left]);

            var length = right - left + 1;
            result = result.add( BigInteger.valueOf(2).pow(length - 1));
        }

        result = result.mod(BigInteger.valueOf(mod));

        return result.intValue();
    }
}
