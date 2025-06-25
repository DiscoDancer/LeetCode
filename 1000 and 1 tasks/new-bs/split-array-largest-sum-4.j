import java.math.BigInteger;
import java.util.*;

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

        return -1;
    }
}