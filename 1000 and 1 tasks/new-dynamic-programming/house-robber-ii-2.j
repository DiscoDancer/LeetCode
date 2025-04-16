class Solution {

    private int[] nums;
    
    private int F(int i, boolean rob0) {
        if (i >= nums.length) {
            return 0;
        }

        if (i == 0) {
            var rob = nums[i] + F(i+2, true);
            var notRob = F(i+1, false);
            return Math.max(rob, notRob);
        }
        else if (i == nums.length - 1) {
            if (!rob0) {
                // если может, всегда лучше грабить
                return nums[i];
            }
            return 0;
        }
        else {
            var rob = nums[i] + F(i+2, rob0);
            var notRob = F(i+1, rob0);

            return Math.max(rob, notRob);
        }
    }

    public int rob(int[] nums) {
        this.nums = nums;

        return F(0, false);
    }
}
