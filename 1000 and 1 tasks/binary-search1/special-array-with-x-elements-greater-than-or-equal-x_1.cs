public class Solution {
    // https://leetcode.com/problems/special-array-with-x-elements-greater-than-or-equal-x/discuss/877791/Java-Counting-Sort-Two-Pass-Simple-Code
    public int SpecialArray(int[] nums) {
        var count = new int[1001];
        foreach (var n in nums) {
            count[n]++;
        }
        
        var left = nums.Length;
        for (int i = 0; i <= nums.Length; i++) {
            if (i == left) {
                return i;
            }
            left -= count[i];
        }
        
        return -1;
    }
}