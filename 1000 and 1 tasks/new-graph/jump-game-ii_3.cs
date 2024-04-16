public class Solution {
    public int Jump(int[] nums) {
        if (nums.Length == 1) {
            return 0;
        }
        if (nums[0] >= nums.Length - 1) {
            return 1;
        }

        // jump count -> max distance
        var table = new int[nums.Length + 1];
        table[1] = nums[0];

        
        for (int i = 1; i < nums.Length; i++) {

            // сколько прыжков стоит добраться до i?
            // это надо оптимизировать
            var j = 1;
            while (table[j] < i) {
                j++;
            }

            var jumpsToReachI = j;
            table[jumpsToReachI + 1] = Math.Max(i + nums[i], table[jumpsToReachI + 1]);
            if (table[jumpsToReachI + 1] >= nums.Length - 1)
            {
                return jumpsToReachI + 1;
            }
        }

        return -1;
    }
}