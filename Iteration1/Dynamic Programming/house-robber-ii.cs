public class Solution {
    // сначала решить как обычно
    // хотя пофигу, просто нельзя брать первый и последний
    // заменить по очереди на -1 и просчитать варики - не работает, примерн -1 3 100
    
    public int RegularRob(int[] nums) {
        if (nums.Length == 1) {
            return nums[0];
        }
        if (nums.Length == 2) {
            return 0;
        }
        
        var n = nums.Length;
        
        var sums = new int[n];
        
        for (int i = 0; i < n; i++) {
            var prevSum = i > 0 ? sums[i-1] : 0;
            var prevSum2 = i > 1 ? sums[i-2] : 0;
            sums[i] = Math.Max(prevSum, prevSum2 + nums[i]);
        }
        
        return sums[n - 1];
    }
    
    public int Rob(int[] nums) {
        if (nums.Length == 1) {
            return nums[0];
        }
        if (nums.Length == 2) {
            return Math.Max(nums[0],nums[1]);
        }
        
        var n = nums.Length;
        var a = nums[0];
        var b = nums[n-1];
        
        nums[0] = int.MinValue;
        var r1 = RegularRob(nums);
        nums[0] = a;
        
        nums[n - 1] = int.MinValue;
        var r2 = RegularRob(nums);
        nums[n-1] = b;
        
        return Math.Max(r1,r2);
    }
}