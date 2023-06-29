public class Solution {
    // 2*n
    // max + secondMax
    // мелкие числа
    public int DominantIndex(int[] nums) {
        var table = new bool[101];
        var max = -1;
        var maxIndex = -1;
        for (int i = 0; i < nums.Length; i++) {
            if (!table[nums[i]])
            {
                table[nums[i]] = true;
            }

            if (nums[i] > max)
            {
                max = nums[i];
                maxIndex = i;
            }
        }

        var cur = max - 1;
        while (cur >= 0 ) {
            if (table[cur]) {
                if (max < cur*2) {
                    return -1;
                }
            }
            cur--;
        }

        return maxIndex;
    }
}