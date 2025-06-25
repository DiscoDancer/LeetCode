import java.math.BigInteger;
import java.util.*;

// see koko bananas for reference

class Solution {


    private int[] nums;
    private int k;

    private boolean f(int targetSum) {
        var max = Arrays.stream(nums).max().orElse(0);
        var sum = Arrays.stream(nums).sum();

        // нужно форсить взятие
        long currentSum = sum + 1;
        var pileCount = 0;
        for (var i = 0; i < nums.length; i++) {
            if (currentSum + nums[i] <= targetSum)  {
                currentSum += nums[i];
            }
            else {
                pileCount++;
                currentSum = nums[i];
            }
        }

        // [2,3,1,1,1,1,1]
        // мы как бы строим самый худший случай: мы хотим минимальное количество куч
        // поэтому если минимум меньше, за большее количество куч уж тем более получится
        // но на самом деле несовсем, как будто бы чисел может не хватить для кучек. Надо посмотреть editorial
        return pileCount <= k;
    }

    public int splitArray(int[] nums, int k) {

        this.nums = nums;
        this.k = k;

        var max = Arrays.stream(nums).max().orElse(0);
        var sum = Arrays.stream(nums).sum();

        for (var targetSum = max; targetSum <= sum; targetSum++) {
            if (f(targetSum)) {
                return targetSum;
            }
        }

        var l = max;
        var r = sum;

        while (l <= r) {
            var m = l + (r - l) / 2;
            if (f(m) && (m == 0 || !f(m - 1))) {
                return m;
            } else if (f(m)) {
                r = m - 1;
            } else {
                l = m + 1;
            }
        }

        return -1;
    }
}