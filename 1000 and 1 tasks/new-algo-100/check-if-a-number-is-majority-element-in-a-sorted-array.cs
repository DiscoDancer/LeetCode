public class Solution {
    public bool IsMajorityElement(int[] nums, int target) {
        var table = new Dictionary<int, int>();
        foreach (var n in nums) {
            if (!table.ContainsKey(n)) {
                table[n] = 0;
            }
            table[n]++;
        }

        return table.ContainsKey(target) && table[target] > nums.Length/2;
    }
}