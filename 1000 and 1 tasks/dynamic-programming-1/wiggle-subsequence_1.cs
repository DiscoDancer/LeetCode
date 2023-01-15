public class Solution {
    public int WiggleMaxLength(int[] nums) {
        if (nums.Length == 1) {
            return nums.Length;
        }

        var positive = new int[nums.Length];
        var negative = new int[nums.Length];
        
        for (int i = 1; i < nums.Length; i++) {
            for (int j = 0; j < i; j++) {
                if (nums[i] != nums[j]) {
                    var curSign = nums[i] - nums[j] > 0;
                    var bonus = curSign ? negative[j] : positive[j];
                    if (curSign) {
                        positive[i] = Math.Max(positive[i], 1 + bonus);
                    }
                    else {
                        negative[i] = Math.Max(negative[i], 1 + bonus);
                    }
                }
            }
        }

        return Math.Max(positive.Max(), negative.Max()) + 1;
    }
}