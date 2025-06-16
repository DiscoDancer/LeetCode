class Solution {

    // editorial ?

    public int lengthOfLIS(int[] nums) {
        var resultTable = new int[nums.length];
        var max = 0;

        for (var i = nums.length - 1; i >= 0; i--) {
            resultTable[i] = 1;

            var j = i + 1;
            while (j < nums.length) {
                if (nums[j] > nums[i]) {
                    resultTable[i] = Math.max(resultTable[i], resultTable[j] + 1);
                }
                j++;
            }
            
            max = Math.max(max, resultTable[i]);
        }
        
        return max;
    }
}