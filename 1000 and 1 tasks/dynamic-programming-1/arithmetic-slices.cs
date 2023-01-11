public class Solution {
    // если последовательность валидна, то ее подпоследовательности тоже валидны
    public int Calc(int x) {
        if (x < 3) {
            return 0;
        }

        var res = 0;
        for (int i = 3; i <= x; i++) {
            res += (i-3 +1);
        }
        return res;
    }

    public int NumberOfArithmeticSlices(int[] nums) {
        if (nums.Length < 3) {
            return 0;
        }

        var startSeqIndex = 0;
        var diff = nums[1] - nums[0];
        var res = 0;

        for (int i = 2; i < nums.Length; i++) {
            if (nums[i] - nums[i-1] == diff) {
                continue;
            }
            else {
                var len = (i-1) - startSeqIndex + 1;
                res += Calc(len);
                diff = nums[i] - nums[i-1];
                startSeqIndex = i - 1;
            }
        }
        var l = (nums.Length - 1) - startSeqIndex + 1;
        res += Calc(l);

        return res;
    }
}