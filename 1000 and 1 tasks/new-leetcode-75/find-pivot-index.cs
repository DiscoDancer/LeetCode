public class Solution {
    public int PivotIndex(int[] nums) {
        var prefixesL = new int[nums.Length];
        prefixesL[0] = 0;

        for (int i = 1; i < prefixesL.Length; i++) {
            prefixesL[i] = prefixesL[i-1] + nums[i-1];
        }

        var prefixesR = new int[nums.Length];
        prefixesR[prefixesR.Length - 1] = 0;

        for (int i = prefixesR.Length - 2; i >= 0; i--) {
            prefixesR[i] = prefixesR[i+1] + nums[i+1];
        }

        for (int i = 0; i < nums.Length; i++) {
            if (prefixesL[i] == prefixesR[i]) {
                return i;
            }
        }

        return -1;
    }
}