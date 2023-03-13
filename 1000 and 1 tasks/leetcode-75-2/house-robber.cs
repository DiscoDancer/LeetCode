public class Solution {
    // no adjacent

    private int[] _nums;

    private int F(int index, bool tookLast) {
        if (index >= _nums.Length) {
            return 0;
        }
        // take it or not

        if (!tookLast) {  
            var take = _nums[index] + F(index + 1, true);
            var notTake = F(index + 1, false);
            return Math.Max(take, notTake);
        }

        return F(index + 1, false);
    }

    // too slow, TL
    public int Rob(int[] nums) {
        _nums = nums;
        return F(0, false);
    }
}