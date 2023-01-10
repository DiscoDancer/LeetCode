public class Solution {
    // (done) перебор за n3 (TL)
    // можно перебор за n2?
    // как предыдущее решение
    public int GetMaxLen(int[] nums) {
        var max = 0;
        for (int size = 1; size <= nums.Length; size++) {
            for (int start = 0; start + size <= nums.Length; start++) {
                var count = 0;
                var sign = true;
                for (int i = start; i < size + start && nums[i] != 0; i++) {
                    sign = nums[i] > 0 ? sign : !sign;
                    count++;
                    if (sign) {
                        max = Math.Max(count, max);
                    }
                }
                if (sign) {
                    max = Math.Max(count, max);
                }
            }
        }

        return max;
    }
}