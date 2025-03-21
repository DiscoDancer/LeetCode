class Solution {
    
    private int[] nums;
    
    private int F(int i) {
        if (i >= nums.length) {
            return 0;
        }
        
        // rob
        var rob = nums[i] + F(i+2);
        // not rob
        var notRob = F(i+1);
        
        return Math.max(rob, notRob);
    }
    
    public int rob(int[] nums) {
        this.nums = nums;
        
        return F(0);
    }
}
