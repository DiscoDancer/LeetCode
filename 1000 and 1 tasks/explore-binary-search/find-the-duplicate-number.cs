public class Solution {
    public int FindDuplicate(int[] nums) {
        var table = new bool[100001];
        foreach (var n in nums) {
            if (table[n]) {
                return n;
            }
            table[n] = true;
        }

        return -1;
    }
}