public class Solution {
    public int LargestUniqueNumber(int[] nums) {
        var table = new int[1001];
        foreach (var n in nums) {
            table[n]++;
        }

        for (int i = 1000; i >= 0; i--) {
            if (table[i] == 1) {
                return i;
            }
        }

        return -1;
    }
}