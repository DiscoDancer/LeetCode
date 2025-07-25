import java.util.Arrays;

class Solution {
    public int minStartValue(int[] nums) {
        var result = new int[nums.length];
        result[0] = nums[0];
        for (var i = 1; i < nums.length; i++) {
            result[i] = result[i-1] + nums[i];
        }

        
        int min = Arrays.stream(result)
                        .min()
                        .getAsInt();

        if (min >= 0) {
            return 1;
        }
        return 1 - min;
    }
}
